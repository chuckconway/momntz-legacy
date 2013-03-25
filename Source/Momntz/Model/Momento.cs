using System;
using System.Collections.Generic;

namespace Momntz.Model
{
    public class Momento
    {
        /// <summary>
        /// Gets or sets the media.
        /// </summary>
        /// <value>The media.</value>
        public virtual IList<MomentoMedia> Media { get; set; }

        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public virtual int Id { get; set; }

        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public virtual string Username { get; set; }

        /// <summary> Gets or sets the amount to uploaded by. </summary>
        /// <value> The amount to uploaded by. </value>
        public virtual string UploadedBy { get; set; }

        /// <summary> Gets or sets the visibility. </summary>
        /// <value> The visibility. </value>
        public virtual string Visibility { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public virtual int? Day { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public virtual int? Month { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public virtual int? Year { get; set; }

        /// <summary> Gets or sets the story. </summary>
        /// <value> The story. </value>
        public virtual string Story { get; set; }

        /// <summary>
        /// Gets or sets the internal id.
        /// </summary>
        /// <value>The internal id.</value>
        public virtual Guid InternalId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public virtual string Location { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public virtual decimal? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public virtual decimal? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public virtual DateTime? CreateDate { get; set; }
    }
}
