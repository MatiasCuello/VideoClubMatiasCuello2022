using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios;
using VideoClub.Repositorios.Repositorios.Facades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioSoportes
    {
        private readonly IRepositorioSoportes repositorio;

        public ServicioSoportes()
        {
            repositorio = new RepositorioSoportes();
        }
        public List<Soporte> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
