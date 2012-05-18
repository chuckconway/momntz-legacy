﻿namespace Momntz.Model
{
    public class Momento
    {
        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }

        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary> Gets or sets the amount to uploaded by. </summary>
        /// <value> The amount to uploaded by. </value>
        public string UploadedBy { get; set; }

        /// <summary> Gets or sets the visibility. </summary>
        /// <value> The visibility. </value>
        public string Visibility { get; set; }

        /// <summary> Gets or sets the story. </summary>
        /// <value> The story. </value>
        public string Story { get; set; }
    }
}