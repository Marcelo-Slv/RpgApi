using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [Route("[controller]")]
    public class PersonagensExercicioController : Controller
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Personagens aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return Ok(listaBusca);
            return NotFound(listaBusca);
        }
//ex 2
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            Personagem pRemove = personagens.Find(p => p.Classe == ClasseEnum.Cavaleiro);
            personagens.Remove(pRemove);
            List<Personagem> listaFinal = personagens.OrderBy(p => p.PontosVida).ToList();
            return Ok(listaFinal) ;
        }

//ex 3 
      [HttpGet("GetEstatisticas")]
      public IActionResult GetEstatisticas(int resultado)
        {
            return Ok("Quantidade de personagens: " + personagens.Count);
            return Ok("Soma das Inteligencias: " + personagens.Sum(p => p.Inteligencia));
        }

// ex 4
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem bloqueiarNovoPersonagem)
        {
            if (bloqueiarNovoPersonagem.Defesa < 10 || bloqueiarNovoPersonagem.Inteligencia > 30)
            {
                return BadRequest("Atributos muito equivocados em defesa e inteligencia");
            }
            return Ok(personagens);
        }

// ex 5 
    [HttpPost("PostValidacaoMago")]
    public IActionResult PostValidacaoMago(Personagem personagemMago)
    {
        if (personagemMago.Inteligencia < 35)
            {
                return BadRequest("Inteligencia muito baixa");
            }

        return Ok(personagens);
    }

// ex 6

    [HttpGet("GetByClasse")]
    public IActionResult GetByClasse(int enumid)
        {
            ClasseEnum Enumdigitado = (ClasseEnum)enumid;
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == Enumdigitado);
            return Ok(listaBusca);
        }


    }
}
