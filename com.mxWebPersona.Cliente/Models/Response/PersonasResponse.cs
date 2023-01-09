namespace com.mxWebPersona.Cliente.Models.Response
{
    public class PersonasResponse
    {
        public Persona[] personas { get; set; }
        public bool code { get; set; }
        public string mensaje { get; set; }
        public string error { get; set; }
    }

    //public class Persona
    //{
    //    public int idPersona { get; set; }
    //    public string nombre { get; set; }
    //    public string apellidoPaterno { get; set; }
    //    public string apellidoMaterno { get; set; }
    //    public string telefono { get; set; }
    //    public string email { get; set; }
    //}

}
