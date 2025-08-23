using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class ActorRequestDto
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public IFormFile Picture { get; set; }
    }
}
