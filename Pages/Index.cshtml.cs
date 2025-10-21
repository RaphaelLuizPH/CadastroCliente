using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Service.Database;

namespace CadastroCliente.Pages.Fornecedores
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<Fornecedor> Fornecedor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Fornecedor = await _context.Fornecedores.ToListAsync();
        }






    }
}
