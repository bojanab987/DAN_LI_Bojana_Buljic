using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Model;
using Zadatak_1.Services;

namespace Zadatak_1.Validations
{
    class BankAccountValidation : ValidationRule
    {
        /// <summary>
        /// Method for validating bank account number input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string account = value as string;
            if (account.Length != 18 || !account.All(Char.IsDigit))
            {
                return new ValidationResult(false, "Bank account must contain 18 digits.");
            }
            else
            {
                Serivce ser = new Serivce();
                List<tblDoctor> doctors = ser.GetAllDoctors();
                var list = doctors.Where(x => x.BankAccountNo == account).ToList();                
                if (list.Count() > 0)
                {
                    return new ValidationResult(false, "This bank account already exists.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
    }
}
