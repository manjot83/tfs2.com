using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonnelRecordsMigrator.Old;
using PersonnelRecordsMigrator.New;
using System.Data.Linq;

namespace PersonnelRecordsMigrator
{
    class Program
    {
        private OldDatabase oldDatabase;
        private NewDatabase newDatabase;

        static void Main(string[] args)
        {
            new Program().Run();
        }

        public Program()
        {
            oldDatabase = new OldDatabase(@"Server=apollo.tfs2.com;Database=tfs_opcenter;user id=sa;password=willypete;");
            newDatabase = new NewDatabase(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;");
        }

        public void Run()
        {
            var usernames = GetAllNewUsernames();
            foreach (var username in usernames)
            {
                var person = GetOrCreatePersonForUsername(username);
                var qualification = GetOrCreateQualification(person);
                var records = GetOldFormRecordsForUsername(username);
                foreach (var record in records)
                {
                    UpdatePerson(person, record);
                    UpdateQual(qualification, record);
                    newDatabase.SubmitChanges();
                }
            }
        }

        IList<string> GetAllNewUsernames()
        {
            return newDatabase.Users.Select(x => x.Username).ToList();
        }

        IList<Formrecord> GetOldFormRecordsForUsername(string username)
        {
            return oldDatabase.Formrecords.Where(x => x.Formfile.Person.Username.Contains(username) &&
                                                      x.Formfile.Formid == 103).ToList();
        }

        New.Person GetOrCreatePersonForUsername(string username)
        {
            var person = newDatabase.Persons.FirstOrDefault(x => x.User.Username == username);
            if (person == null)
            {
                var user = newDatabase.Users.FirstOrDefault(x => x.Username == username);
                person = new PersonnelRecordsMigrator.New.Person
                {
                    User = user,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
                newDatabase.Persons.InsertOnSubmit(person);
                newDatabase.SubmitChanges();
            }
            return person;
        }

        Qualification GetOrCreateQualification(New.Person person)
        {
            var qual = newDatabase.Qualifications.FirstOrDefault(x => x.PersonId == person.PersonId);
            if (qual == null)
            {
                qual = new Qualification
                {
                    Person = person,
                };
                newDatabase.Qualifications.InsertOnSubmit(qual);
                newDatabase.SubmitChanges();
            }
            return qual;
        }

        void UpdatePerson(New.Person person, Formrecord record)
        {
            switch (record.Formfield.Name)
            {
                case "Last Name": person.LastName = record.Storedvalue; return;
                case "First Name": person.FirstName = record.Storedvalue; return;
                case "Middle Initial": person.MiddleInitial = record.Storedvalue; return;
                case "SSN Last Four": person.SocialSecurityLastFour = record.Storedvalue; return;
                case "Date of Birth": person.DateOfBirth = TryParseDate(record.Storedvalue); return;
                case "Gender": person.Gender = MaleOrFemale(record.Storedvalue); return;
                case "Phone": person.PrimaryPhoneNumber = StripExtraPhoneCharacters(record.Storedvalue); return;
                case "Alt. Phone": person.AlternatePhoneNumber = StripExtraPhoneCharacters(record.Storedvalue); return;
                case "E-mail Address": person.AlternateEmail = record.Storedvalue; return;
                case "Emergency Contact Name": person.EmergencyContactName = record.Storedvalue; return;
                case "Emergency Contact Phone": person.EmergencyContactPhoneNumber = StripExtraPhoneCharacters(record.Storedvalue); return;
                case "Position": person.Position = TryGetPosition(record.Storedvalue); return;
                case "Address": person.StreetAddress = record.Storedvalue; return;
                default: return;
            };
        }

        void UpdateQual(Qualification qual, Formrecord record)
        {
            switch (record.Formfield.Name)
            {
                case "Date Last BFR or Qual Form 8": qual.LastBFR = TryParseDate(record.Storedvalue); return;
                case "Date Last Military Flight Physical": qual.LastMilitaryFlightPhysical = TryParseDate(record.Storedvalue); return;
                case "Date Last Altitude Chamber": qual.LastAltitudeChamber = TryParseDate(record.Storedvalue); return;
                case "Date Last Egrees Training LL-03": qual.LastEgreesTraining = TryParseDate(record.Storedvalue); return;
                case "Date Last Simulator Refresher": qual.LastSimulatorRefresher = TryParseDate(record.Storedvalue); return;
                case "Date Last CRM": qual.LastCRM = TryParseDate(record.Storedvalue); return;
                case "Date Last Life Support Training": qual.LastLifeSupportTraining = TryParseDate(record.Storedvalue); return;
                case "Date Last Flight": qual.LastFlight = TryParseDate(record.Storedvalue); return;
                case "Military FCF Qual": qual.MilitaryFCFQualification = PraseFCFQual(record.Storedvalue); return;
                default: return;
            };
        }

        string StripExtraPhoneCharacters(string input)
        {
            if (input == null)
                return null;
            var number = input.Replace(")", "")
                .Replace("(", "")
                .Replace(".", "")
                .Replace("-", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace(",", "")
                .Replace(" ", "");
            number = number.Replace("Cell:", "");
            number = number.Replace("HOME#OR", "");
            if (number.Length > 10)
            {
                number = number.Substring(0, 10);
            }
            return number;
        }

        DateTime? TryParseDate(string input)
        {
            if (input == null)
                return null;
            DateTime date = DateTime.Now;
            if (!DateTime.TryParse(input, out date))
                return null;
            return date;
        }

        int? MaleOrFemale(string input)
        {
            if (input == null)
                return null;
            if (input.ToUpperInvariant() == "MALE")
                return 1;
            if (input.ToUpperInvariant() == "FEMALE")
                return 2;
            return null;
        }

        Position TryGetPosition(string input)
        {
            if (input == null)
                return null;
            return newDatabase.Positions.FirstOrDefault(x => x.Title.Contains(input));
        }

        int? PraseFCFQual(string input)
        {
            if (input == null)
                return null;
            if (input.ToUpperInvariant() == "NO")
                return 0;
            if (input.ToUpperInvariant() == "YES")
                return 1;
            if (input.StartsWith("TFS"))
                return 2;
            return null;
        }
    }
}
