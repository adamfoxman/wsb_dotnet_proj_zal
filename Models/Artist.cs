namespace proj_zal.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Genre { get; set; }

        #region Navigation Properties
        public ICollection<Album> Albums { get; set; }

        #endregion
    }
}