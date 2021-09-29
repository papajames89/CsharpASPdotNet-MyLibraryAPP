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
    public class UpdateModel : PageModel
    {
        private readonly AppDbContext _context;

        public UpdateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Books Books { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        public void OnGet(int Id)
        {
            Books = _context.Books.Find(Id);
        }

        public IActionResult OnPostUpdate(int Id)
        {
            var itemToUpdate = _context.Books.Find(Id);
            itemToUpdate.Title = Books.Title;
            itemToUpdate.Rating = Books.Rating;
            itemToUpdate.Description = Books.Description;

            if (Upload != null)
            {
                var target = new MemoryStream();
                Upload.CopyTo(target);
                itemToUpdate.Image = target.ToArray();
            }
            _context.SaveChanges();
            return RedirectToPage("/Forms/Index");
        }
    }
}
