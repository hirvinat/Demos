using pryDemoCrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pryDemoCrudWebApi.Interface
{
    public interface ICrud
    {
        Task<List<Tbcliente>> GetClientes();
        Task<Tbcliente> GetCliente(int id);

        Task<int> PutCliente(string nombres, string apellidos, int edad, string direccion, string celular, string correo);

        Task<Tbcliente> PostCliente(int id, string nombres, string apellidos, int edad, string direccion, string celular, string correo);

        Task<int> DeleteCliente(int id);


    }
}
