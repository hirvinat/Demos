using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pryDemoCrudWebApi.Interface;

namespace pryDemoCrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        ICrud oICrud;
        public ClientesController(ICrud _crud)
        {
            oICrud = _crud;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {

            try
            {
                var lstClientes = await oICrud.GetClientes();
                if (lstClientes == null)
                {
                    return NotFound();
                }

                return Ok(lstClientes);

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetCliente")]
        public async Task<ActionResult> GetCliente(int id)
        {
            try
            {
                var cliente = await oICrud.GetCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("PutCliente")]
        public async Task<IActionResult> PutCliente(string nombres, string apellidos, int edad, string direccion ,string celular, string correo )
        {

            try
            {
                var _exito = await oICrud.PutCliente(nombres, apellidos, edad, direccion, celular, correo);
                if (_exito == 0)
                {
                    return NotFound();
                }

                return Ok(_exito);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpPost]
        [Route("PostCliente")]
        public async Task<IActionResult> PostCliente(int id, string nombres, string apellidos, int edad, string direccion, string celular, string correo)
        {

            try
            {
                var _exito = await oICrud.PostCliente(id, nombres, apellidos, edad, direccion, celular, correo);
                if (_exito == null)
                {
                    return NotFound();
                }

                return Ok(_exito);


            }            
            catch (Exception)
            {

                return BadRequest();
            }

        }


        [HttpDelete]
        [Route("DeleteCliente")]
        public async Task<ActionResult> DeleteClienteAsync(int id)
        {
            try
            {
                var _exito = await oICrud.DeleteCliente(id);
                if (_exito == 0)
                {
                    return NotFound();
                }

                return Ok(_exito);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }



    }
}