﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo.WebUI.Models {
    public class ExternalLoginConfirmationViewModel {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// The model is using for user loging in.
    /// </summary>
    public class LoginViewModel {
        [Required(ErrorMessageResourceName = "EmailIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// The model is using for user registration.
    /// </summary>
    public class RegisterViewModel {
        [Required(ErrorMessageResourceName = "UserNameIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "SurnameIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }

        [Display(Name = "Patronomic", ResourceType = typeof(Resources.Resource))]
        public string Patronomic { get; set; }

        [Required(ErrorMessageResourceName = "EmailIsRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}",
            ErrorMessageResourceName = "PhonePattern",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "PhoneNumberIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = "AboutMyselfIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UserComment", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Required(ErrorMessageResourceName = "PasswordIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage",
            ErrorMessageResourceType = typeof(Resources.Resource),
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "RepeatPassword", ResourceType = typeof(Resources.Resource))]
        [Compare("Password",
            ErrorMessageResourceName = "PasswordDoNotMatch",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage",
            ErrorMessageResourceType = typeof(Resources.Resource),
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessageResourceName = "PasswordDoNotMatch",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
