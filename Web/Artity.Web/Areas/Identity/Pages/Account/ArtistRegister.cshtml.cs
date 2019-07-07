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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Net.Http.Headers;

    public class ArtistRegisterModel : PageModel
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IHostingEnvironment environment;
        private readonly IFileService fileService;
        private readonly IPicureService picureService;

        public UserManager<ApplicationUser> UserManager { get; }

        public ArtistRegisterModel(
            ICategoryService categoryService, 
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment,
            IFileService fileService,
            IPicureService picureService
            )
        {
            this.categoryService = categoryService;
            this.userService = userService;
            this.UserManager = userManager;
            this.environment = hostingEnvironment;
            this.fileService = fileService;
            this.picureService = picureService;
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
                //TODO: Refactor Category new
                await this.userService.SetFirstLogin(user);
                this.Categories = new Category(this.categoryService);                   
                return this.Page();
            }
            else
            {
                returnUrl = "/";
                return this.LocalRedirect(returnUrl);
            }
           
        }

        [Authorize]
        public async Task<string> PictureCreate()
        {

           return  await this.fileService.UploadProfilePicture(this.HttpContext);
           
        }



        [Authorize]
        public async Task<IActionResult> OnPostRegisterAsync(string returnUrl = null)
        {

           
            returnUrl = returnUrl ?? this.Url.Content("~/");
            if (this.ModelState.IsValid)
            {
               var name = this.User.Identity.Name;

               var user = this.userService.GetApplicationUserByName(name);

                var artist = new Artist()
                {
                    AboutMe = this.Input.AboutMe,
                    CategoryId = this.categoryService.GetCategoryId(this.Input.Category),
                    Nikname = this.Input.Nikname,
                    WorkNumber = this.Input.WorkNumber,

                };

                this.userService.AddArtistSettings(user, artist);
                
                var picture = await this.PictureCreate();

                var result = await this.picureService.GenerateProfilePicture(picture, GlobalConstants.ProfilePicture,user.Id.ToString(), user);
          
                return this.LocalRedirect(returnUrl);

            }     
                return this.Forbid();
            //TODO: Iplement Logic
            // If we got this far, something failed, redisplay form        
        }

        public class InputModel
        {

            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
            [Display(Name = "Nikname")]
            public string Nikname { get; set; }

            [Required]         
            [Display(Name = "Category")]
            public string Category { get; set; }



            [Required]
            [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 30)]
            [Display(Name = "About Me")]
            public string AboutMe { get; set; }


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

        public List<string> Categories => this.service.GetAllCategories().ToList();

    }
}