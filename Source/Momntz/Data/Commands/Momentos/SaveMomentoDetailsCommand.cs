using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Momntz.Data.Commands.Momentos
{
    public class SaveMomentoDetailsCommand : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Albums { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }

        public SaveMomentoDetailsCommand(int id, string title, string story, int? day, int? month, int? year, string albums, string location, string username)
        {
            Id = id;
            Title = title;
            Story = story;
            Day = day;
            Month = month;
            Year = year;
            Albums = albums;
            Location = location;
            Username = username;
        }
    }
}
