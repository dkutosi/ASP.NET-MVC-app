﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.ViewModels
{
    public class VideoViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}