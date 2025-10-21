namespace CadastroCliente.Pages.Shared
{
    public static class ImageHelper
    {
        public static string? GetImage(byte[]? data)
        {
            if (data == null || data.Length == 0)
                return null;


            string mime = "application/octet-stream";

            if (data.Length >= 4 &&
                data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47)
            {
                mime = "image/png";
            }
            else if (data.Length >= 3 &&
                data[0] == 0xFF && data[1] == 0xD8 && data[2] == 0xFF)
            {
                mime = "image/jpeg";
            }
            else if (data.Length >= 6 &&
                data[0] == 0x47 && data[1] == 0x49 && data[2] == 0x46)
            {
                mime = "image/gif";
            }

            return $"data:{mime};base64,{Convert.ToBase64String(data)}";
        }

    }
}
