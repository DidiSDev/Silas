namespace Silas.Models.Usuarios
{
    public class UserValidatorResponse
    {

        public int status {  get; set; }
        public int id { get; set; }
        public int user_status {  get; set; }
        public string category { get; set; }

        public UserValidatorResponse(int status, int id, int user_status, string category)
        {
            this.status = status;
            this.id = id;
            this.user_status = user_status;
            this.category = category;
        }
    }

    
}
