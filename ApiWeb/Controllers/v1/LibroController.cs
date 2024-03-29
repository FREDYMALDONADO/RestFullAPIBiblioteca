﻿using Aplicacion.Feautres.Libros.Comandos.CrearLibro;
using Aplicacion.Feautres.Libros.Comandos.EliminarLibro;
using Aplicacion.Feautres.Libros.Comandos.ModificarLibro;
using Aplicacion.Feautres.Libros.Consultas.ObtenerLibroPorId;
using Aplicacion.Feautres.Libros.Consultas.OctenerTodosLibros;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LibroController : BaseApiController
    {
        //Post 
        [HttpPost]
       public async Task<IActionResult> Post(CrearLibro comando)
        {
            return Ok(await Mediator.Send(comando));
        }

        //Put

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ModificarLibro comando)
        {
            if (id != comando.Id)
                return BadRequest();
            return Ok(await Mediator.Send(comando));


        }
        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            return Ok(await Mediator.Send(new EliminarLibro { Id= id}));


        }

        //get o select
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await Mediator.Send(new ObtenerLibroId { Id = id }));


        }


        //get all
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] OctenerTodosLibrosParametros filter)
        {

            return Ok(await Mediator.Send(new OctenerTodosLibros
            {
                NumeroPagina = filter.NumeroPagina,
                TamanioPagina = filter.TamanioPagina,
                TituloLibro = filter.TituloLibro


            }
             ));


        }

    }
}
