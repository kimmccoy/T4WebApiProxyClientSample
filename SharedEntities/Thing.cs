using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities
{
    public class Thing
    {
        public Thing()
        {
            Whatsits = new List<Whatsit>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public List<Whatsit> Whatsits { get; set; }
    }

}
