using System;
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
        /// Gets or sets the story.
        /// </summary>
        /// <value>The story.</value>
        public virtual string Story { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public virtual int Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public virtual int Width { get; set; }

        /// <summary>
        /// Gets or sets the X axis.
        /// </summary>
        /// <value>The X axis.</value>
        public virtual int XAxis { get; set; }

        /// <summary>
        /// Gets or sets the Y axis.
        /// </summary>
        /// <value>The Y axis.</value>
        public virtual int YAxis { get; set; }

        /// <summary>
        /// Gets or sets the tag person id.
        /// </summary>
        /// <value>The tag person id.</value>
        public virtual int TagPersonId { get; set; }

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