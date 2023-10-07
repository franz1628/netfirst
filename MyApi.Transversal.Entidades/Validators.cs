using System.ComponentModel.DataAnnotations;

namespace MyApi.Transversal.Entidades
{
    public class IsTrue : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value == true;
        }
    }
}
