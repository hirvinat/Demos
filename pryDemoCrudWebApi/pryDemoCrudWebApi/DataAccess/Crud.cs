using Microsoft.EntityFrameworkCore;
using pryDemoCrudWebApi.Interface;
using pryDemoCrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pryDemoCrudWebApi.DataAccess
{
    public class Crud : ICrud

    {

        dbtestContext db;
        public Crud(dbtestContext _db)
        {
            db = _db;
        }

        public async Task<int> DeleteCliente(int id)
        {
            int rsValue = 0;
            try
            {   
                var result = await db.Tbcliente.SingleOrDefaultAsync(a => a.Id == id);

                if (result != null)
                {
                    db.Tbcliente.Remove(result);

                    rsValue = await db.SaveChangesAsync();
                }

                return rsValue;

            }
            catch (Exception)
            {
                return rsValue;
            }
        }

        public async Task<Tbcliente> GetCliente(int id)
        {
            try
            {
               
                var cliente = (from a in db.Tbcliente
                                   where a.Id == id
                                   select a).SingleOrDefaultAsync();

                return await cliente;
                
            }
            catch (Exception)
            {
                Tbcliente cleinte = new Tbcliente();
                return cleinte;
            }
        }

        public async Task<List<Tbcliente>> GetClientes()
        {
            try
            {

                    var lstClientes = (from a in db.Tbcliente
                                       select a).ToListAsync();

                    return await lstClientes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tbcliente> PostCliente(int id, string nombres, string apellidos, int edad, string direccion, string celular, string correo)
        {
            try
            {
                
                var result = await db.Tbcliente.SingleOrDefaultAsync(a => a.Id == id);
                if (result != null)
                {
                    result.Nombres = nombres;
                    result.Apellidos = apellidos;
                    result.Edad = edad;
                    result.Direccion = direccion;
                    result.Celular = celular;
                    result.Correo = correo;

                    await db.SaveChangesAsync();
                    result = await db.Tbcliente.SingleOrDefaultAsync(a => a.Id == id);
                }

                return result;


                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> PutCliente(string nombres, string apellidos, int edad, string direccion, string celular, string correo)
        {
            try
            {
                
                
                Models.Tbcliente nuevoCliente = new Models.Tbcliente();

                nuevoCliente.Nombres = nombres;
                nuevoCliente.Apellidos = apellidos;
                nuevoCliente.Edad = edad;
                nuevoCliente.Direccion = direccion;
                nuevoCliente.Celular = celular;
                nuevoCliente.Correo = correo;

                await db.Tbcliente.AddAsync(nuevoCliente);
                await db.SaveChangesAsync();
                var result = await db.Tbcliente.SingleOrDefaultAsync(a => a.Correo == correo);


                return result.Id;
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
