using System.Runtime.CompilerServices;

namespace Module9._2
{
    class MyException : Exception
    {
        public MyException(string message = "myException") : base(message)
        {

        }
    }
    public class Program
    {
        public  delegate void SortA();  // делегат
        public static event SortA StartSort; // событие
        static List<string> surname = new List<string>()
        {
            "Иванова",
            "Смирнов",
            "Соболев",
            "Енисеев",
            "Шишкин"
        };
        public static  void SortAsc()
        {
            surname.Sort();
        }
        public static  void SortDesc()
        {
            surname.Sort();
            surname.Reverse();
        }
        static void Print()
        {
            foreach(string s in surname)
                Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            {
                                StartSort += SortAsc;
                                break;
                            }
                        case 2:
                            {
                                StartSort += SortDesc;
                                break;
                            }
                        default:
                            {
                                throw new MyException("Введите 1 или 2");
                            }
                    }
                    StartSort?.Invoke();
                    Print();
                    Console.ReadKey();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}