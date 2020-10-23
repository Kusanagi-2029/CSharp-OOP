using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Cs
{
    class Program
    {
        // 4) Объявление делегата, ссылающегося на функцию
        // с двумя параметрами и целочисленным результатом
        public delegate int AddDelegate(int num1, int num2);

        static void Main(string[] args)
        {
            Console.WriteLine("   My first class in C# ");
         // My first class in C#:
            int result;
               NumManipulator numManipulator = new NumManipulator();

               Console.WriteLine(" Введите значения А и B: ");
               string x = Console.ReadLine();
               int a = Convert.ToInt32(x);
               string y = Console.ReadLine();
               int b = Convert.ToInt32(y);

               result = numManipulator.FindMax(a, b);

               Console.WriteLine($" Максимальный элемент: " + result + "\n\t");

            Console.WriteLine("   access modifiers: ");
      // access modifiers

         //Public:
            Public num = new Public();
            num.id = 7;               // изменяем знач-е открытого поля
            num.Show();               // вызываем открытый метод

            Console.WriteLine("                         1)  Инкапсюляция: ");
      //1) Инкапсюляция:
         //Private:
         // Ничего не вызывается, ведь данные закрыты от внешнего воздействия, - Инкапсюляция

            Human human = new Human();
            human.SetAge(-75); // 2-ой способ закрывания поля
            human.Age = 52;    // 1-ый способ, 1) записываем значение в поле при помощи свойства

            Console.WriteLine("\n                         2)  Наследование: ");
      //2) Наследование:
            Boozer Toha = new Boozer();
            Toha.Vozr = 57;
            Toha.Sex = "Гендерфлюидный боевой вертолёт";
            Toha.Name = "дядя Тоха";
            Toha.ShyasYaChuchuNamandryuchu();

      // UPCAST:
            HomoSapiens man = Toha; /* экземпляр класса "Алкаш" мы привели к э.кл. "Человек", и теперь можно исп-ь 
           методы класса "Человек", но нельзя - методы класса "Алкаш", хоть они и никуда не деваются (лишь скрыты).
        это UPCAST - операция приведения конкретного типа к общему */
            Console.WriteLine(" \n  UPCAST: ");
            man.LetsToTalk();

      // DOWNCAST: (возможен <=> экз.кл. "Человек" уже был когда-то экз.кл. "Алкаш", как наш Toha).
         //1:
            HomoSapiens chelovek = Toha;
            Boozer boozer = (Boozer)chelovek;
            Console.WriteLine("   Downcast №1: ");
            boozer.ShyasYaChuchuNamandryuchu();
            


            //2.1: is - проверяет, явл-ся ли Объект указанным типом. Если да - True, нет - False
            HomoSapiens isMan = Toha;
            bool isBoozer = isMan is Boozer;
            if (isBoozer)
            {
                Boozer alcoman = (Boozer)isMan; // классическое приведение типа
                Console.WriteLine("   Downcast №2.1: is ");
                alcoman.ShyasYaChuchuNamandryuchu();
            }

         //2.2: в С# 7 расширили оператор is и добавили шаблоны сопоставления
            HomoSapiens isChel = Toha;
            if (isChel is Boozer alkash)
            {
                Console.WriteLine("   Downcast №2.2: is C#7 ");
                alkash.ShyasYaChuchuNamandryuchu();
            }    

         //3: as - 1) проверяет Объект на соответствие типу, 2) as приводит О-т к этому типу
            // в случае, если О-т НЕ имеет ничего общего с указанным типом, вместо исключения получим NULL в результате
            HomoSapiens istMann = Toha;
            Boozer branntweiner = istMann as Boozer;
            if(branntweiner != null)
            {
                Console.WriteLine("   Downcast №3: as ");
                branntweiner.ShyasYaChuchuNamandryuchu();
            }

            Console.WriteLine("\n                         3)  Полиморфизм: ");
      //3) Полиморфизм

            Animal[] animals = new Animal[3];

            Teammate teammate = new Teammate();
            teammate.Name = "NagEbator591185719857231";

            Groupmate groupmate = new Groupmate();
            groupmate.Name = "Jorik";

            Boozer1 boozer1 = new Boozer1();
            boozer1.Name = "Toha";

            animals[0] = teammate;
            animals[1] = groupmate;
            animals[2] = boozer1;

            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].GetRoar();
            }

            // Upcast:
            Boozer1 boozer2 = new Boozer1();
            boozer2.Name = " Безымянный ";

            Animal animal = boozer2; // в animal всё равно хранится экз.кл. Boozer1, хоть мы с ним и обращаемся, как с Animal
            animal.GetRoar(); // перекрыли базовую реализацию метода GetRoar(), т.е. вызвали переопределённый метод GetRoar() класса Boozer1



            Console.WriteLine("\n                     3.1)  Ad Hoc - Полиморфизм: ");
      // Ad Hoc - Полиморфизм - с перегрузкой метода!

            AdHoc adHoc = new AdHoc();
            Console.WriteLine(adHoc.GetMax(175, 2)); //175
            Console.WriteLine(adHoc.GetMax(" Ad ", " Hoc ")); // Слово "Hoc" длиннее слова "Ad", => "Hoc"
            Console.WriteLine(adHoc.GetMax(1, 47, 23, 21, 1, 4, 56, 0, 7, 4, 34, 2, 1, 15, 6, 47, 14));
            int[] arr = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(adHoc.GetMax(arr));

            Console.WriteLine("\n             Конструкторы: ");
            // С применением КОНСТРУКТОРОВ:
            Programmer Ren = new Programmer();
            Ren.Name = "Ренат";
            Ren.Vozr = 22;
            Ren.Sex = " Male";
            Ren.YaP = " C#, C++, JS, SQL, Dart2";
            Console.WriteLine($"\n\tName: {Ren.Name}, \n\tAge: {Ren.Vozr}, \n\tSex: {Ren.Sex}, \n\tStack: {Ren.YaP} \n");



            Console.WriteLine("\n                         4) Делегаты: ");
         // 4) Делегаты:
            /*  Делегат ссылается на метод и после назначения метода ведёт себя идентично ему. 
                Делегат можно использовать как любую функцию с параметром и возвращаемым значением.

           - делегаты нечувствительны к ошибкам ввода;
           - объектно-ориентированы;
           - безопасны.
              
            Делегаты C# обладают следующими свойствами:

            - позволяют обрабатывать методы в качестве аргумента;
            - могут быть связаны вместе;
            - несколько методов могут быть вызваны по одному событию;
            - тип делегата определяется его именем;
            - не зависят от класса объекта, на который ссылается;
            - сигнатура метода должна совпадать с сигнатурой делегата.     */

            // Создание метода делегата и передача функции Add в качестве аргумента
            AddDelegate funct1 = new AddDelegate(Add);
            // Вызов делегата
            int k = funct1(70, 30);
            Console.WriteLine("Sumalation = {0}", k);



            Console.WriteLine("\n                         5) События: ");
         // 5) События (events):
            /*  События сигнализируют системе о том, что произошло определенное действие.
                И если нам надо отследить эти действия, то как раз мы можем применять события.*/

            Events acc = new Events(100);
  /*5*/     acc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            acc.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}"); // 120
            acc.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}"); // 50
            acc.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}"); // 50 < 180 => 50


            Console.WriteLine("\n\n     Нажмите любую клавишу для завершения. Доброго дня, не болейте. ");
            Console.ReadKey();
        }



        static void HumanMethod(Human human)
        {
            int age = human.Age; // 1-ый способ, 2) считываем значение поля при помощи свойства
        }

        // 4) Делегаты:

        // Статическая функция Add с той же сигнатурой, что и у делегата:
        public static int Add(int num1, int num2)
        {
            Console.WriteLine("I was called by Delegate");
            int sumation;
            sumation = num1 + num2;
            return sumation;
        }


        // 5) События (Events): 
  /*4*/ private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}



