using System.ComponentModel.DataAnnotations;

namespace com.mxWebPersona.Cliente.Models.Response
{
    public class Persona
    {
        public int idPersona { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio.")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellodo Paterno es obligatorio.")]
        public string apellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio.")]
        public string apellidoMaterno { get; set; }
        [RegularExpression("[0-9]*", ErrorMessage="Solo permite Numeros")]
        [StringLength(10,ErrorMessage ="Debe de tener 10 digitos")] 
        public string telefono { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}
