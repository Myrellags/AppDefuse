using AppDefuse.Class;
using AppDefuse.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AppDefuse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            List<string> inputs = new List<string>();
            bool active = true;
            int status;

            if(active == true)
            {
                //Show the options
                Console.WriteLine("Escolha uma das opção abaixo para desarmar uma bomba:");
                foreach (var i in System.Enum.GetNames(typeof(Inputs)))
                {
                    Console.WriteLine($" {i}");
                }

                //Check wires list
                try
                {
                    //Create new Bomb object
                    var bomb = new Bomb();
                    bomb.Status = 1;

                    do
                    {
                        input = Console.ReadLine().ToUpper();
                        Inputs enumTypes;

                        //Check if input is valid
                        if (System.Enum.TryParse<Inputs>(input, true, out enumTypes))
                        {
                            inputs.Add(input);
                            bomb.Wires = inputs;
                            status = bomb.Defuse.DefuseBomb(bomb);

                            if (status == 0)
                            {
                                active = false;
                                Console.WriteLine(Resource.Results.Result03);
                            }
                            else if (status == 1)
                            {
                                active = true;
                                Console.WriteLine(Resource.Results.Result01);
                            }
                            else
                            {
                                active = false;
                                Console.WriteLine(Resource.Results.Result02);
                            }
                        } 
                        else
                        {
                            Console.WriteLine(Resource.Results.Invalid);
                        }

                    } while (active);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

    }
}
