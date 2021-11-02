using System;

namespace Khlyzova_Valeria_PRI_117_lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторную работу выполнил");
            Console.WriteLine("студент группы ПРИ-117");
            Console.WriteLine("Хлызова Валерия");

            string user_command = "";
            bool Infinity = true;
            Man hero = null; 

            while (Infinity)
            {
                Console.WriteLine("\nПожалуйста, введите команду");
                user_command = Console.ReadLine();                      
                
                switch (user_command)
                {
                    case "help":
                        {
                            Console.WriteLine("\nСписок команд:");
                            Console.WriteLine("---");

                            Console.WriteLine("Основные команды: ");
                            Console.WriteLine("create_man : команда создает человека, (экземпляр класса Man)");
                            Console.WriteLine("info : команда выводит на экран информацию о человеке (если создан экземпляр класса)");
                            Console.WriteLine("kill_man : команда убивает человека (если создан экземпляр класса)");
                            Console.WriteLine("talk : команда застравляет человека говорить (если создан экземпляр класса)");
                            Console.WriteLine("go : команда застравляет человека идти (если создан экземпляр класса)\n");

                            Console.WriteLine("Команды при сражении: ");
                            Console.WriteLine("hit : нанести удар противнику");
                            Console.WriteLine("run : попытаться убежать от противника");
                            Console.WriteLine("yes : пощадить противника");
                            Console.WriteLine("no : уничтожить противника(((\n");

                            Console.WriteLine("---");
                            break;
                        }

                    case "create_man":
                        { 
                            Console.WriteLine("Пожалуйста, введите имя создаваемого человека");
                            user_command = System.Console.ReadLine();
                            hero = new Man(user_command);
                            Console.WriteLine("Человек успешно создан, его имя " + hero.getName() + "\n");
                            break;
                        }

                    case "info":
                        {
                            if (hero != null) hero.Info();
                            else Console.WriteLine("Человек не создан.");
                            break;
                        }

                    case "kill_man":
                        {
                            if (hero != null) hero.Kill();
                            else Console.WriteLine("Человек не создан. Вы не можете его убить");
                            break;
                        }

                    case "talk":
                        {
                            if (hero != null && hero.IsAlive()) Console.WriteLine("Человек не создан. Команда не может быть выполнена");
                            else Console.WriteLine("Человек не создан. Команда не может быть выполнена");
                            break;
                        }

                    case "go":
                        {
                            if (hero != null) hero.Go();
                            else Console.WriteLine("Человек не создан. Команда не может быть выполнена");
                            break;
                        }

                    case "exit":
                        {
                            Infinity = false;
                            Console.WriteLine("Приграмма завершена");
                            break;                            
                        }

                    default:
                        {
                            Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова");
                            Console.WriteLine("Для вывода списка команд введите команду help");
                            Console.WriteLine("Для завершения программы введите команду exit");
                            break;
                        }                

                }
            }
        }
    }
}
