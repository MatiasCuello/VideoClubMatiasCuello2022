using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios.Facades;

namespace VideoClub.Repositorios.Repositorios
{
    public class RepositorioEstados : IRepositorioEstados
    {
        private readonly VideoClubDbContext context;

        public RepositorioEstados()
        {
            context = new VideoClubDbContext();
        }

        public List<Estado> GetLista()
        {
            try
            {
                return context.Estados.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
