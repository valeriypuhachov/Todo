using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;

namespace Todo.WebUI.Models {

    public class EditViewModel {

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required(ErrorMessageResourceName = "UserNameIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "SurnameIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }

        [Display(Name = "Patronomic", ResourceType = typeof(Resources.Resource))]
        public string Patronomic { get; set; }

        [Required(ErrorMessageResourceName = "AboutMyselfIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UserComment", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [RegularExpression(@"\([0-9]{3}\)\s[0-9]{3}-[0-9]{2}-[0-9]{2}",
            ErrorMessageResourceName = "PhonePattern",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "PhoneNumberIsRequired",
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }
    }

    public class DisplayProfileViewModel {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }

        [Display(Name = "Patronomic", ResourceType = typeof(Resources.Resource))]
        public string Patronomic { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        public string Description { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resource))]
        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }
    }
}