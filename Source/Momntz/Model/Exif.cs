namespace Momntz.Model
{
    public class Exif
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the momento id.
        /// </summary>
        /// <value>The momento id.</value>
        public virtual Momento Momento { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public virtual string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual string Value { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public virtual int Type { get; set; }
    }
}
