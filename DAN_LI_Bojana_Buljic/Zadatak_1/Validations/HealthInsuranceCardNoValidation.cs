using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Model;
using Zadatak_1.Services;

namespace Zadatak_1.Validations
{
    /// <summary>
    /// Validation class for Health insurance cardno.
    /// </summary>
    class HealthInsuranceCardNoValidation : ValidationRule
    {
        /// <summary>
        /// Method for health insurance card number input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length != 11 || !number.All(Char.IsDigit))
            {
                return new ValidationResult(false, "Number must contain 10 digits.");
            }
            else
            {
                Serivce ser = new Serivce();
                List<tblPatient> patients = ser.GetAllPatients();
                var list = patients.Where(x => x.HealthInsuranceCardNo == number).ToList();                
                if (list.Count() > 0)
                {
                    return new ValidationResult(false, "This account number already exists.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
    }
}
