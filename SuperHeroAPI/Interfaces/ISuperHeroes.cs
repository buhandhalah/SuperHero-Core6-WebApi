using SuperHeroAPI.Models;

namespace SuperHeroAPI.Interfaces
{
    public interface ISuperHeroes
    {
       Task<List<SuperHero>> GetAllHeroesAsync();

        Task<SuperHero> GetAHeroAsync(int Id);

        Task<List<SuperHero>> CreateHeroAsync(SuperHero hero);

        Task<List<SuperHero>> UpdateHeroAsync(SuperHero hero);

        Task<List<SuperHero>> DeleteHeroAsync(int Id);

                        

    }
}
