using System.ComponentModel.DataAnnotations;

namespace Silas.Models.Usuarios
{
    public class User
    {

       // [Required(ErrorMessage = "El correo electrónico es obligatorio")]
       // [EmailAddress(ErrorMessage = "Formato de correo electrónico no válido")]
        public string email { get; set; }
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$",
       // ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluir una mayúscula, una minúscula y un número.")]
        public string password { get; set; }
        public int status { get; set; } //DEFINIMOS EL STATUS DE USER 0 = PENDIENTE, 1 = ACTIVO  (LA TAREA DE ACCTIVACION LA HACER EL ADMIN) 

        

        

    }
}
