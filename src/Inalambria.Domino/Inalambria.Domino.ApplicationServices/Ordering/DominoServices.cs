using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            if(fichas == null || fichas.Count()<2 || fichas.Count()>6)
            {
                return new List<string>();
            }
            (List<string> FichasValid, bool valid) = ListValid(fichas);
          

       
            string firstDomino = FichasValid[0];

            if(valid)
            {
                result.Add(firstDomino);
                FichasValid.Remove(firstDomino);

                while (FichasValid.Count > 0)
                {
                    foreach(var ficha in FichasValid)
                    {
                        var Ultima = result.Last();
                        if (Ultima[3] == ficha[1])
                        {
                            result.Add(ficha);
                            FichasValid.Remove(ficha);
                            break;

                        }
                        else if (Ultima[3] == ficha[3])
                        {
                            var invertida = $"[{ficha[3]}|{ficha[1]}]";
                            result.Add(invertida);
                            FichasValid.Remove(ficha);
                            break;
                        }             
                    };

                }

                return (result);
            }
            else
            {
                return new List<string>();
            }

        }

        public (List<string>, bool) ListValid(List<string> fichas)
        {
            Boolean ok = false;
            Boolean valid = false;
            Boolean doubles = false;
            Boolean doublesValid = true;
            List<string> CountPair = new List<string>();
            List<string> listaValid = fichas.ToList();
            foreach (string element in fichas)
            {
                string[] n = element.Replace("[", "").Replace("]", "").Split("|");
                CountPair.Add(n[0]);
                CountPair.Add(n[1]);
            }

            foreach( var f in fichas)
            {
                if (f[1] == f[3])
                {
                    doubles = true;
                    if ( CountPair.Count(x => x.Contains(f[1]))>3)
                    {
                        int index = fichas.IndexOf(f);

                        listaValid.RemoveAt(index);
                        listaValid.Insert(0, f); 

                    }
                    else
                    {
                        doublesValid = false;
                        
                    }
                }
            }
            foreach (var i in CountPair)
            {
                if (CountPair.Count(x => x.Contains(i)) % 2 == 0)
                {
                    valid = true;

                }
                else
                {
                    valid = false;
                    break;
                }

            }


            if(valid && doubles && doublesValid)
            {
                ok = true;
            }
            if (valid && !doubles && doublesValid)
            {
                ok = true;
            }
           
            return (listaValid, ok);
        }
    }
}
