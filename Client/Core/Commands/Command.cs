﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    [DataContract]
    public class Command
    {
        [DataMember]
        public int Id { get; set; }
    }
}
