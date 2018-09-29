using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie, IEnumerable<Genre> genres)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            Genres = genres;

        }

        public MovieFormViewModel(IEnumerable<Genre> genres)
        { 
            Id=0;
            Genres = genres;
        }

        public Movie ToMovie()
        {
            return new Movie
            {
                Id = Id.Value,
                Name = Name,
                DateAdded = DateAdded.Value,
                ReleaseDate = ReleaseDate.Value,
                GenreId = GenreId.Value,
                NumberInStock = NumberInStock.Value
            };
        }


    }
}