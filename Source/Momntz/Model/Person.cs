namespace Momntz.Model
{
   public class Person
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
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
       /// Gets or sets the width.
       /// </summary>
       /// <value>The width.</value>
       public virtual decimal Width { get; set; }

       /// <summary>
       /// Gets or sets the height.
       /// </summary>
       /// <value>The height.</value>
       public virtual decimal Height { get; set; }

       /// <summary>
       /// Gets or sets the X axis.
       /// </summary>
       /// <value>The X axis.</value>
       public virtual decimal XAxis { get; set; }

       /// <summary>
       /// Gets or sets the Y axis.
       /// </summary>
       /// <value>The Y axis.</value>
       public virtual decimal YAxis { get; set; }

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
