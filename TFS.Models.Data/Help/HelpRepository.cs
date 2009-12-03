using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.Help;

namespace TFS.Models.Data.Help
{
    public class HelpRepository : BaseDataAccessObject, IHelpRepository
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

        public Question GetQuestionById(int id)
        {
            return Session.Get<Question>(id);
        }

        public Question AddQuestion(Question question)
        {
            question.Validate();
            return Session.SaveOrUpdateCopy<Question>(question);
        }
    }
}
