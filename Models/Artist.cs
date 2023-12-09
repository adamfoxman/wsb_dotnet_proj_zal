using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace proj_zal.Models
{
    public class Artist
    {
        public Guid ArtistId { get; set; }

        [DisplayName("Artist Name")]
        [Required(ErrorMessage = "Artist name is required")]
        public required string Name { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Genre")]
        public required string Genre { get; set; }

        #region Navigation Properties
        public ICollection<Album>? Albums { get; set; }

        #endregion
    }
}