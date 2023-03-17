using Aplicacion.Wrappers.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Feautres.Libros.Consultas.OctenerTodosLibros
{
    public class OctenerTodosLibrosParametros : RespuestaParametros
    {
        public string? TituloLibro { get; set; }
    }
}
