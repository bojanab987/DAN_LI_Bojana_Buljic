using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Model;
using Zadatak_1.Services;

namespace Zadatak_1.Validations
{
    class UsernameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;
            Serivce ser= new Serivce();
            List<tblUser> userList = ser.GetAllUsers();
            var list = userList.Where(x => x.Username == username).ToList();            
            if (list.Count() > 0)
            {
                return new ValidationResult(false, "This username already exists.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
