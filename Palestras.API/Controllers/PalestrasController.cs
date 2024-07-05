using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palestras.API.Entities;
using Palestras.API.Persistence;

namespace Palestras.API.Controllers
{
    [Route("api/palestras")]
    [ApiController]
    public class PalestrasController : ControllerBase
    {

        //Injeção de dependencia
        private readonly PalestrasDbContext _context;

        //acessar o dbcontext
        public PalestrasController(PalestrasDbContext context)
        {
            _context = context;
        }

        //Obter todos os registros onde isDeleted = falso
        [HttpGet]
        public IActionResult GetAll()
        {
            //pega todos os registros não deletados
            var palestra = _context.Palestras.Where(d => !d.IsDeleted).ToList();

            return Ok(palestra);
        }

        //Obter registro pelo ID
        [HttpGet ("{id}")]
        public IActionResult GetById(Guid id)
        {
            var palestra = _context.Palestras.SingleOrDefault(d => d.Id == id);

            //Se não encontrar nenhum registro
            if (palestra == null)
            {
                return NotFound();
            }

            return Ok(palestra);
        }

        //Cadastrar novo registro
        [HttpPost]
        public IActionResult Post(Palestra palestra)
        {
            //Adiciona o registro
            _context.Palestras.Add(palestra);
            //Retorna o registro recém-adicionado
            return CreatedAtAction(nameof(GetById), new { id = palestra.Id }, palestra);
        }

        //Atualizar registro
        [HttpPut ("{id}")]
        public IActionResult Update(Guid id, Palestra input)
        {
            //Busca o Id 
            var palestra = _context.Palestras.SingleOrDefault(d => d.Id == id);

            //Se não encontrar nenhum registro
            if (palestra == null)
            {
                return NotFound();
            }

            //atualiza o registro
            palestra.Update(input.Titulo, input.Descricao, input.DataInicio, input.DataTermino);

            return NoContent();

        }

        //Deletar registro
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // Busca o Id
            var palestra = _context.Palestras.SingleOrDefault(d => d.Id == id);

            //Se não encontrar nenhum registro
            if (palestra == null)
            {
                return NotFound();
            }

            palestra.Delete();
            return NoContent();

        }

        //Cadastrar Palestrante
        [HttpPost("{id}/palestrantes")]
        public IActionResult PostPalestrante(Guid id, PalestraPalestrante palestrante)
        {
            // Busca o Id
            var palestra = _context.Palestras.SingleOrDefault(d => d.Id == id);

            //Se não encontrar nenhum registro
            if (palestra == null)
            {
                return NotFound();
            }

            palestra.Palestrantes.Add(palestrante);

            return NoContent();
        }



    }
}
