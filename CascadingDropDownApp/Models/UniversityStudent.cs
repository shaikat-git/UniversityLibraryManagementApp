using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class UniversityStudent
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "Please Enter Student ID Number")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "ID must be at least 5 to maximum 10 characters long")]
        public string StudentId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please Enter Student Name")]
        public string StudentName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please Enter Student Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid Email")]
        public string StudentEmail { get; set; }

        [DisplayName("Contact No")]
        [Required(ErrorMessage = "Please Enter Contact No")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Contact No must be 11 characters long")]
        public string StudentContactNo { get; set; }

    }
}