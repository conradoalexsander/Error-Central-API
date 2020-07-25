using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Domain.Model
{
    public class Error
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Type { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}