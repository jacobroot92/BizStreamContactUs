using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactUs.API.Interfaces;
using ContactUs.Domain.Entities;
using ContactUs.Domain.Repositories;

namespace ContactUs.API.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly IUserMessageRepo userMessageRepo;

        public UserMessageService(IUserMessageRepo userMessageRepo)
        {
            this.userMessageRepo = userMessageRepo;
        }
        public async Task<IEnumerable<UserMessage>> GetAllUserMessages()
        {
            return await userMessageRepo.GetAllUserMessages();
        }

        public async Task<int> SetUserMessage(UserMessage submisson)
        {
            return await userMessageRepo.SetUserMessage(submisson);
        }
    }
}
