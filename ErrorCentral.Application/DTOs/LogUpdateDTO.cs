using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCentral.Application.DTOs
{
    public class LogUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Level { get; set; }
    }
}