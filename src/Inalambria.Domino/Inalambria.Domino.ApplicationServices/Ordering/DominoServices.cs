using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.ApplicationServices.Ordering
{
    public class DominoServices : IDominoServices
    {
 

        List<string> IDominoServices.OrderDomino(List<string> fichas)
        {

            foreach(var f  in fichas)
            {
                Console.WriteLine(f[0]);
                Console.WriteLine(f[1]);
            }


            List<string> result = new List<string>(
                fichas


                ) ;
            



            return (result);
        }
    }
}
