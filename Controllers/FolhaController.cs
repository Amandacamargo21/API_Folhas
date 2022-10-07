using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
        private readonly DataContext _context;

        public FolhaController(DataContext context) =>
            _context = context;

        private static List<FolhaPagamento> folhas = new List<FolhaPagamento>();

        // POST: /api/folha/cadastrar
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {
            folha.Funcionario = _context.Funcionarios.Find(folha.FuncionarioId);
            folha.SalarioBruto = folha.ValorHora * folha.QuantidadeDeHoras;

            if (folha.Funcionario != null)
            {
                //Imposto de renda

                switch (folha.SalarioBruto)
                {
                    case < 1903.99:
                        folha.ImpostoRenda = 0;
                        break;

                    case < 2826.66:
                        folha.ImpostoRenda = folha.SalarioBruto * 0.075 - 142.8;
                        break;

                    case < 3751.06:
                        folha.ImpostoRenda = folha.SalarioBruto * 0.015 - 354.80;
                        break;

                    case < 4664.69:
                        folha.ImpostoRenda = folha.SalarioBruto * 0.0225 - 636.13;
                        break;

                    default:
                        folha.ImpostoRenda = folha.SalarioBruto * 0.0275 - 869.36;
                        break;

                }



                switch (folha.SalarioBruto)
                {
                    case < 1693.73:
                        folha.SalarioBruto = folha.SalarioBruto * 0.08;
                        break;

                    case < 2822.91:
                        folha.SalarioBruto = folha.SalarioBruto * 0.09;
                        break;

                    case < 5645.81:
                        folha.SalarioBruto = folha.SalarioBruto * 0.011;
                        break;

                    default:
                        folha.SalarioBruto = folha.SalarioBruto - 621.03;
                        break;

                }



                folha.SalarioLiquido = folha.SalarioBruto - folha.ImpostoRenda - folha.Inss;
                folha.Fgts = folha.SalarioBruto * 0.08;

                _context.Folhas.Add(folha);
                _context.SaveChanges();
                return Created("", folha);
            }
            return NotFound();

        }

        // GET: /api/folha/listar
        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Folhas.ToList());



        // GET: /api/folha/buscar/{cpf}/{mes}/{ano}
        [Route("buscar/{cpf}/{mes}/{ano}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            //Expressão lambda
            FolhaPagamento folha = _context.Folhas.FirstOrDefault
            (
                f => f.Funcionario.Cpf.Equals(cpf)
            );
            //IF ternário
            return folha != null ? Ok(folha) : NotFound();
        }

        // GET: /api/folha/filtrar/{Data}
        [Route("filtrar/{Data}")]
        [HttpGet]
        public IActionResult Filtar([FromRoute] int Data)
        {
            FolhaPagamento folhaPagamento = _context.Folhas.FirstOrDefault(f => f.Data.Equals(Data));

            return folhaPagamento != null ? Ok(folhaPagamento) : NotFound();
        }
    }
}
