using Microsoft.EntityFrameworkCore;
using Personas.Controllers;
using Personas.Controllers.Entities;
using DBPersonas;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Personas.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : Controller
    {
        public IPersonasRepositorio _personaRepositorio;
        public PersonasController(IPersonasRepositorio personaRepositorio) {
            _personaRepositorio = personaRepositorio;
        }//end of contructor

        [HttpGet]
        [Route("traePersonas")]
        public ActionResult<List<Persona>> ObtenerPersonas()
        {
            return Ok(_personaRepositorio.ObtenerPersonas());
        }//End of ObtenerPersonas

        [HttpGet]
        [Route("agregarPersona")]
        public bool AgregarPersona([FromBody] Persona nuevaPersona)
        {
            return _personaRepositorio.AgregarPersona(nuevaPersona);
        }//End of AgregarPersona

        [HttpGet]
        [Route("eliminarPersona")]
        public bool EliminarLibro([FromBody] Persona eliminarPersona)
        {
            return _personaRepositorio.EliminarPersona(eliminarPersona); 
        }//End of EliminarLibro

        [HttpGet]
        [Route("actualizaPersona")]
        public bool ActualizaPersona([FromBody] Persona actualizaPersona)
        {
            return _personaRepositorio.ActualizarPersona(actualizaPersona);
        }//End of ActualizaPersona

        [HttpGet]
        [Route("buscarPersona")]
        public Persona BuscarPersona([FromBody] Persona actualizaPersona)
        {
            return _personaRepositorio.BuscarPersona(actualizaPersona.Nombre, actualizaPersona.Correo);
        }//End of ActualizaPersona

    }//End of Class 
}
