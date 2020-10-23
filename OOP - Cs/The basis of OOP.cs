using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Cs
{
    class Public  // это некорректное имя, нужно чисто для показательности
    {
        public int id; // Открытое для взаимодействия поле. Так делать НЕ надо - все поля наших классов д.б. ЗАКРЫТЫ.
      
        public void Show() // Открытый для взаимодействия метод
        {
            Console.WriteLine(" Это {0}-й номер ", id); // Вывод содержимого поля класса на консоль
        }
    }


    /*  Инкапсюляция: механизм в ООП, позволяющий связать данные с методами
                      и скрыть их от внешнего воздействия. 
        Инкапсюляция содержит сокрытие, но им НЕ является.  */
    class Private
    {
        private int zu; // Закрытое для внешнего взаимодействия поле 
        int pu; // если члену классу не присваивать мод-р доступа, то по умолчанию он будет private

        private void Show() // Закрытый для внешнего взаимодействия метод
        {
            Console.WriteLine(" Это {0} номер и номер {1} ", zu, pu); // Вывод содержимого поля класса на консоль
        }
    }



    // Открытые поля - плохо - могут быть допущены ошибки, приводящие всю программу в неисправность.
    
    /*2) Способ  для большинства ЯП, включая C#:
      делать для каждого поля 2 метода: один-для записи в поле, другой-для чтения из поля */
    class Human
    {
        private int age;

        public int GetAge() 
        {
            return age;
        }

    public void SetAge(int value)
        {
            if (value > 0) // элегантнее было бы использовать "switch-case", но    ┐(￣ヮ￣)┌
            {
                age = value;
                Console.WriteLine($" Возраст человека = {age} .");
            }
            else if (value == 0)
            {
                Console.WriteLine(" Хороший будет человек. ");
            }
            else
            {
                Console.WriteLine(" Хороший был человек... ");
            }
        }

        //1) Способ для C#-бояр: 
        public int Age
        {
            get                // блок для чтения из поля
            {
                return age;
            }
            set                // блок для записи в поле
            {
                if(value > 0)
                {
                    age = value;
                    Console.WriteLine($" Возраст человека = {age} .");
                }
            }
        }
    }

///////////////          НАСЛЕДОВАНИЕ 

    class HomoSapiens
    {
        public int Vozr { set; get; }       //свойства класса (они-то как раз м.б. public)
        public string Sex { set; get; }
        public string Name { set; get; }
        

        public HomoSapiens() { } // если КОНСТРУКТОР в классе НЕ объявлен, то по умолчанию счит-ся, что там уже есть пустой К-Р
        // А если указан К-Р с параметрами И при этоя явно НЕ указан ПУСТОЙ К-Р, то счит-ся, что ПУСТОГО К-РА по Дефолту НЕТ
        public HomoSapiens(string name) 
        {
            Name = name;
        }
        public HomoSapiens(string name, int age) : this(name) // при помощи кл.сл. this мы можем вызывать перегруженный К-Р и передавать ему Аргументы ТЕКУЩЕГО К-РА
        {
            Vozr = age;
        }


        public void LetsToTalk()
        {
            Console.WriteLine(" Здравствуйте, я - нормальная ячейка общества.");
        }
    }

    class Programmer : HomoSapiens
    {
        public Programmer() { } // пустой К-Р

        public string YaP { get; set; }
        public Programmer(string name, int age, string yap) : base(name, age) // аргументы К-РА ДАННОГО класса передаются в К-Р РОД-КОГО класса 
        {
            YaP = yap;
        }

        
    }

    class Boozer : HomoSapiens
    {
        private int liver; // это печень только ДАННОГО алкаша и ничья больше (ему самому одной мало)
        protected float boyara; /* protected делает члены класса ОТКРЫТЫМИ для взаимодействия между НАСЛЕДНИКАМИ, но
        для ВНЕШНЕГО взаимодействия они всё ещё ЗАКРЫТЫ (Тоха поделится боярой с наследниками, но больше - ни с кем) */
        public void ShyasYaChuchuNamandryuchu()
        {
            Console.WriteLine(@" Дядя Тоха: ""А? Кокие вы там фУмЯнистки?"" ");
        }
    }
}

///////////////          Полиморфизм (подтипов)

class Animal
{
    public string Name { get; set; }

    public virtual void GetRoar()
    {
        Console.WriteLine($" \n Животное {Name} говорит:");
        Console.WriteLine(" Боевой клич ");
    }
}

class Teammate : Animal
{
    public override void GetRoar()
    {
        Console.WriteLine($" \n Животное {Name} говорит:");
        Console.WriteLine(" The Impostor is Red! ");
    }
}

class Groupmate : Animal
{
    public override void GetRoar()
    {
        Console.WriteLine($" \n Животное {Name} говорит:");
        Console.WriteLine(" Ля, я валю с шестой пары ");
    }
}

class Boozer1 : Animal
{
    public override void GetRoar()
    {
        Console.WriteLine($" \n Животное {Name} говорит:");
        Console.WriteLine(" Отец, пять рублей не найдётся? ");
        base.GetRoar();
    }
}

////////////////////////////// Ad Hoc - Полиморфизм:

class AdHoc
{
    public int GetMax(int a, int b)
    {
        return a > b ? a : b;    
    }
    public string GetMax(string a, string b) // перегрузка метода позволяет создавать методы с различными принимаемыми и возвращаемыми параметрами
    {
        return a.Length > b.Length ? a : b;
    }
    public int GetMax(params int[] args)
    {
        int result = args[0];
        
        for (int i = 0; i < args.Length; i++)
        {
            if (result < args[i])
            {
                result = args[i];
            }
        }

        return result;
    }
}

/////////////// Конструктор - инициализирующий метод класса 
class Constructor
{
    private int field;

    public Constructor() // конструктор НЕ принимает никаких параметров
    {
        field = 7;
        
    }

    public void Show()
    {
        Console.WriteLine(field);
    }

    // лезем в класс HomoSapiens

}
