using System;
using System.Collections.Generic;
using System.Text;

namespace ContactUs.Domain.Entities
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
