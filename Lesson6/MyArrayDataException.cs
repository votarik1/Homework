using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class MyArrayDataException: Exception
    {

        public int i { get; }
        public int j { get; }

        public MyArrayDataException(int I, int J)
        {

            i = I;
            j = J;

        }


    }
}
