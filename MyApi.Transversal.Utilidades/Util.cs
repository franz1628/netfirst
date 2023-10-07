using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Transversal.Utilidades
{
    public class Util
    {
        public static int CalcularEdad(DateTime nacimiento)
        {
            // throws un representable date time error
            //return DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            if (nacimiento > DateTime.Today)
                return 0;
            else
            {
                int edad = DateTime.Today.Year - nacimiento.Year;
                if (nacimiento > DateTime.Today.AddYears(-edad))
                    edad--;
                return edad;
            }
        }

        public static string FileSize(int bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
