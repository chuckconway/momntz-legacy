namespace Momntz.Data.Projections.Albums
{
    public class AlbumResult : IGroupItem, IProjection
    {
        public string Username { get; set; }

        public string Name { get; set; }
        
        public string Url { get; set; }
    }
}
