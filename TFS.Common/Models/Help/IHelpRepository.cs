using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Help
{
    public interface IHelpRepository
    {
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> GetRecentQuestions(int maxResult);
        Question AddQuestion(Question question);
    }
}
