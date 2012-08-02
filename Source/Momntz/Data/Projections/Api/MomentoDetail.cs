using System;
using System.Collections.Generic;
using Hypersonic.Attributes;

namespace Momntz.Data.Projections.Api
{
    public class MomentoDetail
    {
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

        public string Title { get; set; }

        public string Story { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string Location { get; set; }

        public DateTime? Added { get; set; }

        public string Username { get; set; }

        public string AddedUsername { get; set; }

        public string DisplayName { get; set; }
        
        [Ignore]
        public List<Person> People { get; set; }

        [Ignore]
        public List<Album> Albums { get; set; }
    }

    public class Album
    {
        public string Name { get; set; }

        public int TagId { get; set; }

        public int MomentoId { get; set; }

        public string Story { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }

        public string Username { get; set; }
    }
}
