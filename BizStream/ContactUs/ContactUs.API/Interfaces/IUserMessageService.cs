using ContactUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactUs.API.Interfaces
{
    public interface IUserMessageService
    {
        public Task<IEnumerable<UserMessage>> GetAllUserMessages();
        public Task<int> SetUserMessage(UserMessage submisson);
    }
}
