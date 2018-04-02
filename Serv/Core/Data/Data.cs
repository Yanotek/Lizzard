using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serv.Core.Data
{
    public class Data : Other.ViewModel
    {
        public static List<Models.Client> Clients { get; set; } = new List<Models.Client>();


    }
}
