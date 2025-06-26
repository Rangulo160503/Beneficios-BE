using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace DA.Repositorios
{
    public class ServicioDA : IServicioDA
    {
        private readonly IRepositorioDapper _repositorioDapper;

        public ServicioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
        }

        public async Task<IEnumerable<Servicio>> ListarServiciosAsync()
        {
            var query = @"SELECT Id, Nombre, Categoria, Fuente FROM Servicios";
            using var conexion = _repositorioDapper.ObtenerRepositorio();
            return await conexion.QueryAsync<Servicio>(query, commandType: CommandType.Text);
        }
    }
}
