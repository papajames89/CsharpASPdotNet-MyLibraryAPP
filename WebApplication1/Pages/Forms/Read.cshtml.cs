using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.Forms
{
    public class ReadModel : PageModel
    {
        private readonly AppDbContext _context;

        public ReadModel(AppDbContext context)
        {
            _context = context;
        }

        public Books Books { get; set; }


        public void OnGet(int Id)
        {
            Books = _context.Books.Find(Id);
        }
    }
}
