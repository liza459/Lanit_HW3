using Color;
using Provider.dto;
using Provider;

namespace lanit_HW3
{
    public class WorkWithDB
    {
        private readonly ColorCw color = new();
        public void Menu()
        {
            
                color.Yellow("Что вы хотите сделать?\nВведите:\n \t1  что бы добавить нового работника;" +
                              "\n \t2  что бы посмотреть списки работников по филиалам" +
                              "\n \t3  что бы посмотреть списки работников и их достижения;" +
                              "\n \t4  что бы перевести работника в другой филиал" +
                              "\n \t5  что бы удалить уволившегося сатрудника" +
                              "\n \t6  что бы выйти\n");
                string menu = Console.ReadLine();
                ProviderSQL provider = new ProviderSQL();

                switch (menu)
                {
                    case "1":
                    Workers worker = new Workers();
                    try
                    {
                        color.Yellow("Введите id сотрудника\n");
                        worker.ID = int.Parse(Console.ReadLine());
                        color.Yellow("Введите имя сотрудника\n");
                        worker.Name = Console.ReadLine();
                        color.Yellow("Введите фамилию сотрудника\n");
                        worker.Last_name = Console.ReadLine();
                        color.Yellow("Введите номер филиала в который принимают сотрудника\n");
                        worker.Number_Branch = int.Parse(Console.ReadLine());
                        provider.Create(worker);
                        color.Green("Сотрудник добавлен\n");
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    
                    break;
                    case "2":
                    try
                    {
                        color.Yellow("Введите номер филиала\n");
                        int number = int.Parse(Console.ReadLine());
                        provider.Read1N(number);
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    break;
                    case "3":
                    try
                    {
                        provider.ReadNN();
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    break;
                case "4":
                    try
                    {
                        Workers worker1 = new Workers();
                        color.Yellow("Введите id сотрудника\n");
                        worker1.ID = int.Parse(Console.ReadLine());
                        color.Yellow("Введите номер филиала куда переведен работник\n");
                        worker1.Number_Branch = int.Parse(Console.ReadLine());
                        provider.Update(worker1.ID, worker1.Number_Branch);
                        color.Green("Сотрудник перведен \n");
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    
                    break;
                    case "5":
                    try
                    {
                        color.Yellow("Введите ID сотрудника для удаления\n");
                        int id= int.Parse(Console.ReadLine());
                        provider.Read1N(id);
                        color.Green("Сотрудник удален");
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    break;
                    case "6":
                        break;
                    default:
                        color.Red("Ошибка ввода\n");
                        break;
                }
            
        }
        
    }
}
