using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _0_FrameWork.Application
{
    public class FileExtensionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _validExtension;

        public FileExtensionLimitationAttribute(string[] validExtension)
        {
            _validExtension = validExtension;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            var fileExtension = Path.GetExtension(file.FileName);
            if (!_validExtension.Contains(fileExtension))
                return false;
            return true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            // context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-fileExtensionLimit", ErrorMessage);

        }
    }
}
