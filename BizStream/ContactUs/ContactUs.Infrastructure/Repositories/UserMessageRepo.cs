using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ContactUs.Domain.Entities;
using ContactUs.Domain.Repositories;
using Newtonsoft.Json;

namespace ContactUs.Infrastructure.Repositories
{
    public class UserMessageRepo : IUserMessageRepo
    {
        List<UserMessage> messages = new List<UserMessage>();
        string messagesFileName = "messages.json";

        async Task<IEnumerable<UserMessage>> IUserMessageRepo.GetAllUserMessages()
        {
            string currentMessages = File.ReadAllText(messagesFileName);
            messages = JsonConvert.DeserializeObject<List<UserMessage>>(currentMessages);

            return await Task.FromResult(messages);
        }

        async Task<int> IUserMessageRepo.SetUserMessage(UserMessage submission)
        {
            submission.Id = messages.Count + 1;
            messages.Add(submission);

            var json = JsonConvert.SerializeObject(messages);

            File.WriteAllText(messagesFileName, json);

            return await Task.FromResult(1);
        }
    }
}
