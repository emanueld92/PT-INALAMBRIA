using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.ApplicationServices.Ordering
{
    public class DominoServices : IDominoServices
    {
 

        List<string> IDominoServices.OrderDomino(List<string> fichas)
        {

            List<string> result = new List<string>();




            
            string firstDomino = fichas[0];
            result.Add(firstDomino);
            fichas.Remove(firstDomino);

            while (fichas.Count > 0)
            {
                foreach(var ficha in fichas)
                {
                    var Ultima = result.Last();
                    if (Ultima[3] == ficha[1])
                    {
                        result.Add(ficha);
                        fichas.Remove(ficha);
                        break;

                    }
                    else if (Ultima[3] == ficha[3])
                    {
                        var invertida = $"[{ficha[3]}|{ficha[1]}]";
                        result.Add(invertida);
                        fichas.Remove(ficha);
                        break;
                    }
                    
                    
                
                };

                ////string nextDomino = fichas.FirstOrDefault(s => s.StartsWith($"[{result.Last().Split('|')[1]}|") || s.EndsWith($"|{result.Last().Split('|')[1]}]"));
                //if (nextDomino != null)
                //{
                //    result.Add(nextDomino);
                //    fichas.Remove(nextDomino);
                //}
                //else
                //{
                //    break;
                //}
            }

            if (fichas.Count > 0)
            {
                Console.WriteLine("No se pueden ordenar las fichas según la condición dada.");
                
            }
            else
            {
                Console.WriteLine($"[{string.Join("],[", result)}]");
            }


            return (result);
        }
    }
}
