using Personas.Controllers.Entities;


namespace Personas.Controllers
{
    public interface IPersonasRepositorio
    {
        public List<Persona> ObtenerPersonas();
        public bool AgregarPersona(Persona persona);
        public bool EliminarPersona(Persona persona);
        public bool ActualizarPersona(Persona persona);
        public Persona BuscarPersona(string nombre = "", string correo = "");

    }
}
