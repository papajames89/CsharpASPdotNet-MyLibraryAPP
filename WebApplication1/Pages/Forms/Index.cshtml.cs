using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.Forms
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Books> Books { get; set; }
        public void OnGet()
        {
            Books = _context.Books.ToList();
        }

        public IActionResult OnPostDelete(int Id)
        {
            var itemToDelete = _context.Books.Find(Id);
            if (itemToDelete == null)
            {
                return NotFound();
            }
            _context.Books.Remove(itemToDelete);
            _context.SaveChanges();
            return RedirectToPage("/Forms/Index");
        }
    }
}
