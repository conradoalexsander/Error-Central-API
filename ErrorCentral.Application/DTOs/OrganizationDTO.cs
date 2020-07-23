using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCentral.Application.DTOs
{
    public class OrganizationDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<LogDTO> Logs { get; set; }
    }
}