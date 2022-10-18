using System;
using System.Collections.Generic;

namespace SpotifyApplication.Models
{
    public partial class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Bio { get; set; }
    }
}
