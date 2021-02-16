using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoManagement.Models
{
    public class Video
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [Range(30, 300, ErrorMessage = "Length is not valid")]
        public int Length { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [MaxLength(4)]
        public string Format { get; set; }
    }
}
