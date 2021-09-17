using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;

namespace Aplicacion.Productos
{
    public class Editar
    {
        public class Ejecuta:IRequest
        {
             public string nombreProducto{ get; set;}
            public string descripcionProducto {get;set;}

            public int Id {get;set;}

            
        }
        public class Administrador:IRequestHandler<Ejecuta>
        {
            public readonly TiendaContext _context;

            public Administrador(TiendaContext context)
            {

                _context=context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto= await _context.Producto.FindAsync(request.Id);
                if(producto== null){
                    throw new Exception("El curso no existe");

                }

                 producto.descripcionProducto=request.descripcionProducto??producto.descripcionProducto;
                    producto.nombreProducto=request.nombreProducto?? producto.nombreProducto;
                    var result=await _context.SaveChangesAsync();

                     if(result>0) {
                     return Unit.Value;
                    }

                      throw new System.Exception("no se guardaron los cambios en el curso");

            }
            

        }


    }
}