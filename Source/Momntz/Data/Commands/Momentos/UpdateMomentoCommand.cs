namespace Momntz.Data.Commands.Momentos
{
    public class UpdateMomentoCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Albums { get; set; }

        public UpdateMomentoCommand(int id, string title, string story, string day, string month, string year, string albums)
        {
            Id = id;
            Title = title;
            Story = story;
            Day = day;
            Month = month;
            Year = year;
            Albums = albums;
        }
    }
}
