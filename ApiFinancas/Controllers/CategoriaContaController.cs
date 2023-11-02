using ApiFinancas.Dto;
using ApiFinancas.Models;
using ApiFinancas.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace ApiFinancas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaContaController : ControllerBase
    {
        private readonly ICategoriaConta _categoriaContaRepository; 

        public CategoriaContaController(ICategoriaConta categoriaContaRepository)
        {
            _categoriaContaRepository = categoriaContaRepository;
        }

        [HttpGet("buscar/{categoriaContaId:int}")]
        public async Task<ActionResult<CategoriaConta>> GetCategoriaConta([FromRoute] int categoriaContaId)
        {
            try
            {
                var result = await _categoriaContaRepository.GetCategoriaConta(categoriaContaId);

                if(result != null)
                {
                    return Ok(result);
                }

                return BadRequest("Não foi possível localizar nenhuma categoria de conta com o Id informado!"); 
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<CategoriaConta>>> GetCategoriasConta()
        {
            try
            {
                var result = await _categoriaContaRepository.GetCategoriasConta(); 

                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest("Não foi possível localizar nenhuma categoria de conta!");
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult> AddCategoriaConta([FromBody] CategoriaContaDTO categoriaConta)
        {
            try
            {
                var result = await _categoriaContaRepository.AddCategoriaConta(categoriaConta);

                if (result)
                {
                    return Ok($"Categoria de conta {categoriaConta.NomeCategoria} adicionada com sucesso!");
                }

                return BadRequest("Não foi possível adicionar uma nova categoria de conta!"); 
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint" + e);
            }
        }

        [HttpPut("atualizar/{categoriaContaId:int}")]
        public async Task<ActionResult> UpdateCategoriaConta([FromRoute] int categoriaContaId, [FromBody] CategoriaContaDTO categoriaConta)
        {
            try
            {
                var result = await _categoriaContaRepository.UpdateCategoriaConta(categoriaContaId, categoriaConta);

                if (result)
                {
                    return Ok("Categoria de conta atualizada com sucesso!"); 
                }

                return BadRequest("Não foi possível atualizar a categoria de conta!"); 
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }

        [HttpDelete("deletar/{categoriaContaId:int}")]
        public async Task<ActionResult> DeleteCategoriaConta([FromRoute] int categoriaContaId)
        {
            try
            {
                var result = await _categoriaContaRepository.DeleteCategoriaConta(categoriaContaId);

                if (result)
                {
                    return Ok("Categoria de conta deletada com sucesso!"); 
                }

                return BadRequest("Não foi possível deletar uma categoria de conta com o Id informado!"); 
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro durante a execução do EndPoint");
            }
        }
    }
}
