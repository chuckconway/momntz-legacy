namespace Momntz.Model
{
    public class Tag
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the story.
        /// </summary>
        /// <value>
        /// The story.
        /// </value>
        public string Story { get; set; }

        /// <summary>
        /// Gets or sets the kind of tag.
        /// </summary>
        /// <value>
        /// The kind of tag.
        /// </value>
        public KindOfTag KindOfTag { get; set; }

    }

    public enum KindOfTag
    {
        User,
        Tag,
        Location,
        Album
    }
}
