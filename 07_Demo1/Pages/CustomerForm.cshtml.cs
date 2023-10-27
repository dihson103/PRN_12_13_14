using _07_Demo1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _07_Demo1.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Mesage { get; set; }

        [BindProperty]
        public Customer customerInfo { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Mesage = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Mesage = "Error on input data.";
            }
        }
    }
}
