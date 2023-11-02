using ApiFinancas.Dto;
using ApiFinancas.Models;
using ApiFinancas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ApiFinancas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IConta _contaRepository; 

        public ContaController(IConta contaRepository)
        {
            _contaRepository = contaRepository;
        }

        [HttpGet("buscar/{contaId:int}")]
        public async Task<ActionResult<Conta>> GetConta([FromRoute] int contaId)
        {
            try
            {
                var result = await _contaRepository.GetConta(contaId); 

                if(result != null)
                {
                    return Ok(result);
                }

                return BadRequest("Nenhuma conta encontrada com o Id informado!");
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas()
        {
            try
            {
                var result = await _contaRepository.GetContas(); 

                if(result != null)
                {
                    return Ok(result);
                }

                return BadRequest("Não foi possível encontrar nenhuma conta cadastrada!"); 
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult> AddConta([FromBody] AdicionarContaDTO adicionarConta)
        {
            try
            {
                var result = await _contaRepository.AddConta(adicionarConta);

                if (result)
                {
                    return Ok($"Conta {adicionarConta.NomeConta} adicionada com sucesso!");
                }

                return BadRequest("Não foi possível adicionar a nova conta!"); 
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpPut("atualizar/{contaId:int}")]
        public async Task<ActionResult> UpdateConta([FromRoute] int contaId, [FromBody] AtualizarContaDTO atualizarConta)
        {
            try
            {
                var result = await _contaRepository.UpdateConta(contaId, atualizarConta);

                if (result)
                {
                    return Ok($"Conta {atualizarConta.NomeConta} atualizada com sucesso!"); 
                }

                return BadRequest("Não foi possível atualizar a conta!");
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpDelete("deletar/{contaId:int}")]
        public async Task<ActionResult> DeleteConta(int contaId)
        {
            try
            {
                var result = await _contaRepository.DeleteConta(contaId);

                if (result)
                {
                    return Ok("Conta deletada com sucesso!"); 
                }

                return BadRequest("Não foi possível deletar uma conta com o Id informado!");
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }
    }
}
