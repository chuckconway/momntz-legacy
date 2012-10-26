using System;
using System.Collections.Generic;

namespace Momntz.Data.Projections.Api
{
    public class MomentoDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoDetail" /> class.
        /// </summary>
        public MomentoDetail()
        {
            Title = string.Empty;
            Story = string.Empty;
            Day = string.Empty;
            Month = string.Empty;
            Year = string.Empty;
            Location = string.Empty;
            Username = string.Empty;
            AddedUsername = string.Empty;
            DisplayName = string.Empty;
            People = new List<Person>();
            Albums = new List<Album>();

        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the story.
        /// </summary>
        /// <value>The story.</value>
        public virtual string Story { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public virtual string Day { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public virtual string Month { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public virtual string Year { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public virtual string Location { get; set; }

        /// <summary>
        /// Gets or sets the added.
        /// </summary>
        /// <value>The added.</value>
        public virtual DateTime? Added { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the added username.
        /// </summary>
        /// <value>The added username.</value>
        public virtual string AddedUsername { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        /// <value>The people.</value>
        public virtual List<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        /// <value>The albums.</value>
        public virtual List<Album> Albums { get; set; }
    }

    public class Album
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
        /// Gets or sets the tag id.
        /// </summary>
        /// <value>The tag id.</value>
        public virtual int TagId { get; set; }

        /// <summary>
        /// Gets or sets the momento id.
        /// </summary>
        /// <value>The momento id.</value>
        public virtual int MomentoId { get; set; }

        /// <summary>
        /// Gets or sets the story.
        /// </summary>
        /// <value>The story.</value>
        public virtual string Story { get; set; }
    }
}
