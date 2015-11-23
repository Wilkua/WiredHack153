using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WiredHack153Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
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

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class AccountDisplayViewModel
    {
        #region accountInfo
        [Display(Name = "First Name")]
        public string AccFirstName { get; set; }

        [Display (Name= "Last Name")]
        public string AccLastName { get; set; }

        public int AccEmployeeId { get; set; } = 0;
        #endregion

        #region employee

        public string AccAddress { get; set; } = "Not Given";
        public string AccCity { get; set; } = "Not Given";
        public string AccState { get; set; } = "Not Given";
        public int AccZip { get; set; } = 0;
        public string AccCounty { get; set; } = "Not Given";
        public string AccImage { get; set; } = "http://i1.wp.com/www.techrepublic.com/bundles/techrepubliccore/images/icons/standard/icon-user-default.png";
        public int AccJobId { get; set; } = 0;
        public string AccBio { get; set; } = "Not Given";
        #endregion

        #region job
        public string JobName { get; set; } = "Not Given";
        public string JobPayRate { get; set; } = "Not Given";
        public DateTime JobStartDate { get; set; } = new DateTime();
        public DateTime JobEndDate { get; set; } = new DateTime();
        public string JobBaseSalary { get; set; } = "Not Given";
        #endregion

        #region employer
        public string EmployerName { get; set; } = "Not Given";
        public string EmployerDescription { get; set; } = "Not Given";
        public string EmployerAddress { get; set; } = "Not Given";
        public string EmployerCity { get; set; } = "Not Given";
        public string EmployerState { get; set; } = "Not Given";
        public int EmployerZip { get; set; } = 0;
        public string EmployerCounty { get; set; } = "Not Given";
        public string EmployerPhone { get; set; } = "Not Given";
        public string EmployerAmtOfEmployees { get; set; } = "Not Given";
        public int EmployerId { get; set; } = 0;
        public string EmployerLogo { get; set; } = "";
        #endregion

        #region clusterInfo
        public int CCID { get; set; } = 0;

        [Display(Name = "Cluster Name")]
        public string ClustClusterName { get; set; } = "Unknown Cluster";

        public string ClustClusterDescription { get; set; } = "Unknown Description";
        #endregion

        #region School

        public int UniID { get; set; } = 0;
        public string UniName { get; set; } = "Not Given";
        public string UniAddress { get; set; } = "Not Given";
        public string UniCity { get; set; } = "Not Given";
        public string UniState { get; set; } = "Not Given";
        public string UniZip { get; set; } = "Not Given";
        public string UniCounty { get; set; } = "Not Given";
        public string UniDescription { get; set; } = "Not Given";
        public string UniLogo { get; set; } = "";
        #endregion

        #region Major

        public int MajorID { get; set; } = 0;
        public string MajorDescription { get; set; } = "Not Given";
        #endregion


    }

    
}
