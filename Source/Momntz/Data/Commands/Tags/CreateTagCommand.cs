﻿using System;

namespace Momntz.Data.Commands.Tags
{
    public class CreateTagCommand
    {
        public string Name { get; set; }
        public decimal Left { get; set; }
        public decimal Top { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Username { get; set; }
        public int MomentoId { get; set; }
        public Guid InternalId { get; set; }

        public CreateTagCommand(string name, decimal left, decimal top, decimal width, decimal height, string username, int momentoId)
        {
            Name = name;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Username = username;
            MomentoId = momentoId;
            InternalId = Guid.NewGuid();
        }
    }
}
