using System;
using System.Collections.Generic;

namespace SpotifyApplication.Models
{
    public partial class User
    {
        public User()
        {
            UserRatings = new HashSet<UserRating>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }
    }
}
