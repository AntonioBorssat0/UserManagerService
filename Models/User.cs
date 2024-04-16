namespace UserManagerService.Models
{
    //I'm gonna use this class for creating the database (and for having a class with all user properties)
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; } //Gonna set it True within the endpoint
    }

}
