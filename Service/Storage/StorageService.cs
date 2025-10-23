using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Elfie.Serialization;
using System.ComponentModel;

namespace CadastroCliente.Service.Storage
{
    public class StorageService
    {

        private readonly BlobServiceClient _client;
        private readonly string _accountKey;
        private readonly BlobContainerClient _container;
        public StorageService(string connection, string accountKey)
        {

            _client = new(connectionString: connection);
            _container = _client.GetBlobContainerClient("fornecedores");
            _container.CreateIfNotExistsAsync();
            _accountKey = accountKey;


        }


        public async Task<string> GenerateSasToken(string file)
        {


            try
            {
                var blob = _container.GetBlobClient(file);

                BlobSasBuilder blobSas = new()
                {
                    BlobContainerName = _container.Name,
                    BlobName = blob.Name,
                    Resource = "b",
                    ExpiresOn = DateTimeOffset.UtcNow.AddHours(1),


                };

                blobSas.SetPermissions(BlobAccountSasPermissions.Read);


                var query = blob.GenerateSasUri(blobSas);

                return query.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task UploadBlob(string name, MemoryStream content)
        {

            try
            {
                var binary = new BinaryData(content.ToArray());

                await _container.UploadBlobAsync(name, binary);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task ReplaceBlob(string newFileName, MemoryStream content)
        {
            try
            {
                var old = _container.GetBlobClient(newFileName);
                BinaryData binary = new(content.ToArray());

                if (old.Exists())
                {
                    await old.UploadAsync(binary, overwrite: true);
                    return;
                }


                await _container.UploadBlobAsync(newFileName, binary);
            }
            catch (Exception)
            {

                throw;
            }


        }


    }



}

