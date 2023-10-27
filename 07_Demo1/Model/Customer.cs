using _07_Demo1.Binding;
using _07_Demo1.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _07_Demo1.Model
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(
            20, 
            MinimumLength = 3, 
            ErrorMessage = "The length of name is from 3 to 20 characters."
            )]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required!")]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}
