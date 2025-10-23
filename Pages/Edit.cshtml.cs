using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Service.Database;
using CadastroCliente.Pages.Shared;

namespace CadastroCliente.Pages.Fornecedores
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _context;
        public readonly ImageHelper _helper;

        public EditModel(DatabaseContext context, ImageHelper imageHelper)
        {
            _context = context;
            _helper = imageHelper;
        }

        [BindProperty]
        public Fornecedor Fornecedor { get; set; } = default!;

        [BindProperty]
        public IFormFile? Foto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var fornecedor =  await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            Fornecedor = fornecedor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (await _context.Fornecedores.AnyAsync(f => f.Cnpj == Fornecedor.Cnpj && f.Id != Fornecedor.Id))
                {
                    ModelState.AddModelError("Fornecedor.Cnpj", "Este CNPJ já está cadastrado no sistema.");
                    return Page();
                }
                ;


                var existing = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == Fornecedor.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                existing.Nome = Fornecedor.Nome;
                existing.Segmento = Fornecedor.Segmento;
                existing.Cep = Fornecedor.Cep;
                existing.Endereco = Fornecedor.Endereco;


                if (Foto is not null && Foto.Length > 0)
                {
                    var filename = $"{Guid.NewGuid()}{Path.GetExtension(Foto.FileName)}";
                    await _helper.ReplaceImage(Foto, filename);
                    existing.FotoUrl = filename;
                }

                await _context.SaveChangesAsync();




            }
           
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(Fornecedor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return RedirectToPage("./Index");
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
