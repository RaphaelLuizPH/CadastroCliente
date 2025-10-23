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
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;
        public readonly ImageHelper _helper;

        public IndexModel(DatabaseContext context, ImageHelper imageHelper)
        {
            _context = context;
            _helper = imageHelper;
        }


        public IList<Fornecedor> Fornecedor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Fornecedor = await _context.Fornecedores.ToListAsync();
        }






    }
}
