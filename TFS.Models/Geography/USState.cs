using System.Collections.Generic;
using Centro.DomainModel;

namespace TFS.Models.Geography
{
    public sealed class USState : BaseEntity
    {
        private static Dictionary<string, USState> states = new Dictionary<string, USState>();

        static USState()
        {
            states.Add("AL", new USState("Alabama", "AL"));
            states.Add("AK", new USState("Alaska", "AK"));
            states.Add("AZ", new USState("Arizona", "AZ"));
            states.Add("AR", new USState("Arkansas", "AR"));
            states.Add("CA", new USState("California", "CA"));
            states.Add("CO", new USState("Colorado", "CO"));
            states.Add("CT", new USState("Connecticut", "CT"));
            states.Add("DE", new USState("Delaware", "DE"));
            states.Add("FL", new USState("Florida", "FL"));
            states.Add("GA", new USState("Georgia", "GA"));
            states.Add("HI", new USState("Hawaii", "HI"));
            states.Add("ID", new USState("Idaho", "ID"));
            states.Add("IL", new USState("Illinois", "IL"));
            states.Add("IN", new USState("Indiana", "IN"));
            states.Add("IA", new USState("Iowa", "IA"));
            states.Add("KS", new USState("Kansas", "KS"));
            states.Add("KY", new USState("Kentucky", "KY"));
            states.Add("LA", new USState("Louisiana", "LA"));
            states.Add("ME", new USState("Maine", "ME"));
            states.Add("MD", new USState("Maryland", "MD"));
            states.Add("MA", new USState("Massachusetts", "MA"));
            states.Add("MI", new USState("Michigan", "MI"));
            states.Add("MN", new USState("Minnesota", "MN"));
            states.Add("MS", new USState("Mississippi", "MS"));
            states.Add("MO", new USState("Missouri", "MO"));
            states.Add("MT", new USState("Montana", "MT"));
            states.Add("NE", new USState("Nebraska", "NE"));
            states.Add("NV", new USState("Nevada", "NV"));
            states.Add("NH", new USState("New Hampshire", "NH"));
            states.Add("NJ", new USState("New Jersey", "NJ"));
            states.Add("NM", new USState("New Mexico", "NM"));
            states.Add("NY", new USState("New York", "NY"));
            states.Add("NC", new USState("North Carolina", "NC"));
            states.Add("ND", new USState("North Dakota", "ND"));
            states.Add("OH", new USState("Ohio", "OH"));
            states.Add("OK", new USState("Oklahoma", "OK"));
            states.Add("OR", new USState("Oregon", "OR"));
            states.Add("PA", new USState("Pennsylvania", "PA"));
            states.Add("RI", new USState("Rhode Island", "RI"));
            states.Add("SC", new USState("South Carolina", "SC"));
            states.Add("SD", new USState("South Dakota", "SD"));
            states.Add("TN", new USState("Tennessee", "TN"));
            states.Add("TX", new USState("Texas", "TX"));
            states.Add("UT", new USState("Utah", "UT"));
            states.Add("VT", new USState("Vermont", "VT"));
            states.Add("VA", new USState("Virginia", "VA"));
            states.Add("WA", new USState("Washington", "WA"));
            states.Add("WV", new USState("West Virginia", "WV"));
            states.Add("WI", new USState("Wisconsin", "WI"));
            states.Add("WY", new USState("Wyoming", "WY"));
            states.Add("AS", new USState("American Samoa", "AS"));
            states.Add("DC", new USState("District of Columbia", "DC"));
            states.Add("FM", new USState("Federated States of Micronesia", "FM"));
            states.Add("GU", new USState("Guam", "GU"));
            states.Add("MH", new USState("Marshall Islands", "MH"));
            states.Add("MP", new USState("Northern Mariana Islands", "MP"));
            states.Add("PW", new USState("Palau", "PW"));
            states.Add("PR", new USState("Puerto Rico", "PR"));
            states.Add("VI", new USState("Virgin Islands", "VI"));
        }

        public static USState FromAbbreviation(string abbreviation)
        {
            if (states.ContainsKey(abbreviation))
                return states[abbreviation];
            return null;
        }

        public static USState Alabama { get { return states["AL"]; } }
        public static USState Alaska { get { return states["AK"]; } }
        public static USState Arizona { get { return states["AZ"]; } }
        public static USState Arkansas { get { return states["AR"]; } }
        public static USState California { get { return states["CA"]; } }
        public static USState Colorado { get { return states["CO"]; } }
        public static USState Connecticut { get { return states["CT"]; } }
        public static USState Delaware { get { return states["DE"]; } }
        public static USState Florida { get { return states["FL"]; } }
        public static USState Georgia { get { return states["GA"]; } }
        public static USState Hawaii { get { return states["HI"]; } }
        public static USState Idaho { get { return states["ID"]; } }
        public static USState Illinois { get { return states["IL"]; } }
        public static USState Indiana { get { return states["IN"]; } }
        public static USState Iowa { get { return states["IA"]; } }
        public static USState Kansas { get { return states["KS"]; } }
        public static USState Kentucky { get { return states["KY"]; } }
        public static USState Louisiana { get { return states["LA"]; } }
        public static USState Maine { get { return states["ME"]; } }
        public static USState Maryland { get { return states["MD"]; } }
        public static USState Massachusetts { get { return states["MA"]; } }
        public static USState Michigan { get { return states["MI"]; } }
        public static USState Minnesota { get { return states["MN"]; } }
        public static USState Mississippi { get { return states["MS"]; } }
        public static USState Missouri { get { return states["MO"]; } }
        public static USState Montana { get { return states["MT"]; } }
        public static USState Nebraska { get { return states["NE"]; } }
        public static USState Nevada { get { return states["NV"]; } }
        public static USState NewHampshire { get { return states["NH"]; } }
        public static USState NewJersey { get { return states["NJ"]; } }
        public static USState NewMexico { get { return states["NM"]; } }
        public static USState NewYork { get { return states["NY"]; } }
        public static USState NorthCarolina { get { return states["NC"]; } }
        public static USState NorthDakota { get { return states["ND"]; } }
        public static USState Ohio { get { return states["OH"]; } }
        public static USState Oklahoma { get { return states["OK"]; } }
        public static USState Oregon { get { return states["OR"]; } }
        public static USState Pennsylvania { get { return states["PA"]; } }
        public static USState RhodeIsland { get { return states["RI"]; } }
        public static USState SouthCarolina { get { return states["SC"]; } }
        public static USState SouthDakota { get { return states["SD"]; } }
        public static USState Tennessee { get { return states["TN"]; } }
        public static USState Texas { get { return states["TX"]; } }
        public static USState Utah { get { return states["UT"]; } }
        public static USState Vermont { get { return states["VT"]; } }
        public static USState Virginia { get { return states["VA"]; } }
        public static USState Washington { get { return states["WA"]; } }
        public static USState WestVirginia { get { return states["WV"]; } }
        public static USState Wisconsin { get { return states["WI"]; } }
        public static USState Wyoming { get { return states["WY"]; } }
        public static USState AmericanSamoa { get { return states["AS"]; } }
        public static USState DistrictOfColumbia { get { return states["DC"]; } }
        public static USState FederatedStatesOfMicronesia { get { return states["FM"]; } }
        public static USState Guam { get { return states["GU"]; } }
        public static USState MarshallIslands { get { return states["MH"]; } }
        public static USState NorthernMarianaIslands { get { return states["MP"]; } }
        public static USState Palau { get { return states["PW"]; } }
        public static USState PuertoRico { get { return states["PR"]; } }
        public static USState VirginIslands { get { return states["VI"]; } }

        private USState(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
    }

}
