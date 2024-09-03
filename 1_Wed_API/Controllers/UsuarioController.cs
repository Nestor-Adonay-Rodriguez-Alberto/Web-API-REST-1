using _1_Wed_API.Data;
using _1_Wed_API.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace _1_Wed_API.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        // OBTIENE TODOS LOS REGISTROS DE LA TABLA:
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }

        // POST api/<controller>
        // RECIBE UN PARAMETRO Y LO GUARDA EN LA DB:
        public bool Post([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Registrar(oUsuario);
        }

        // PUT api/<controller>/5
        // RECIBE UN PARAMETRO LO BUSCA EN LA DB POR SU ID Y MODIFICA:
        public bool Put([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Modificar(oUsuario);
        }

        // GET api/<controller>/5
        // OBTIENE UN REGISTRO DE LA DB CON ESE ID:
        public Usuario Get(int id)
        {
            return UsuarioData.Obtener(id);
        }

        // DELETE api/<controller>/5
        // RECIBE UN PARAMETRO LO BUSCA EN LA DB POR SU ID Y ELIMINA:
        public bool Delete(int id)
        {
            return UsuarioData.Eliminar(id);
        }
    }
}