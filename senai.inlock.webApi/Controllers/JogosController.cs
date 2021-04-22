using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository Jogo { get; set; }

        public JogosController()
        {
            Jogo = new JogosRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<JogosDomain> JgLista = Jogo.ListarTodos();
            return Ok(JgLista);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(JogosDomain NovoJogo)
        {
            Jogo.Cadastrar(NovoJogo);
            return StatusCode(201);
        }
    }
}
