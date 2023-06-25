using System.ComponentModel.DataAnnotations;

namespace EFproject.Validation
{
    public class NameAttribute : ValidationAttribute
    {
        private string[] invalidName = new[] { "Abdul", "Sal", "Abdulna" };
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            return !invalidName.Contains(value.ToString());
        }
    }
    
}
