using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;




namespace WebApplication1.Models
{
    public class SongsList
    {
        public int Id { get; set; }
        
        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public decimal Length { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "YoutubeUrl Link")]
        public string YoutubeUrl { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }
    }
}