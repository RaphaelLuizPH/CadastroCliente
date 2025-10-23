using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CadastroCliente.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]

    public class ShouldHaveLastName : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
           
            if(value is string name)
            {
                var parts = name.Trim().Split(' ');
                if (parts.Length < 2)
                {
                    return false;
                }
                return true;
            }


            return false;
           
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }

    }
}
