using System;
using System.Collections.Generic;

namespace Momntz.Model
{
    public class Momento
    {

        public virtual List<MomentoMedia> Media { get; set; }

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

        public virtual int? Day { get; set; }

        public virtual int? Month { get; set; }

        public virtual int? Year { get; set; }

        /// <summary> Gets or sets the story. </summary>
        /// <value> The story. </value>
        public virtual string Story { get; set; }

        public virtual Guid InternalId { get; set; }

        public virtual string Title { get; set; }

        public virtual string Location { get; set; }

        public virtual decimal? Latitude { get; set; }

        public virtual decimal? Longitude { get; set; }
    }
}
