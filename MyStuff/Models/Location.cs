﻿namespace MyStuff.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Storage> Storages { get; set; }
    }
}
