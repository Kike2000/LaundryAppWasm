using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.ModelValidations
{
    internal class EmployeeValidationModel : BaseUserValidationModel
    {
        public string Nombre { get; set; }
    }
}
