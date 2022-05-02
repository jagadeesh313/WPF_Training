using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoApplication.Validation.Rules
{
	internal class NotEmptyValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if(value is string str)
			{
				if(!string.IsNullOrEmpty(str))
				{
					return ValidationResult.ValidResult;
				}else
				{
					return new ValidationResult(false, "This field cannot be empty or white space and Value should be string");
				}
			}
			else
			{
				return new ValidationResult(false, "Value should be string");
			}
		}
	}
}
