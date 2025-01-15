namespace Silas.Models.Usuarios
{
    public class Usuario
    {
        public string identification {  get; set; }
        public string name {  get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public string sex { get; set; }
        public DateOnly birthDate { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }

        public string country { get; set; }

    }
}
