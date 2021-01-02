using ContactUs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContactUs.Form.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ContactUs.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserMessage> messages;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44336/usermessages"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    messages = JsonConvert.DeserializeObject<IEnumerable<UserMessage>>(apiResponse);
                }
            }

            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            UserMessage message = new UserMessage()
            {
                FirstName = form["firstName"],
                LastName = form["lastName"],
                Email = form["email"],
                Message = form["message"]
            };

            var json = JsonConvert.SerializeObject(message);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                await httpClient.PostAsync("https://localhost:44336/usermessages", data);
            }

            return await Index();
        }
    }
}
