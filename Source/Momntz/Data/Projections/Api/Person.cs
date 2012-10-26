using Momntz.Model;

namespace Momntz.Data.Projections.Api
{
    public class Person
    {
        public virtual int Id { get; set; } 

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the momento id.
        /// </summary>
        /// <value>The momento id.</value>
        public virtual Momento Momento { get; set; }
    }
}