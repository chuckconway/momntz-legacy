namespace Momntz.Data.Schema
{
    public class MomentoUser
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the momento id.
        /// </summary>
        /// <value>The momento id.</value>
        public virtual Momento Momento { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }
    }
}
