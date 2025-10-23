using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Pages.Shared;
using CadastroCliente.Service.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Pages.Fornecedores
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;
        public readonly ImageHelper _helper;

        public DetailsModel(DatabaseContext context, ImageHelper imageHelper)
        {
            _context = context;
            _helper = imageHelper;
        }

        public Fornecedor Fornecedor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);

                if (fornecedor is not null)
                {
                    Fornecedor = fornecedor;

                    return Page();
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
