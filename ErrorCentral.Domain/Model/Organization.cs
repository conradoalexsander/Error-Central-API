using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Domain.Model
{
    public class Organization : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Log> Logs { get; set; }
    }
}