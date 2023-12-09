namespace proj_zal.Models
{
    public class Album
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int ArtistId { get; set; }
        public required DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }

        public string? Description { get; set; }

        #region Navigation Properties
        public Artist Artist { get; set; }

        #endregion
    }
}