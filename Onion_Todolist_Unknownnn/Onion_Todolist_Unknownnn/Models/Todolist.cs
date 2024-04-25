namespace Onion_Todolist_Unknownnn.Models
{
    public class Todolist
    {
        public int Id { get; set; }
        public required string Task { get; set; }
        public required string Date { get; set; }
        public required string Action { get; set; }
    }
}
