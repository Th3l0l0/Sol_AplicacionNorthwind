using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yo.Models
{
    public class ordenes_por_cliente
    {
        public int orderid { get; set; }
        public DateTime orderdate { get; set; }
        
        public int employeeid { get; set; }
    }
}