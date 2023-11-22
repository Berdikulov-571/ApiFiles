namespace WorkingApiWithFiles.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}