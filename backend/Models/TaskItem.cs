namespace backend.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public bool IsCompleted { get; set; } 

        // Foreign Key
        public int UserId { get; set; }
        public User? User { get; set; } 
    }
}
