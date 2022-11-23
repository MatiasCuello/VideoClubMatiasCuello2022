using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;

namespace VideoClub.Repositorios.Repositorios.Facades
{
    public class RepositorioPeliculas:IRepositorioPeliculas
    {
        private readonly VideoClubDbContext context;

        public RepositorioPeliculas()
        {
            context = new VideoClubDbContext();
        }

        public void Borrar(int peliculaId)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> GetLista
            (Calificacion calificacion=null, Estado estado=null, Genero genero=null, Soporte soporte=null)
        {
            try
            {
                var query = context.Peliculas
                    .Include(p => p.Calificacion)
                    .Include(p => p.Estado)
                    .Include(p => p.Genero)
                    .Include(p => p.Soporte);

                if (calificacion != null || estado != null || genero != null ||soporte != null)
                {
                    query = query.Where(p => p.CalificacionId == calificacion.CalificacionId);
                    query = query.Where(p => p.EstadoId == estado.EstadoId);
                    query = query.Where(p => p.GeneroId == genero.GeneroId);
                    query = query.Where(p => p.SoporteId == soporte.SoporteId);
                }
                return query.AsNoTracking().ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
