// ReSharper disable VirtualMemberCallInConstructor
namespace Artity.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Artity.Data.Common.Models;
    using Artity.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Orders = new List<Order>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public UserType UserType { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public string PofilePictureId { get; set; }

        public virtual Picture PofilePicture { get; set; }

        public virtual IList<Order> Orders { get; set; }

        public bool FirstLogin { get; set; } = false;

    }
}
