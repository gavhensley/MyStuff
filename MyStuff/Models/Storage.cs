namespace MyStuff.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlacementNotes { get; set; }
        public string Image { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
