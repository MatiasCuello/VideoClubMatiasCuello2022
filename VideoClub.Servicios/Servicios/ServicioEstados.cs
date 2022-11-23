using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;
using VideoClub.Repositorios.Repositorios;
using VideoClub.Repositorios.Repositorios.Facades;
using VideoClub.Servicios.Servicios.Facades;

namespace VideoClub.Servicios.Servicios
{
    public class ServicioEstados:IServicioEstados
    {
        private readonly IRepositorioEstados repositorio;

        public ServicioEstados()
        {
            repositorio = new RepositorioEstados();
        }
        public List<Estado> GetLista()
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
