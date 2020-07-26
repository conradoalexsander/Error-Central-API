using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErrorCentral.Domain.Model
{
    public class Error
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string CreatedAt { get; set; }
    }
}