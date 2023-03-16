using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _Context;
        public SuperHeroController(DataContext context)
        {
            _Context = context; 
        }

        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero =_Context.SuperHeroes.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("hero not found.");
            }
            return Ok(hero);
        }

        // _Context.SuperHeroes.FindAsync(id);
        [HttpGet("numberOfPage")]
        public async Task<ActionResult<SuperHero>> GetElement(int numberOfPage)
        {

            var hero = _Context.SuperHeroes.Skip((numberOfPage - 1) * 3).Take(3).ToList();
            if (hero == null)
            {
                return BadRequest("hero not found.");
            }
            return Ok(hero);
        }


        [HttpGet("SelecteTake")]
        public async Task<ActionResult<SuperHero>> GetElement2(int numberOfPage,int numberTake)
        {

            var hero = _Context.SuperHeroes.Skip((numberOfPage - 1) * numberTake).Take(numberTake).ToList();
            if (hero == null)
            {
                return BadRequest("hero not found.");
            }
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            _Context.SuperHeroes.Add(hero);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = await _Context.SuperHeroes.FindAsync( request.Id);
            if (hero == null)
            {
                return BadRequest("hero not found.");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        
        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _Context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("hero not found.");
            }
            _Context.SuperHeroes.Remove(hero);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }



    }
}
