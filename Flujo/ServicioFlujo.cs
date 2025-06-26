using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class ServicioFlujo : IServicioFlujo
    {
        private readonly IServicioDA _servicioDA;

        public ServicioFlujo(IServicioDA servicioDA)
        {
            _servicioDA = servicioDA;
        }

        public async Task<IEnumerable<Servicio>> ListarServiciosAsync()
        {
            return await _servicioDA.ListarServiciosAsync();
        }
    }
}
