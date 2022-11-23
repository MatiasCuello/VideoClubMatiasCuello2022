using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios.Facades;

namespace VideoClub.Repositorios.Repositorios
{
    public class RepositorioGeneros : IRepositorioGeneros
    {
        private readonly VideoClubDbContext context;

        public RepositorioGeneros()
        {
            context = new VideoClubDbContext();
        }

        public List<Genero> GetLista()
        {
            try
            {
                return context.Generos.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
