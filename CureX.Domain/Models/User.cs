namespace CureX.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHashed { get; set; } = "";
        public string Role { get; set; } = ""; 
    }
}