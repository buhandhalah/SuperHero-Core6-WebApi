using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Interfaces;
using SuperHeroAPI.Models;
namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private readonly DataContext _context;

        private readonly ISuperHeroes _hero;
        public SuperHeroController(ISuperHeroes heroes)
        {
            _hero = heroes;
        }

        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "Newyork"
                }
                , new SuperHero {
                    Id = 2,
                    FirstName = "John ",
                    LastName = "Honai",
                    Place = "Delhi"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {


           return Ok(await _hero.GetAllHeroesAsync());

            //return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {

           // var hero = heroes.FirstOrDefault(m => m.Id == id);
            //var hero = await _context.SuperHeroes.FirstOrDefaultAsync(m => m.Id == id);

            //if(hero == null)
            //{
            //    return BadRequest("hero Not Found");
            //}
            //else 
            return Ok(await _hero.GetAHeroAsync(id));
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            // heroes.Add(hero);
            //_context.SuperHeroes.Add(hero);
            //await _context.SaveChangesAsync();

            return Ok(await _hero.CreateHeroAsync(hero));
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            //var Findhero = heroes.Where(m => m.Id == hero.Id).FirstOrDefault();
            //var Findhero = await _context.SuperHeroes.Where(m => m.Id == hero.Id).FirstOrDefaultAsync();

            //if(Findhero != null)
            //{
            //    Findhero.FirstName = hero.FirstName;
            //    Findhero.LastName = hero.LastName;
            //    Findhero.Place = hero.Place;
            //    Findhero.Name = hero.Name;

            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    return BadRequest("Id couldn't found");
            //}

            return Ok(await _hero.UpdateHeroAsync(hero));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            //if(id != 0)
            //{
            //    //var FindHero = heroes.Where(m => m.Id == id).FirstOrDefault();
            //    var FindHero = await _context.SuperHeroes.Where(m => m.Id == id).FirstOrDefaultAsync();

            //    if(FindHero != null)
            //    {
            //        //heroes.Remove(FindHero);
            //        _context.SuperHeroes.Remove(FindHero);
            //        await _context.SaveChangesAsync();
            //    }
            //    else
            //        return BadRequest("Hero Not Found");
            //}
            return Ok(await _hero.DeleteHeroAsync(id));
        }
    }
}
