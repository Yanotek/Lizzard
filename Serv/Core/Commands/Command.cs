using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serv.Core.Commands
{
    public interface ICommand
    {
        int Id { get; set; }
    }
}
