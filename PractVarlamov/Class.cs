using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PractVarlamov
{
    public class Class
    {
        private int[] _mas;
        public Class(int[] mas) 
        {
            _mas = mas;
        }

        public bool Task()
        {
            int count = 0;
            for (int i = 0; i < _mas.Length; i++)
            {
                int j;
                for (j = 2; j <= Math.Sqrt(_mas[i]); j++)
                {
                    if (_mas[i] % j == 0) break;
                }
                if (j > Math.Sqrt(_mas[i]) && _mas[i] > 1)
                {
                    count++;
                }
            }

            if (count == _mas.Length)
            {
                return true;
            }
            else return false; 
        }
    }
}
