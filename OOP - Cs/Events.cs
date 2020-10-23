using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Cs
{
    class Events
    {
  /*1*/ public delegate void AccountHandler(string message);
  /*2*/ public event AccountHandler Notify;              // 1.Определение события
        public Events (int sum) // Конструктор (т.е. инициализирующий метод класса/структуры).
        {
            Sum = sum;
        }
        public int Sum { get; private set; } 
        public void Put(int sum)
        {
            Sum += sum;
  /*3*/     Notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
  /*3*/         Notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
  /*3*/         Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }
}
