using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_Music.Models
{
    //专辑的流派，流行，古典。。。
    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}