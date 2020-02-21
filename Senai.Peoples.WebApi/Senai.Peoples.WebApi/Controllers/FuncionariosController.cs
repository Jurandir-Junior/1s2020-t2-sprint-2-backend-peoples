using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);
            
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Deletar(id);

            return Ok("Funcionario Deletado");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpGet("Buscar/{nome}")]
        public IActionResult GetByName(string nome)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorNome(nome);

            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if(funcionarioBuscado == null)
            {
                return NotFound
                    (
                    new
                    {
                        mensagem = "Funcionario não encontrado",
                        erro = true
                    }

                    );
                
            }

            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}