using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class ActorResponseDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Unicode(false)]
        public string Picture { get; set; }
    }
}
