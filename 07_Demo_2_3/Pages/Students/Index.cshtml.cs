using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _07_Demo_2_3.Models;

namespace _07_Demo_2_3.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly _07_Demo_2_3.Models.Demo2Slot121314Context _context;

        public IndexModel(_07_Demo_2_3.Models.Demo2Slot121314Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public string? searchValue { get; set; } = string.Empty;

        public async Task OnGetAsync(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (_context.Students != null)
                {
                    Student = await _context.Students.ToListAsync();
                }
            }
            else
            {
                Student = await _context.Students
                    .Where(student => (student.FirstName + " " + student.LastName).Contains(name))
                    .ToListAsync();
            }
            searchValue = name;
        }
    }
}
