using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QualitySystemsEstagio.Controllers
{

    [ApiController]
    //[Route("[controller]")]
    [Route("api/UsuariosController")]
    public class UsuariosController : ControllerBase
    {

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return Repositorio.Usuarios;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            Usuario usuario = Repositorio.Usuarios.FirstOrDefault(l => l.IdUsuario == id);
            return usuario;
        }
     
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Usuario value)
        {
            Usuario usuario = Repositorio.Usuarios.FirstOrDefault(l => l.IdUsuario == value.IdUsuario);
            

            if (usuario == null)
            {
                //Adiciona novo usuario na lista de usuario
                Repositorio.Usuarios.Add(value);
                //Salva lista de usuarios atualizada no arquivo Json
                Repositorio.Insert(Repositorio.Usuarios, Repositorio.path);

            }

        }




    }
}
