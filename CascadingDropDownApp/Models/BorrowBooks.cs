using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class BorrowBooks
    {
        [DisplayName("Student ID:")]
        [Required(ErrorMessage = "Please Select a Student")]
        public string StudentID { get; set; }

        [DisplayName("Book Title: ")]
        [Required(ErrorMessage = "Please Select a Book")]
        public string BookTitle { get; set; }

        [DisplayName("Book Code: ")]
        public string BookCode { get; set; }
        public int BookQuantity { get; set; }
        public string BookAuthor { get; set; }
        public string StudentName { get; set; }
        public string StudentContactNo { get; set; }
      
    }
}