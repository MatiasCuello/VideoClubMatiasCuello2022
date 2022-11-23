using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios.Facades;

namespace VideoClub.Repositorios.Repositorios
{
    public class RepositorioSoportes : IRepositorioSoportes
    {
        private readonly VideoClubDbContext context;

        public RepositorioSoportes()
        {
            context = new VideoClubDbContext();
        }

        public List<Soporte> GetLista()
        {
            try
            {
                return context.Soportes.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
