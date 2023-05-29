namespace Module_10_Final{


    // Интерфейс ICalculator со методом Sum
    public interface ICalculator{ 
        int Sum(int a, int b); }

    // Класс Calculator, реализующий интерфейс ICalculator
    public class Calculator : ICalculator{
        // Реализация метода Sum для вычисления суммы двух чисел
        public int Sum(int a, int b) { return a + b; }
    }

    // Интерфейс ILogger со методами Event и Error
    public interface ILogger{
        void Event(string _message);
        void Error(string _message);
    }

    // Класс Logger, реализующий интерфейс ILogger
    public class Logger : ILogger{
        // Реализация метода Event для записи сообщения о событии в лог
        public void Event(string _message){
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(_message);
            Console.ResetColor();
        }

        // Реализация метода Error для записи сообщения об ошибке в лог
        public void Error(string _message){

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_message);
            Console.ResetColor();
        }
    }
    public class Program{
        public static void Main(string[] args){

            ICalculator _myCalculator = new Calculator(); 
            ILogger _logger = new Logger();

            while (true){

                Console.WriteLine("Ведите первое слогаемое:");
                var _firstInput = Console.ReadLine();

                Console.WriteLine("Введите второе слогаемое:");
                var _secondInput = Console.ReadLine();

                int a;
                int b;

                try{
                    a = int.Parse(_firstInput);
                    b = int.Parse(_secondInput);
                }
                catch (FormatException){
                    _logger.Error("Не верный формат ввода, повторите ввод");
                    continue;
                }
                finally{

                }

                // Вычисление суммы чисел с помощью объекта calculator и вывод результата
                int _sum = _myCalculator.Sum(a, b);
                Console.WriteLine("Сумма: " + _sum);

                // Запись события в лог с помощью объекта logger
                _logger.Event("Сумма чисел = "  + _sum);
            }
        }
    }
}