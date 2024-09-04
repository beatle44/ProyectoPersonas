using Personas.Controllers;
using Microsoft.EntityFrameworkCore;

using DBPersonas;
using System;
using Personas.Controllers.Entities;


namespace Personas.Controllers
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        List<Persona> libros = new List<Persona>();
        PersonasRepositorio librosRepositorio = new PersonasRepositorio();

      
        public bool AgregarPersona(Persona nuevaPersona)
        {
            using (var context = new ApiContext())
            {
                try
                {
                    context.Personas.AddRange(nuevaPersona);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }//end of using

        }//End of AgregarLibro

        public bool EliminarPersona(Persona eliminarPersona)
        {
            using (var context = new ApiContext())
            {
                try
                {
                    context.Personas.Remove(eliminarPersona);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }//End of using
        }//End of EliminarLibro

        public bool ActualizarPersona(Persona actualPersona) {

            using (var context = new ApiContext()) {
                try {
                    Persona personaAnterior = (Persona)context.Personas.Where(x => x.Nombre == actualPersona.Nombre);
                    if (personaAnterior == null)
                    {
                        context.Personas.Remove(personaAnterior);
                        context.Personas.AddRange(actualPersona);
                        context.SaveChanges();
                        return true;
                    }//End of If
                    else
                    {
                        return false;
                    }

                }catch (Exception)
                {
                    return false;
                }
            }//End of using

        }//end of ActualizarPersona

        public List<Persona> ObtenerPersonas()
        {
            using (var context = new ApiContext())
            {
                var list = context.Personas.ToList();
                return list;
            }
        }//End of ObtenerPersonas

        public Persona BuscarPersona(string Nombre = "", string Correo = "") {

            using (var context = new ApiContext()) {

                if (Nombre != "" && Correo == "")
                {
                    Persona personaBuscada = (Persona)context.Personas.Where(x => x.Nombre == Nombre);
                    return personaBuscada;
                }else if (Nombre == "" && Correo != "")
                {
                    Persona personaBuscada = (Persona)context.Personas.Where(x => x.Correo == Correo);
                    return personaBuscada;
                }
                else
                {
                    return null;
                }

            }//End of Using

        }//End of BuscarPersona

    }
}
