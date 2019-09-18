namespace Artity.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Artity.Common;
    using Artity.Data.Models;
    using Artity.Data.Models.Enums;
    using Artity.Services;
    using Artity.Services.Messaging;
    using Artity.Web.InputModels.Picture;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    using Services.Data.File;

    [AllowAnonymous]
#pragma warning disable SA1649 // File name should match first type name
    public class RegisterModel : PageModel
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly ISendGrid emailSender;
        private readonly IPicureService picureService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IdentityRole roles;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            ISendGrid emailSender,
            IPicureService picureService,
            ICloudinaryService cloudinaryService
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.picureService = picureService;
            this.cloudinaryService = cloudinaryService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {

            if (this.User.Identity.IsAuthenticated)
            {
                return this.Redirect(GlobalConstants.HomeUrl);
            }

            this.ReturnUrl = returnUrl;
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.Username,
                    Email = this.Input.Email,
                    PhoneNumber = this.Input.PhoneNumber,
                    UserType = Enum.Parse<UserType>(this.Input.AccountType),
                };

                if (this.Input.ProfilePicture != null)
                {
                    var pictureName = this.Input.Username + GlobalConstants.ProfilePicture;
                    string pictureLink = await this.cloudinaryService.UploadPictureAsync(this.Input.ProfilePicture, pictureName);
                    var picture = new PictureInputModel() { Link = pictureLink, Title = user.UserName, Description = user.UserName };
                    var pictureToDb = await this.picureService.AddPictureToDb(picture, user);
                    bool isGenerate = await this.picureService.GenerateProfilePicture(picture, user);
                }
                
                if (user.UserType == UserType.User)
                {
                    user.FirstLogin = true;
                }

                var isRoot = !this.userManager.Users.Any();

                var result = await this.userManager.CreateAsync(user, this.Input.Password);

                if (result.Succeeded && user.UserType == UserType.User)
                {
                    if (isRoot)
                    {
                        await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                    }
                    else
                    {
                        await this.userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);
                    }


                    this.logger.LogInformation("User created a new account with password.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: this.Request.Scheme);

                    await this.emailSender.SendEmailAsync(
                        this.Input.Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return this.Redirect(GlobalConstants.HomeUrl);
                }

                if (user.UserType == UserType.Artist && result.Succeeded)
                {
                    if (user.UserType == UserType.Artist)
                    {
                        await this.userManager.AddToRoleAsync(user, GlobalConstants.ArtistRoleName);
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.RedirectToPage("./ArtistRegister");
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return this.Page();
        }
    }

    public class InputModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        public IFormFile ProfilePicture { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }


        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Incorrect phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        public bool License { get; set; }

        [Required]
        public bool License2 { get; set; }

    }
}

