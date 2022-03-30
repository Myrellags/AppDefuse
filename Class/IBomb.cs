using System.Collections.Generic;

namespace AppDefuse.Class
{
    public interface IBomb
    {
        int Status { get; set; }
        List<string> Wires { get; set; }
        IDefuse Defuse { get; set; }
    }
}