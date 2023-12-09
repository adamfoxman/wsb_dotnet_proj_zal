using System.ComponentModel;

namespace proj_zal.ViewModels
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Album Name")]
        public string Name { get; set; }

        [DisplayName("Artist")]
        public Guid ArtistId { get; set; }

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Genre")]
        public string? Genre { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}