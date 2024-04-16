namespace UserManagerService.Models
{
    //This class is used within the endpoint that changes user's active
    public class UpdateActive
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
