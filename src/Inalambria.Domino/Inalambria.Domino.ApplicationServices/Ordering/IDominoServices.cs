using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inalambria.Domino.ApplicationServices.Ordering
{
    public interface IDominoServices
    {

        public List<string> OrderDomino(List<string> fichas);
    }
}
