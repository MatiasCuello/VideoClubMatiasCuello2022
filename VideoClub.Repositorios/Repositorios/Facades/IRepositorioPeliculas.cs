﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades.Entidades;

namespace VideoClub.Repositorios.Repositorios.Facades
{
    public interface IRepositorioPeliculas
    {
        List<Pelicula> GetLista(Calificacion calificacion , Estado estado , Genero genero, Soporte soporte);
        void Guardar(Pelicula pelicula);
        bool Existe(Pelicula pelicula);
        void Borrar(int peliculaId);
        bool EstaRelacionado(Pelicula pelicula);
    }
}
