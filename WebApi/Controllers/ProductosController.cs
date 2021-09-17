using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Productos;
using MediatR;
using Dominio;


namespace WebApi.Controllers
{
   //http://localhost:5002/api(controller)
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
       public ProductosController(IMediator mediator) {
            _mediator=mediator;
       }
        

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
           
           return await _mediator.Send(new Consulta.ListaProductos());

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>>Detalle(int id)
        {
           return await _mediator.Send(new ConsultaId.ConsultaUnica{Id=id});

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Creacion.Ejecuta data)
        {

           return  await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data)
        {
            data.Id=id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id){
           return await _mediator.Send(new Eliminar.Ejecuta{ productoId=id });
        }


        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
          //  List<string>lst= new List<string>();
            //lst.Add("hola controller  con entity");
            //return lst;
        //}
    }
}
