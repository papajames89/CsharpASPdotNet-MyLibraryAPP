using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
namespace WebApplication1.Pages.Forms
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Books { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                var target = new MemoryStream();
                Upload.CopyTo(target);
                Books.Image = target.ToArray();
            }
            _context.Books.Add(Books);
                _context.SaveChangesAsync();
            
            return RedirectToPage("/Forms/Index");
        }
    }
}
