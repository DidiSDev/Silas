namespace Silas.Models.Usuarios
{
    public class UserResponse
    {
        public int status {  get; set; }
        public List<User> users { get; set; }

        public string message { get; set; }
        
    }
}
