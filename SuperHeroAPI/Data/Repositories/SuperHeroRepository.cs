using SuperHeroAPI.Interfaces;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data.Repositories
{
    public class SuperHeroRepository : ISuperHeroes
    {


        private readonly DataContext _context;

        public SuperHeroRepository(DataContext ctx)
        {
            _context = ctx;   
        }

        public async Task<List<SuperHero>> CreateHeroAsync(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
                    
            //throw new NotImplementedException();
        }

        public async Task<List<SuperHero>> DeleteHeroAsync(int Id)
        {
            if (Id != 0)
            {
                //var FindHero = heroes.Where(m => m.Id == id).FirstOrDefault();
                var FindHero = await _context.SuperHeroes.Where(m => m.Id == Id).FirstOrDefaultAsync();

                if (FindHero != null)
                {
                    //heroes.Remove(FindHero);
                    _context.SuperHeroes.Remove(FindHero);
                    await _context.SaveChangesAsync();
                }
                else
                    throw new("Hero Not Found");
            }
            return await _context.SuperHeroes.ToListAsync();

            //throw new NotImplementedException();
        }

        public async Task<SuperHero> GetAHeroAsync(int Id)
        {
            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(m => m.Id == Id);

            if (hero == null)
            {
                throw new("hero Not Found");
            }
            else
                return  hero;
                //return Ok(hero);
            //throw new NotImplementedException();
        }

        public async Task<List<SuperHero>> GetAllHeroesAsync()
        {
            return await _context.SuperHeroes.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<List<SuperHero>> UpdateHeroAsync(SuperHero hero)
        {
            var Findhero = await _context.SuperHeroes.Where(m => m.Id == hero.Id).FirstOrDefaultAsync();

            if (Findhero != null)
            {
                Findhero.FirstName = hero.FirstName;
                Findhero.LastName = hero.LastName;
                Findhero.Place = hero.Place;
                Findhero.Name = hero.Name;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Id couldn't found");
            }

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
