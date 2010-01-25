using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.Help;
using System;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class HelpRepository : NHibernateRepository, IHelpRepository
    {
        public HelpRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return Query<Question>().ToList();
        }

        public IEnumerable<Question> GetRecentQuestions(int maxResult)
        {
            return Query<Question>().Take(maxResult).ToList();
        }

        public Question AddQuestion(Question question)
        {
            question.AskedOnDate = DateTime.UtcNow;
            question.LastModifiedDate = question.AskedOnDate;
            question.Validate();
            return Persist<Question>(question);
        }
    }
}
