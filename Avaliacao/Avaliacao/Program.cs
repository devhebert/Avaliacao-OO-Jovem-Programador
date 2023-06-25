namespace Programa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("1 - CRUD AGENDA");
                Console.WriteLine("2 - Sair");
                Console.WriteLine("----------------\n");
                Console.Write("Selecione uma opção: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Views.AgendaView.Run();
                        break;
                    case "2":
                        exit = true;
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Digite um número de 1 a 2.");
                        break;
                }
            }
        }
    }
}