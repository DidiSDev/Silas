namespace Silas.Models.Usuarios
{
    public class UserValidatorResponse
    {

        public int status {  get; set; }
        public int id { get; set; }
        public int user_status {  get; set; }
        public string category { get; set; }
        public string name { get; set; }

        public UserValidatorResponse() { }
        public UserValidatorResponse(int status, int id, int user_status, string category, string name)
        {
            this.status = status;
            this.id = id;
            this.user_status = user_status;
            this.category = category;
            this.name = name;
        }

        public UserValidatorResponse(int v1, int v2, int v3, string v4)
        {
        }
    }

    
}
