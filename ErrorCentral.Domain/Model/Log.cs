using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Domain.Model
{
    public class Log : IEntity

    {
        public int Id { get; set; }
        public string organization { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string level { get; set; }
        public string origin { get; set; }
        public string collectedBy { get; set; }
        public DateTime createdAt { get; set; }
    }
}