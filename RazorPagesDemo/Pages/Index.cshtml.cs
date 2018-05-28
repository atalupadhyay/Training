using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        public string Nachricht { get; private set; } = "Hallo vom Page Model";

        public void OnGet()
        {
            Nachricht += $" Serverzeit ist heute { DateTime.Now }";
        }
    }
}