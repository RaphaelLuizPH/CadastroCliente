using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Pages.Shared;
using CadastroCliente.Service.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Pages
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _context;
        public readonly ImageHelper _helper;

        public CreateModel(DatabaseContext context, ImageHelper imageHelper)
        {
            _context = context;
            _helper = imageHelper;
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

            if (await _context.Fornecedores.AnyAsync(f => f.Cnpj == Fornecedor.Cnpj))
            {
                ModelState.AddModelError("Fornecedor.Cnpj", "Este CNPJ já está cadastrado no sistema.");
                return Page();
            };




            if (Foto != null && Foto.Length > 0)
            {
               
                var filename = $"{Guid.NewGuid()}{Path.GetExtension(Foto.FileName)}";
                Fornecedor.FotoUrl = filename;
                await _helper.UploadImage(Foto, filename);
            }


         




            _context.Fornecedores.Add(Fornecedor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}