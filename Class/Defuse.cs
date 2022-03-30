using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDefuse.Class
{
    public class Defuse : IDefuse
    {
        /// <summary>
        ///     Defuse Bomb
        /// </summary>
        /// <param name="bomb"></param>
        /// <returns></returns>
        public int DefuseBomb(IBomb bomb)
        {
            try
            {
                string current = bomb.Wires.Last(); ;
                string previos = null;
                int total = bomb.Wires.Count;
                if (total > 1)
                    previos = bomb.Wires[total - 2];
                
                if(previos != null)
                {
                    string result = string.Join(",", bomb.Wires);
                    if (((previos == "BRANCO") && ((current == "BRANCO") || (current == "PRETO"))) ||
                        ((previos == "VERMELHO") && (current != "VERDE")) ||
                        ((previos == "PRETO") && ((current == "BRANCO") || (current == "VERDE") || (current == "LARANJA"))) ||
                        ((previos == "LARANJA") && ((current == "BRANCO") || (current == "ROXO") || (current == "VERDE"))) ||
                        ((previos == "VERDE") && ((current == "ROXO") || (current == "PRETO") || (current == "VERMELHO"))) ||
                        ((previos == "ROXO") && ((current == "ROXO") || (current == "VERDE") || (current == "LARANJA") || (current == "BRANCO"))))
                    {
                        return 2; //Exploded
                    }
                    else if ((result.Contains("BRANCO,VERMELHO,VERDE")) || (result.Contains("VERDE,VERMELHO,VERDE")))
                    {
                        return 0; //Inactive
                    }
                    else
                    {
                        return 1; //Active
                    }

                }
                else
                    return 1; //Active
            }
            catch
            {
                throw new ArgumentException(Resource.Results.Invalid, nameof(bomb));
            }
        }
    }
}