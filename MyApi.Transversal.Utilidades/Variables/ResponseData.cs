using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSalud.Transversal.Utilidades.Variables
{
    public class ResponseData
    {
        public int code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
}
