using System.Text;
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
    public class Eliminar
    {

         public class Ejecuta:IRequest
         {
             public int productoId {get;set;}
             
         }

         public class Administrador: IRequestHandler<Ejecuta>
         {
             private readonly TiendaContext _context;

             public Administrador(TiendaContext  context){
                 _context=context;
             }

             public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken){
                 
                 var producto= await _context.Producto.FindAsync(request.productoId);
                 if(producto== null)
                 throw new Exception("no de puede elminira este producto");
    
                  _context.Remove(producto);

                  var resultado= await _context.SaveChangesAsync();

                  if(resultado>0)
                     return Unit.Value;

                     throw new Exception("no se pudieron guardar los cambios");
             }


             
         }

        
    }
}