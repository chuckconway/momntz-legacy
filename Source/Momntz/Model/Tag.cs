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
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the story.
        /// </summary>
        /// <value>
        /// The story.
        /// </value>
        public virtual string Story { get; set; }

        /// <summary>
        /// Gets or sets the kind of tag.
        /// </summary>
        /// <value>
        /// The kind of tag.
        /// </value>
        public virtual int Kind { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

    }

    public enum KindOfTag
    {
        Person = 0,
        Tag = 1,
        Location = 2,
        Album = 3
    }
}
