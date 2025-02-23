﻿namespace LibraryManager.Models
{
    public class Author
    {
        public string Name { get; set; }

        public Author(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
