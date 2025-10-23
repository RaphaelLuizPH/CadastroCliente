using CadastroCliente.Model.Fornecedor;
using CadastroCliente.Service.Storage;
using System.Globalization;

namespace CadastroCliente.Pages.Shared
{
    public class ImageHelper
    {
        private readonly StorageService _service;

        public ImageHelper(StorageService storage)
        {
            _service = storage;
        }


        public async Task<string?> GetImage(string filename)
        {


            try
            {
                var sas = await _service.GenerateSasToken(filename);

                return sas;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task UploadImage(IFormFile file, string fileName)
        {


            try
            {
                using MemoryStream ms = new MemoryStream();

                file.CopyTo(ms);

                await _service.UploadBlob(fileName, ms);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task ReplaceImage(IFormFile file, string newFileName)
        {

            try
            {
                using MemoryStream ms = new MemoryStream();

                file.CopyTo(ms);

                await _service.ReplaceBlob(newFileName, ms);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
