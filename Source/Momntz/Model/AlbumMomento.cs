namespace Momntz.Model
{
   public class AlbumMomento
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
       public virtual int Id { get; set; }

       /// <summary>
       /// Gets or sets the album.
       /// </summary>
       /// <value>The album.</value>
       public virtual Album Album { get; set; }

       /// <summary>
       /// Gets or sets the momento.
       /// </summary>
       /// <value>The momento.</value>
       public virtual Momento Momento { get; set; }
    }
}
