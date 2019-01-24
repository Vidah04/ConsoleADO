using Bootcamp.CRUD.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Model
{
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset DateIn { get; set; }
       

    }
}
