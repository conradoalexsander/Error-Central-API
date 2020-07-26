using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Domain.Repository
{
    public interface IEntity
    {
        int Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}