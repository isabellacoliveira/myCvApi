using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCvApi.Data;
using myCvApi.Data.DTOs.Formacao;
using myCvApi.Models;

namespace myCvApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormacaoAcademicaController : ControllerBase
    {
        private LinguagemContext _context;
        private IMapper _mapper;
        public FormacaoAcademicaController(LinguagemContext context, IMapper mapper)
        {        
            _context = context;
            _mapper = mapper;
        }

    [HttpPost]
    public IActionResult AdicionaFormacao([FromBody] CreateFormacaoDto formacaoDto)
    {
        Formacao formacao = _mapper.Map<Formacao>(formacaoDto);
        _context.Formacoes.Add(formacao); 
        _context.SaveChanges(); 
        return CreatedAtAction(nameof(RecuperaFormacaoPorId),  new {  
                                          linguagemId = formacao.Id }, formacao);
    }

    [HttpGet]
    public IEnumerable<ReadFormacaoDto> RecuperaFormacoes([FromQuery] int? formacaoId = null)
    {
        if(formacaoId == null)
        {
            return _mapper.Map<List<ReadFormacaoDto>>(_context.Formacoes.ToList()); 
        }
        // TODO arrumar isso 
        return _mapper.Map<List<ReadFormacaoDto>>(_context.Formacoes.FromSqlRaw($"SELECT Id, Nome, Cor, CorTexto, Imagem from LINGUAGENS WHERE linguagens.linguagemId = {formacaoId}").ToList());
    }



    [HttpGet("{id}")]
    public IActionResult RecuperaFormacaoPorId(int id)
    {
        Formacao formacao = _context.Formacoes.FirstOrDefault(formacao => formacao.Id == id);
        if(formacao != null)
        {
            ReadFormacaoDto formacaoDto = _mapper.Map<ReadFormacaoDto>(formacao);
            return Ok(formacaoDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFormacao(int id, [FromBody] UpdateFormacaoDto formacaoDto)
    {
        var formacao = _context.Formacoes.FirstOrDefault(formacao => formacao.Id == id);
        if(formacao == null) return NotFound(); 
        _mapper.Map(formacaoDto, formacao); 
        _context.SaveChanges(); 
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFormacaoParcial(int id, JsonPatchDocument<UpdateFormacaoDto> patch)
    {
            var formacao = _context.Formacoes.FirstOrDefault(
            formacao => formacao.Id == id);
            if(formacao == null) return NotFound();
            var formacaoParaAtualizar = _mapper.Map<UpdateFormacaoDto>(formacao);
            patch.ApplyTo(formacaoParaAtualizar, ModelState);
            if(!TryValidateModel(formacaoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(formacaoParaAtualizar, formacao);
            _context.SaveChanges();
            return NoContent(); 
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletaFormacao(int id)
    {
        var formacao = _context.Formacoes.FirstOrDefault(formacao => formacao.Id == id);
        if(formacao == null) return NotFound(); 
        
        _context.Remove(formacao); 
        _context.SaveChanges(); 
        return NoContent(); 
    }
    }
}