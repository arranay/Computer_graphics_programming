using System;
using System.Dynamic;

namespace Khlyzova_Valeria_PRI_117_lab_01
{
    class Man
    {
        private Random rnd = new Random();

        public Man(string _name)
        {
            Name = _name;
            isLife = true;
            Age = (uint)rnd.Next(15, 50);
            Health = (uint)rnd.Next(10, 100);
        }

        private string Name;
        private uint Age;
        private uint Health;
        private bool isLife;

        public string getName()
        {
            return Name;
        }

        public void Talk()
        {
            int random_talk = rnd.Next(1, 3);
            string tmp_str = "";

            switch (random_talk)
            {
                case 1:
                    {
                        tmp_str = "Привет, меня зовут " + Name + ", рад познакомиться";
                        break;
                    }
                case 2:
                    {
                        tmp_str = "Мне " + Age + ". А тебе?";

                        break;
                    }
                case 3:
                    {
                        if (Health > 50)
                            tmp_str = "Да я зводоров как бык!";
                        else
                            tmp_str = "Со здоровьем у меня хреново, дожить бы до " + (Age + 10).ToString();
                        break;
                    }
            }
            System.Console.WriteLine(tmp_str);
        }

        public void Go()
        {
            if (IsAlive())
            {
                if (Health > 40)
                {
                    string outString = Name + " мирно прогуливается по городу";
                    Console.WriteLine(outString);
                }
                else
                {
                    string outString = Name + " болен и не может гулять по городу";
                    Console.WriteLine(outString);
                }

                // Случайным образом генерируется схватка с противником
                if (rnd.Next() % 2 == 0) Fight();
            }
            else
            {
                string outString = Name + " не может идти, он умер";
                Console.WriteLine(outString);
            }
        }

        public bool IsAlive()
        {
            return isLife;
        }

        public void Kill()
        {
            isLife = false;
            Health = 0;
            Console.WriteLine(Name + " умер");
        }

        // Метод выводит информацию о созданном человеке
        public void Info()
        {
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Возраст: " + Age);
            Console.WriteLine("Здоровье: " + Health);
        }

        // Бой с противником
        private void Fight()
        {
            // Создаем противника со случайным значением здоровья
            uint enemy = (uint)rnd.Next(20, 70);
            // Выводим сообщения об атаке и текущее здоровье человека и противника
            Console.WriteLine("На человека нападает противник");
            Console.WriteLine("Здоровье человека: " + Health + ", здоровье противника: " + enemy);

            // Создаем переменную для определения вводимых пользователем команд
            string user_command = "";
            // Создаем цекл для схватки
            while ((Health >= 10) && (enemy > 10) && (enemy != 100))
            {
               // Каждую итерацию записываем команду и в зависимости от выбранного действия формируем ход сражения 
               Console.WriteLine("\nВведите коматду hit чтобы нанести удар, или run чтобы убежать");
               user_command = Console.ReadLine();
               switch (user_command)
               {
                    case "hit":
                        {
                            // При аттаки человек и противник наносят поочередно удары, после выводится текущее состояние каждого
                            Health -= (uint)10;
                            enemy -= (uint)10;
                            Console.WriteLine("Человек наносит противнику удар, противник отвечает");
                            Console.WriteLine("Здоровье человека: " + Health + ", здоровье противника: " + enemy);
                            break;
                        }
                    case "run":
                        {
                            // При попытке человека убежат противник решает напасть только если здоровье человека превышает 20 едениц
                            if (Health < 20)
                            {
                                Console.WriteLine("Противник проявил милосердие");
                                enemy = 100;
                            }
                            else
                            {
                                Health -= 10;
                                Console.WriteLine("Противник наносит удар");
                                Console.WriteLine("Здоровье человека: " + Health + ", здоровье противника: " + enemy);
                            }
                            break;
                        }
                    default:
                        {
                            // Обработка неверно введенной команды
                            Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова");
                            Console.WriteLine("Введите коматду hit чтобы нанести удар, или run чтобы убежать");
                            break;
                        }
               }
            }

            if (Health <= 10)
            {
                // Если здоровье человека меньше 10 и он не пытался убежать, противник наносит решающий удар
                Console.WriteLine("Противник наносит решающий удар");
                Kill();
            }
            else
            {
                // Если противник проиграл в честной схватке, он попытается убежать
                if (enemy < 100) {
                    Console.WriteLine("Противник убегает. Проявить милосердие? (Введите команду yes или no)");
                    user_command = Console.ReadLine();
                    switch (user_command)
                    {
                        case "yes":
                            {
                                // Если человек пощадил противника его здоровье увеличивается
                                Health = (uint)rnd.Next((int)Health, 100);
                                break;
                            }
                        case "no":
                            {
                                // Если человек не пощадил противника его здоровье увеличиваетсяв, но в меньшем размере
                                Health = (uint)rnd.Next((int)Health, 80);
                                break;
                            }
                        default:
                            {
                                // Обработка неверно введенной команды
                                Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова");
                                Console.WriteLine("Введите команду yes или no");
                                break;
                            }
                    }
                }
                // После сражения выводится информация о текущем здоровье человека
                Console.WriteLine("После встречи с противником ваше здоровье составляет " + Health);
            }
           
        }
    }
}
