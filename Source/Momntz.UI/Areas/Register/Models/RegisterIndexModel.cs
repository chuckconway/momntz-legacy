namespace Momntz.UI.Areas.Register.Models
{
    public class RegisterIndexModel
    {
        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }

        /// <summary> Gets or sets the name of the first. </summary>
        /// <value> The name of the first. </value>
        public string FirstName { get; set; }

        /// <summary> Gets or sets the name of the last. </summary>
        /// <value> The name of the last. </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; set; }
        
        /// <summary> Gets or sets the password. </summary>
        /// <value> The password. </value>
        public string Password { get; set; }
    }
}
