using System.ComponentModel.DataAnnotations;

namespace CivilRegistrationMobile.Models.ViewModels.ValidationAttributes
{
    public class ChildBirthdayAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value == null) return false;

            DateTime birthday = (DateTime)value;
            DateTime minDate = DateTime.Now.AddYears(-1);

            int result = DateTime.Compare(birthday, minDate);

            if(result < 0 ) return false;

            return true;
        }
    }
}
