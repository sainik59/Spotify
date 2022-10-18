using System;
using System.Collections.Generic;

namespace SpotifyApplication.Models
{
    public partial class UserRating
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SongId { get; set; }
        public int? Rating { get; set; }

        public virtual Song? Song { get; set; }
        public virtual User? User { get; set; }
    }
}
