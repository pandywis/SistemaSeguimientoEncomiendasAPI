using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSeguimientoEncomiendas.Application.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}