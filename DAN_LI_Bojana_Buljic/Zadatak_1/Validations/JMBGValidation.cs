﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Model;
using Zadatak_1.Services;

namespace Zadatak_1.Validations
{
    /// <summary>
    /// Validation class for jmbg no validation
    /// </summary>
    class JMBGValidation : ValidationRule
    {
        /// <summary>
        /// Method for validating jmbg input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string jmbg = value as string;
            if (jmbg.Length != 13 || !jmbg.All(Char.IsDigit))
            {
                return new ValidationResult(false, "JMBG must have 13 digits.");
            }
            else
            {
                try
                {
                    string day = jmbg.Substring(0, 2);
                    string month = jmbg.Substring(2, 2);
                    string year = jmbg.Substring(4, 3);
                    string validyear = "";
                    if (year[0] == '0')
                    {
                        validyear = "2" + year;
                    }
                    else
                    {
                        validyear = "1" + year;
                    }
                    bool conversionYear = Int32.TryParse(year, out int y);
                    bool conversionMonth = Int32.TryParse(month, out int m);
                    bool conversionDay = Int32.TryParse(day, out int d);
                    //checks if passed jmbg contains a valid date
                    var expectedDatetime = new DateTime(y, m, d);
                    //gets a birth date from passed jmbg
                    DateTime dateOfBirth = DateTime.Parse(validyear + "-" + month + "-" + day);
                    Serivce ser = new Serivce();
                    List<tblUser> userList = ser.GetAllUsers();
                    var list = userList.Where(x => x.JMBG == jmbg).ToList();
                    //if exists user with forwarded username, return false
                    if (list.Count() > 0)
                    {
                        return new ValidationResult(false, "This JMBG already exists, it must be unique value.");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                catch (Exception)
                {
                    return new ValidationResult(false, "JMBG contains invalid date.");
                }
            }
        }
    }
}
