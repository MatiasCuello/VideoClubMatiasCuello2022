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
            try
            {
                var peliculaIdDb = context.Peliculas.SingleOrDefault(p => p.PeliculaId == peliculaId);
                if (peliculaIdDb == null)
                {
                    throw new Exception("El codigo de la pelicula es inexistente");
                }

                context.Entry(peliculaId).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pelicula pelicula)
        {
            try
            {
                return context.Peliculas
                    .Any(p => p.PeliculaId == pelicula.PeliculaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Pelicula pelicula)
        {
            try
            {
                if (pelicula.PeliculaId == 0)
                {
                    return context.Peliculas
                        .Any(p => p.Titulo == pelicula.Titulo);
                }

                return context.Peliculas.Any(p => p.Titulo == pelicula.Titulo &&
                                                    p.GeneroId != pelicula.GeneroId &&
                                                    p.DuracionEnMinutos != pelicula.DuracionEnMinutos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(object pelicula)
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
            try
            {
                if (pelicula.PeliculaId == 0)
                {
                    context.Peliculas.Add(pelicula);
                }
                else
                {
                    var peliculaInDb = context.Peliculas.SingleOrDefault(p => p.PeliculaId == pelicula.PeliculaId);
                    if (peliculaInDb == null)
                    {
                        throw new Exception("El codigo de la Pelicula es inexistente");
                    }

                    peliculaInDb.Titulo = pelicula.Titulo;
                    peliculaInDb.GeneroId = pelicula.GeneroId;
                    peliculaInDb.FechaIncorporacion = pelicula.FechaIncorporacion;
                    peliculaInDb.EstadoId = pelicula.EstadoId;
                    peliculaInDb.DuracionEnMinutos = pelicula.DuracionEnMinutos;
                    peliculaInDb.CalificacionId = pelicula.CalificacionId;
                    peliculaInDb.Activa = pelicula.Activa;

                    context.Entry(pelicula).State = EntityState.Modified;

                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
