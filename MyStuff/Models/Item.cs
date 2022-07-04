﻿namespace MyStuff.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlacementNotes { get; set; }
        public string Image { get; set; }
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
    }
}