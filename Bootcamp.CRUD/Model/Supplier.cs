using Bootcamp.CRUD.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    
    public class Supplier : BaseModel
    {
        public static string Name { get; internal set; }
        public string name { get; set; }

        public DateTimeOffset JoinDate { get; set; }
    }
}
