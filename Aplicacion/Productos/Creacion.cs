using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Productos
{
    public class Creacion
    {
        public class Ejecuta:IRequest
        {
            public string nombreProducto{ get; set;}
            public string descripcionProducto {get;set;}

        }

        public class Administrador:IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;

            public Administrador(TiendaContext context)
            {
                _context=context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto= new Producto
                {
                   nombreProducto=request.nombreProducto,
                   descripcionProducto=request.descripcionProducto
                };

                _context.Producto.Add(producto);

                var valor= await _context.SaveChangesAsync();

                if(valor>0){
                    return Unit.Value;
                }else
                {
                    throw new System.Exception("no se inserto el producto");
                }

            }

            
        }


    }
}