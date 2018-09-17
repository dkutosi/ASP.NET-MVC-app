using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.Entities;
using System.ComponentModel.DataAnnotations;


namespace AspNetCoreVideo.Entities
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}
