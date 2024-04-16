namespace UserManagerService.Models
{
    //I'm gonna use this so the request body has only name and birthdate
    public class CreatingUser
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
