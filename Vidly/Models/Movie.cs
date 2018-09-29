using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }

        public virtual Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}