namespace ApiAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }// In production environment it must be encrypted.
        public string Role { get; set; }//
        
    }
}