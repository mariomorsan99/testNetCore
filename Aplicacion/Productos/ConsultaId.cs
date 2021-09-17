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
    public class ConsultaId
    {

        public class ConsultaUnica:IRequest<Producto>
        {
            public int Id{get;set;}
        }

      public class Administrador : IRequestHandler<ConsultaUnica, Producto>
      {
          private readonly TiendaContext _context;

          public Administrador(TiendaContext context)
          {
              _context=context;

          }

          public async Task<Producto> Handle(ConsultaUnica request, CancellationToken cancellationToken)
          {
              var productoUnico=await _context.Producto.FindAsync(request.Id);
              return productoUnico;

          }




      }

    }
}