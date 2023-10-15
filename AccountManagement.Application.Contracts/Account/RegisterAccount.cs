using _0_FrameWork.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        public RegisterAccount()
        {
            Roles = new List<RoleViewModel>();
        }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Fullname { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; } = string.Empty;

        public long RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
