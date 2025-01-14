using ControleDeEstudantes.Data;
using ControleDeEstudantes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControleDeEstudantes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CpfApiController : Controller
    {
       private readonly BancoContext _bancoContext;

        public CpfApiController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        [HttpGet("existe")] // Rota: /api/cpf/existe
        public IActionResult VerificarCpfExistente(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return BadRequest(new { erro = "CPF não informado." });
            }

            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11)
            {
                return BadRequest(new { erro = "CPF inválido." });
            }

            try
            {
                bool existe = _bancoContext.Estudantes.Any(e => e.CPF == cpf);
                return Ok(new { existe });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { erro = "Erro ao consultar o banco de dados: " + ex.Message });
            }
        }
    }
}
