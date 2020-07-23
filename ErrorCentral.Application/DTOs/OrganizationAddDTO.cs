using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCentral.Application.DTOs
{
    public class OrganizationAddDTO
    {
        [Required]
        public string Name { get; set; }
    }
}