using TFS.Models.Users;
using System;

namespace TFS.Models.Help
{
    public class HelpManager
    {
        public HelpManager(IHelpRepository helpRepository, IUserRepository userRepository)
        {
            HelpRepository = helpRepository;
            UserRepository = userRepository;
        }

        public IHelpRepository HelpRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public Question AddQuestion(Question question)
        {
            question.AskedOnDate = DateTime.UtcNow;
            question.LastModifiedDate = question.AskedOnDate;
            question.Validate();
            return HelpRepository.AddQuestion(question);
        }
    }
}
