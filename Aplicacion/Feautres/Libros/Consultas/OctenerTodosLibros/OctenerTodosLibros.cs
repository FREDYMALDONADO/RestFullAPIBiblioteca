using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Aplicacion.Wrappers.Especificaciones;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Feautres.Libros.Consultas.OctenerTodosLibros
{
    public class OctenerTodosLibros : IRequest<PaginadorRespuesta<List<Librodto>>>
    {
        public string TituloLibro { get; set; }
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
       

        public class OctenerTodosLibrosHandler : IRequestHandler<OctenerTodosLibros, PaginadorRespuesta<List<Librodto>>>
        {
            private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono;
            private readonly IMapper _mapper;

            public OctenerTodosLibrosHandler(IRepositorioAsincrono<Libro> repositorioAsincrono, IMapper mapper)
            {
                _repositorioAsincrono = repositorioAsincrono;
                _mapper = mapper;
            }



            public async Task<PaginadorRespuesta<List<Librodto>>> Handle(OctenerTodosLibros request, CancellationToken cancellationToken)
            {
                var libros = await _repositorioAsincrono.ListAsync(new PaginaLibroEspecificacion(request.TamanioPagina, request.NumeroPagina,request.TituloLibro));
                var librodto = _mapper.Map<List<Librodto>>(libros);


                return new PaginadorRespuesta<List<Librodto>>(librodto, request.NumeroPagina, request.TamanioPagina);
            }
        }
    }
}
