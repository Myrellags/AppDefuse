using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDefuse.Class
{
    public class Bomb : IBomb
    {
        public int Status { get; set; }
        public List<string> Wires { get; set; }
        public IDefuse Defuse { get; set; } = new Defuse();
    }
}
