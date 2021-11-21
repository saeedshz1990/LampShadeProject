using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text;
using System.Text.RegularExpressions;

namespace _0_Framework.Application
{
    public static class MaxFileSizeAttribute : ValidationAttribute , IClientModelValidator
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public void AddValidation(ClientModelValidationContext context)
        {   
            context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-maxFileSiZe",ErrorMessage);

        }
        public override bool IsValid(object value)
        {
            var file=value as IFormFile;
            if(file==null) return true ;
            if(file.Length > _maxFileSize)
                return false;
            return true;  



        }
    }






}