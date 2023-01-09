namespace com.mxWebPersona.Cliente.Models.Response
{
    public class CreatePersonaResponse
    {
        public Persona persona { get; set; }
        public bool code { get; set; }
        public string mensaje { get; set; }
        public string error { get; set; }
    }
}
