using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class Book
    {
        [DisplayName("ISBN")]
        [Required(ErrorMessage = "Please Enter Book Code Number")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "ISBN must be at least 5 to maximum 15 characters long")]
        public string BookCode { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please Enter Book Title")]
        public string BookTitle { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Please Enter Book Quantity")]
        [Range(1, 200, ErrorMessage = "Please enter value from 1 to 200")]
        public int BookQuantity { get; set; }
        public int BookRemaining { get; set; }

        [DisplayName("Author")]

        [Required(ErrorMessage = "Please Enter Book Author")]
        public string BookAuthor { get; set; }

        [DisplayName("Publisher")]
        [Required(ErrorMessage = "Please Enter Book Publisher")]
        public string BookPublisher { get; set; }
    }
}