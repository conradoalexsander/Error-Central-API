﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCentral.Application.DTOs
{
    public class LogAddDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string CollectedBy { get; set; }

        [Required]
        public int IdOrganization { get; set; }
    }
}