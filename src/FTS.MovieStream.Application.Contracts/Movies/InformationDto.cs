using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FTS.MovieStream.Movies
{
    public class InformationDto
    {
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
