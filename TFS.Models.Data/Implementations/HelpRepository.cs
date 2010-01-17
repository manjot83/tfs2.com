using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.Help;
using System;

namespace TFS.Models.Data.Implementations
{
    public class HelpRepository : NHibernateRepository, IHelpRepository
    {
        public HelpRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return Session.Linq<Question>().ToList();
        }

        public IEnumerable<Question> GetRecentQuestions(int maxResult)
        {
            return Session.Linq<Question>().Take(maxResult).ToList();
        }

        public Question AddQuestion(Question question)
        {
            question.AskedOnDate = DateTime.UtcNow;
            question.LastModifiedDate = question.AskedOnDate;
            question.Validate();
            return Session.SaveOrUpdateCopy<Question>(question);
        }
    }
}
