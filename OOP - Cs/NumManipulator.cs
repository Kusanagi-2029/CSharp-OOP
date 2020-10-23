using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Cs
{
    class NumManipulator
    {
        public int FindMax(int first, int second)
        {
            int result; //здесь хранится наиб. число

            if(first > second)
            {
                result = first;
            }
            else
            {
                result = second;
            }

            return result;
        }
    }
}
