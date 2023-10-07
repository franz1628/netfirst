using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Transversal.Utilidades
{
    public abstract class PaginationInfoFilter
    {
        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public int draw { get; set; } = 1;

    }
}
