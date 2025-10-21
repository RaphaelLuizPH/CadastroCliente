using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Service.Database;

namespace CadastroCliente.Pages
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _context;

        public CreateModel(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fornecedor Fornecedor { get; set; } = default!;


        [BindProperty]
        public IFormFile? Foto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Foto != null && Foto.Length > 0)
            {
                using var ms = new MemoryStream();
                await Foto.CopyToAsync(ms);
                Fornecedor.Foto = ms.ToArray();
            }

            _context.Fornecedores.Add(Fornecedor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}