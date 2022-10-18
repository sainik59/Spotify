using System;
using System.Collections.Generic;

namespace SpotifyApplication.Models
{
    public partial class Song
    {
        public Song()
        {
            UserRatings = new HashSet<UserRating>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CoverImage { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }
    }
}
