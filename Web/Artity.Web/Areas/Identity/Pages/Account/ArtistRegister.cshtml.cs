using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Artity.Common;
using Artity.Data.Models;
using Artity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Artity.Web.Areas.Identity.Pages.Account
{

    public class ArtistRegisterModel : PageModel
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        public UserManager<ApplicationUser> UserManager { get; }

        public ArtistRegisterModel(
            ICategoryService categoryService, 
            IUserService userService,
            UserManager<ApplicationUser> userManager
            )
        {
            this.categoryService = categoryService;
            this.userService = userService;
            this.UserManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

    
        public Category Categories { get; set; }

        public string ReturnUrl { get; set; }

        [Authorize]
        public async Task<IActionResult> OnGet(string returnUrl = null)
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
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

           
            returnUrl = returnUrl ?? this.Url.Content("~/");
            if (this.ModelState.IsValid)
            {
               var name = this.User.Identity.Name;

               var user = this.userService.GetApplicationUserByName(name);

                var artist = new Artist()
                {
                    AboutMe = this.Input.AboutMe,
                    CategoryId = this.categoryService.GetCategoryId(Input.Category),
                    Nikname = Input.Nikname,
                    WorkNumber = Input.WorkNumber,



                };

                this.userService.AddArtistSettings(user, artist);

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