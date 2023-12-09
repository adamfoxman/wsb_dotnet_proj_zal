using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace proj_zal.Models
{
    public class Album
    {
        public Guid Id { get; set; }

        [DisplayName("Album Name")]
        [Required(ErrorMessage = "Album name is required")]
        public required string Name { get; set; }

        [DisplayName("Artist")]
        [Required(ErrorMessage = "Artist is required")]
        public required Guid ArtistId { get; set; }

        [DisplayName("Release Date")]
        [Required(ErrorMessage = "Release date is required")]
        public required DateTime ReleaseDate { get; set; }

        [DisplayName("Genre")]
        public string? Genre { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        #region Navigation Properties
        public virtual Artist? Artist { get; set; }

        #endregion
    }
}