using System;
using System.Collections.Generic;
using Hypersonic.Attributes;
using Momntz.Model;

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
            People = new List<People>();
            Albums = new TagCollection();

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
        public List<People> People { get; set; }

        [Ignore]
        public TagCollection Albums { get; set; }
    }

    public class People
    {
        public String DisplayName { get; set; }

        public string Username { get; set; }
    }
}
