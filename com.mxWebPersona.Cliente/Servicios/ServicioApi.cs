using com.mxWebPersona.Cliente.Models.Response;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net.Http;
namespace com.mxWebPersona.Cliente.Servicios
{
    public class ServicioApi : IServicioApi
    {
        private readonly string _url;

        public ServicioApi()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _url = builder.GetSection("ApiSettings:baseURL").Value; 
        }

        public PersonasResponse GetListPersonas()
        {
            try
            {

                var cliente = new RestClient(_url);
                var request = new RestRequest();

                RestResponse response = cliente.Get(request);

                PersonasResponse personas = System.Text.Json.JsonSerializer.Deserialize<PersonasResponse>(response.Content);


                return personas;
                

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public CreatePersonaResponse CreatePersona(Persona persona)
        {
            var client = new RestClient(_url);
            //client.Timeout = -1;
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var body = System.Text.Json.JsonSerializer.Serialize(persona);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Post(request);
            Console.WriteLine(response.Content);
            CreatePersonaResponse personas = System.Text.Json.JsonSerializer.Deserialize<CreatePersonaResponse>(response.Content);

            return personas;
       
        }

        public bool DeletePersona(int idPersona)
        {
            try
            {

                var cliente = new RestClient(_url);
                var request = new RestRequest("/" + idPersona);
                request.Method = Method.Delete;
                request.AddHeader("Content-Type", "application/json");
                Console.WriteLine(request);
                RestResponse response = cliente.Delete(request);

                DeletePersonaResponse personas = System.Text.Json.JsonSerializer.Deserialize<DeletePersonaResponse>(response.Content);


                return personas.code;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        public PersonasResponse getPersona(int idPersona)
        {
            try
            {

                var cliente = new RestClient(_url);
                var request = new RestRequest("/"+idPersona);
                request.Method = Method.Get;
                request.AddHeader("Content-Type", "application/json");
                request.AddUrlSegment("id", idPersona);
                Console.WriteLine(request);
                RestResponse response = cliente.Get(request);

                PersonasResponse personas = System.Text.Json.JsonSerializer.Deserialize<PersonasResponse>(response.Content);


                return personas;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CreatePersonaResponse UpdatePersona(Persona persona)
        {
            try
            {
                var client = new RestClient(_url);
                //client.Timeout = -1;
                var request = new RestRequest();
                request.Method = Method.Put;
                request.AddHeader("Content-Type", "application/json");
                var body = System.Text.Json.JsonSerializer.Serialize(persona);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Put(request);
                Console.WriteLine(response.Content);
                CreatePersonaResponse personas = System.Text.Json.JsonSerializer.Deserialize<CreatePersonaResponse>(response.Content);

                return personas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
