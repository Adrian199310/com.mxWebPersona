
using com.mxWebPersona.Cliente.Models.Response;

namespace com.mxWebPersona.Cliente.Servicios
{
    public interface IServicioApi
    {
        PersonasResponse GetListPersonas();
        PersonasResponse getPersona(int idPersona);
        CreatePersonaResponse CreatePersona(Persona persona);
        CreatePersonaResponse UpdatePersona(Persona persona);
        bool DeletePersona(int idPersona);
    }
}
