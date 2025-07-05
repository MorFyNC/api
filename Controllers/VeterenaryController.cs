using APIkvalik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIkvalik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterenaryController : ControllerBase
    {
        private AnimalArmiContext context;

        public VeterenaryController(AnimalArmiContext _context)
        {
            context = _context;
        }

        [HttpPost("Card")]
        public async Task<IActionResult> Card([FromBody] card card)
        {
            var cards = new MedKartum() { Id=card.id,PetId = card.id_pet, Vaccine = card.Vaccine, Disease = card.Disease, Medicine = card.Medicine, Advice = card.Advice };
            context.MedKarta.Add(cards);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Advice")]
        public async Task<IActionResult> GiveAdvice([FromBody] advice advice)
        {
            var bd_advice = await context.MedKarta.FirstOrDefaultAsync(x => x.Id == advice.Id_card);
            bd_advice.Advice = advice.Advice;
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("Pets")]
        public async Task<IActionResult> GivePets()
        {
            var pets = new PetsWrapper() { pets = await context.Pets.ToListAsync() };
            return new OkObjectResult(pets);
        }

        public class PetsWrapper
        {
            public List<Pet> pets;
        }

        public class card
        {
            public int id { get; set; }
            public int id_pet { get; set; }
            public string Vaccine { get; set; }
            public string Disease { get; set; }
            public string Medicine { get; set; }
            public string Advice { get; set; }
        }
        public class advice 
        {
            public int Id_card { get; set; }
            public string Advice { get; set; }
        }
     
        }

    }
