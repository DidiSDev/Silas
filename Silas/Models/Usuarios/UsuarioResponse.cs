namespace Silas.Models.Usuarios
{
    public class UsuarioResponse
    {
        public int Estado {  get; set; }
        public List<Usuario> Usuarios { get; set; }

        public string Mensaje
        {
            get; set;
        }
    }
}
