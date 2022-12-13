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
                              "\n \t3  что бы посмотреть списки работников на определенную должность;" +
                              "\n \t4  что бы изменить навыки сотрудика" +
                              "\n \t4  что бы удалить уволившегося сатрудника" +
                              "\n \t5  что бы выйти\n");
                string menu = Console.ReadLine();

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
                        color.Yellow("Может ли работник осуществлять приемку товара (true или false)\n");
                        worker.Skil_loader = bool.Parse(Console.ReadLine());
                        color.Yellow("Может ли работник осуществлять доставку товара (true или false)\n");
                        worker.Skil_driver = bool.Parse(Console.ReadLine());
                        color.Yellow("Может ли сотрудник работать с кассой (true или false)\n");
                        worker.Skil_PC = bool.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        color.Red("Ошибка ввода\n" + e.Message + "\n");
                    }
                    ProviderSQL provider = new ProviderSQL();
                    provider.Create(worker);
                    break;
                    case "2":
                    Console.WriteLine("2");
                    break;
                    case "3":
                    Console.WriteLine("3");
                    break;
                    case "4":
                    Console.WriteLine("4");
                    break;
                    case "5":
                        break;
                    default:
                        color.Red("Ошибка ввода\n");
                        break;
                }
            
        }
        //public void CreateWorker()
        //{
        //    Workers worker= new Workers();
        //    color.Yellow("Введите id сотрудника\n");
        //    worker.ID = int.Parse(Console.ReadLine());
        //    color.Yellow("Введите имя сотрудника\n");
        //    worker.Name = Console.ReadLine();
        //    color.Yellow("Введите фамилию сотрудника\n");
        //    worker.Last_name = Console.ReadLine();
        //    color.Yellow("Введите номер филиала в который принимают сотрудника\n");
        //    worker.Number_Branch = int.Parse( Console.ReadLine());
        //    color.Yellow("Может ли работник осуществлять приемку товара (true или false)\n");
        //    worker.Skil_loader = bool.Parse( Console.ReadLine());
        //    color.Yellow("Может ли работник осуществлять доставку товара (true или false)\n");
        //    worker.Skil_driver = bool.Parse(Console.ReadLine());
        //    color.Yellow("Может ли сотрудник работать с кассой (true или false)\n");
        //    worker.Skil_PC = bool.Parse(Console.ReadLine());
        //    Provider.Create create = new Provider.Create();
        //}
    }
}
