using System;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }
    }
}