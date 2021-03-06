namespace Artity.Web.Areas.Identity.Pages.Account
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Artity.Common;
    using Artity.Data.Models;
    using Artity.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Artity.Web.InputModels.Picture;

    using Services.Data.Category;
    using Services.Data.File;
    using Services.Data.User;

    public class ArtistRegisterModel : PageModel
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IHostingEnvironment environment;
        private readonly IPicureService picureService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICloudinaryService cloudinaryService;

        public UserManager<ApplicationUser> UserManager { get; }

        public ArtistRegisterModel(
            ICategoryService categoryService,
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment,
            IPicureService picureService,
            SignInManager<ApplicationUser> signInManager,
            ICloudinaryService cloudinaryService
            )
        {
            this.categoryService = categoryService;
            this.userService = userService;
            this.UserManager = userManager;
            this.environment = hostingEnvironment;
            this.picureService = picureService;
            this.signInManager = signInManager;
            this.cloudinaryService = cloudinaryService;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public Category Categories { get; set; }

        public string ReturnUrl { get; set; }

        [Authorize]
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            var user = await this.UserManager.GetUserAsync(this.User);
            if (user.UserType.ToString() == GlobalConstants.ArtistRoleName && user.FirstLogin == false)
            {
                await this.userService.SetFirstLogin(user);
                this.Categories = new Category(this.categoryService);
                return this.Page();
            }
            else
            {
                returnUrl = "/";
                return this.Redirect(returnUrl);
            }

        }

        [Authorize]
        public async Task<IActionResult> OnPostRegisterAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? this.Url.Content("~/");
            if (this.ModelState.IsValid)
            {
                var name = this.User.Identity.Name;

                var user = this.userService.GetApplicationUserByName(name);

                var social = new Social() { WebSite = string.Empty, Facebook = string.Empty, Youtube = string.Empty };

                var artist = new Artist()
                {
                    AboutMe = this.Input.AboutMe,
                    CategoryId = await this.categoryService.GetCategoryIdAsync(this.Input.Category),
                    Nikname = this.Input.Nikname,
                    WorkNumber = this.Input.WorkNumber,
                    Social = social,
                    SocialId = social.Id,
                };

                this.userService.AddArtistSettings(user, artist);

                if (this.Input.Picture != null)
                {
                    var pictureName = this.Input.Nikname + GlobalConstants.ProfilePicture;
                    string pictureLink = await this.cloudinaryService.UploadPictureAsync(this.Input.Picture, pictureName);
                    var picture = new PictureInputModel() { Link = pictureLink, Title = user.UserName, Description = this.Input.AboutMe };
                    var pictureToDb = await this.picureService.AddPictureToDb(picture, user);
                    bool isGenerate = await this.picureService.SetArtistPicture(picture, user);
                }
                return this.Redirect(GlobalConstants.HomeUrl);

            }

            return this.Forbid();
            //TODO: Iplement Logic
            // If we got this far, something failed, redisplay form        
        }

        public class InputModel
        {

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            [Display(Name = "Nikname")]
            public string Nikname { get; set; }

            [Required]
            [Display(Name = "Category")]
            public string Category { get; set; }

            [Required]
            [StringLength(2500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 30)]
            [Display(Name = "About Me")]
            public string AboutMe { get; set; }

            [Required]
            public IFormFile Picture { get; set; }

            [Required]
            [Display(Name = "WorkNumber")]
            [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Incorrect phone number.")]
            public string WorkNumber { get; set; }

            [Required]
            public bool License { get; set; }

            [Required]
            public bool License2 { get; set; }

        }

    }

    public class Category
    {
        private ICategoryService service;

        public Category(ICategoryService service)
        {
            this.service = service;
        }

        public List<string> Categories => this.service.GetAllCategoriesNamesAsync().GetAwaiter().GetResult().ToList();

    }
}