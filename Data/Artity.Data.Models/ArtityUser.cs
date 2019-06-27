using Artity.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class ArtityUser : IdentityUser
    {
        public ArtityUser()
        {
            this.Orders = new List<Order>();
        } 
        
        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        public string ArtistId { get; set; }

        public Artist Artist { get; set; }

        public string PofilePictureId { get; set; }

        public Picture PofilePicture { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
