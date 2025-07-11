﻿using System.ComponentModel.DataAnnotations;

namespace TeknorixTest.Dtos
{
    public class CreateDepartmentDto 
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public required string Title { get; set; }
    }
}
