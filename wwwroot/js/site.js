// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const BuscarCEP = async (cep) => {
    console.log("Run");

    const enderecoElement = document.querySelector('input[name="Fornecedor.Endereco"]');
    console.log(cep.length);
    if (cep.length < 8) {

        if (enderecoElement) enderecoElement.value = null;
  
    
        return;
    }
       


    const response = await fetch(`https://viacep.com.br/ws/${cep}/json/`);

    if (!response.ok) {
        return;
    }

    const endereco = await response.json(); 

    if (endereco && !endereco.erro) {
        const enderecoString = `${endereco.logradouro}, ${endereco.bairro}, ${endereco.localidade}, ${endereco.uf}`;
        
        
        if (enderecoElement) {
            enderecoElement.value = enderecoString;
        }
    }

    console.log("Completed");
};