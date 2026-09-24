using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns; 

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Armas a = await _context.TB_ARMAS
                    .FirstOrDefaultAsync(aBusca => aBusca.Id == id);

                if (a == null)
                    return NotFound("Arma não encontrada.");

                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Armas> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
               
                if (novaArma.Dano > 100)
                {
                    throw new Exception("O dano da arma não pode ser maior que 100");
                }

                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
[HttpPatch("{id}")]
public async Task<IActionResult> UpdateDano(int id, [FromBody] int novoDano)
{
    try
    {
 
        Armas armaDoBanco = await _context.TB_ARMAS
            .FirstOrDefaultAsync(a => a.Id == id);

        if (armaDoBanco == null)
            return NotFound("Arma não encontrada.");

        if (novoDano > 100)
            throw new Exception("O dano da arma não pode ser maior que 100");

        armaDoBanco.Dano = novoDano;

        await _context.SaveChangesAsync();
        return Ok($"Dano da arma {armaDoBanco.Nome} atualizado para {novoDano}!");
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message);
    }
}


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas aRemover = await _context.TB_ARMAS.FirstOrDefaultAsync(a => a.Id == id);

                if (aRemover == null)
                    return NotFound("Arma não encontrada para remoção.");

                _context.TB_ARMAS.Remove(aRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
