using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactUs.Domain.Entities;
using ContactUs.API.Interfaces;
using Newtonsoft.Json;

namespace ContactUs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMessagesController : Controller
    {
        private readonly IUserMessageService service;

        public UserMessagesController(IUserMessageService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserMessage>> Get()
        {
            return await service.GetAllUserMessages();
        }

        [HttpPost]
        public async void Post([FromBody] dynamic value)
        {
            string jsonResponse = Convert.ToString(value);
            UserMessage submission = JsonConvert.DeserializeObject<UserMessage>(jsonResponse);
            await service.SetUserMessage(submission);
        }
    }
}
