namespace Momntz.Model
{
    public class TagMomento
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public virtual Tag Tag { get; set; }

        /// <summary>
        /// Gets or sets the momento.
        /// </summary>
        /// <value>The momento.</value>
        public virtual Momento Momento { get; set; }
    }
}
