using ContactUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Domain.Repositories
{
    public interface IUserMessageRepo
    {
        Task<IEnumerable<UserMessage>> GetAllUserMessages();
        Task<int> SetUserMessage(UserMessage submisson);
    }
}
