using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios.Facades;

namespace VideoClub.Repositorios.Repositorios
{
    public class RepositorioCalificaciones : IRepositorioCalificaciones
    {
        private readonly VideoClubDbContext context;

        public RepositorioCalificaciones()
        {
            context = new VideoClubDbContext();
        }

        public List<Calificacion> GetLista()
        {
            try
            {
                return context.Calificaciones.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
