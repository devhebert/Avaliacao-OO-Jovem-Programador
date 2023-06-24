namespace Programa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("1 - CRUD AGENDA");
                Console.WriteLine("2 - Sair");
                Console.WriteLine("----------------\n");
                Console.Write("Selecione uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Views.AgendaView.Run();
                        break;
                    case "2":
                        sair = true;
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