namespace Save_Changes_interceptors.Data.Entities
{
    public class Post : ISoftDelete
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string author { get; set; } = string.Empty;

        public int BlogId { get; set; }

        public Blog Blog { get; set; } 

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}