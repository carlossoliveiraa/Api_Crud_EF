using Api_Crud_EF.Application.Domain;
using Api_Crud_EF.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud_EF.Controllers
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _appEmpresa;

        public EmpresaController(IEmpresaRepository appEmpresa)
        {
            _appEmpresa = appEmpresa;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Empresa empresa)
        {
            if (empresa == null)
            {
                return BadRequest("Empresa inválida");
            }

            await _appEmpresa.Adicionar(empresa);

            return CreatedAtAction(nameof(ObterPorId), new { id = empresa.Id }, empresa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var empresa = await _appEmpresa.ObterEmpresaComEndereco(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var empresas = await _appEmpresa.ObterTodos();
            return Ok(empresas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Empresa empresa)
        {
            if (empresa == null || empresa.Id != id)
            {
                return BadRequest("Dados da empresa inválidos");
            }

            var empresaExistente = await _appEmpresa.ObterPorId(id);
            if (empresaExistente == null)
            {
                return NotFound();
            }

            await _appEmpresa.Atualizar(empresa);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var empresa = await _appEmpresa.ObterPorId(id);
            if (empresa == null)
            {
                return NotFound();
            }
            await _appEmpresa.Remover(id);

            return NoContent();
        }

    }
}
