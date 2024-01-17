using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface ISystemUser
    {
        Guid Id { get; set; }
        Int64 Dni { get; set; }
        string Provincia { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
    }
}
