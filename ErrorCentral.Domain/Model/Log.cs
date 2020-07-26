using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErrorCentral.Domain.Model
{

    public class Log : IEntity

    {
   
        public int Id { get; set; }

   
        public string Title { get; set; }

  
        public string Description { get; set; }


        public string Level { get; set; }


        public string Origin { get; set; }


        public string CollectedBy { get; set; }


        public int IdOrganization { get; set; }


        public string CreatedAt { get; set; }


        public string UpdatedAt { get; set; }

        public virtual Organization Organization { get; set; }
    }
}