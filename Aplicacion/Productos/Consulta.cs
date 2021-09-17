using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class Consulta
    {
         public class ListaProductos:IRequest<List<Producto>> {}

        public class Administrador : IRequestHandler<ListaProductos, List<Producto>>
        {

            private readonly TiendaContext _context;
             public Administrador(TiendaContext context){
                 _context=context;
             }

            public async Task<List<Producto>> Handle(ListaProductos request, CancellationToken cancellationToken)
            {
                var cursos= await  _context.Producto.ToListAsync();
                return cursos;
            }


            
        }


    }
}