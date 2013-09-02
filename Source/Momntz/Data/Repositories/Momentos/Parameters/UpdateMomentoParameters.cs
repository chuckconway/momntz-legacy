namespace Momntz.Data.Repositories.Momentos.Parameters
{
    public class UpdateMomentoParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateMomentoParameters" /> class.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <param name="title">The title.</param>
        /// <param name="story">The story.</param>
        /// <param name="day">The day.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="albums">The albums.</param>
        public UpdateMomentoParameters(int id, string title, string story, string day, string month, string year,
            string albums)
        {
            Id = id;
            Title = title;
            Story = story;
            Day = day;
            Month = month;
            Year = year;
            Albums = albums;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Albums { get; set; }
    }
}