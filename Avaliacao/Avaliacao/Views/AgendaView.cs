using System.Globalization;
using Agenda.Models;
using Programa.Controllers;

namespace Programa.Views;
public class AgendaView
{
    public static void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. CREATE AGENDA.");
            Console.WriteLine("2. READ AGENDA.");
            Console.WriteLine("3. UPDATE AGENDA.");
            Console.WriteLine("4. DELETE AGENDA.");
            Console.WriteLine("5. ALTERAR STATUS DE TAREFA NA AGENDA.");
            Console.WriteLine("6. SAIR.");

            string options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    CreateAgenda();
                    break;
                case "2":
                    ReadAgenda();
                    break;
                case "3":
                    UpdateAgenda();
                    break;
                case "4":
                    DeleteAgenda();
                    break;
                case "5":
                    ToogleTaskStatus();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void CreateAgenda()
    {
        string input;
        AgendaVO agendaVo = new AgendaVO();
        
        Console.WriteLine("Informe o nome da tarefa:");
        input = Console.ReadLine();
        agendaVo.nome = input;

        Console.WriteLine("Informe a data e hora (formato DD-MM-AAAA HH:mm):");
        input = Console.ReadLine();
        
        if (DateTime.TryParseExact(input, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
        {
            agendaVo.data = data;
        }
        else
        {
            Console.WriteLine("Formato de data e hora inválido. A data não será definida.");
        }
        
        Console.WriteLine("Informe se já concluiu. Digite [S] para sim ou [N] para não:");
        input = Console.ReadLine();
        input = input.ToLower();

        while (input != "s" && input != "n")
        {
            Console.WriteLine("Digite apenas [S] para sim ou [N] para não:");
            input = Console.ReadLine();
            input = input.ToLower();
        }
        bool completed = (input == "s");
        agendaVo.concluido = completed;
        
        AgendaController.Create(agendaVo);
    }
    
    private static void ReadAgenda()
    {
        int index = 1;
        List<AgendaModel> tasks = AgendaController.Read();

        foreach (AgendaModel task in tasks)
        {
            Console.WriteLine($"ID: ({index}) - {task}");
            index++;
        }
    }

    private static void UpdateAgenda()
    {
        string input;
        Console.WriteLine("Informe o ID que deseja acessar para atualizar as informações:");
        Console.WriteLine("Caso não saiba o ID, verifique na opção: [2. READ AGENDA] do menu anteior.");
        input = Console.ReadLine();

        while (!RegexUtils.IsValidNumber(input))
        {
            Console.WriteLine("Digite apenas números.");
            input = Console.ReadLine();
        }
        int index = Convert.ToInt32(input);
        
        Console.WriteLine("Digite as informações que deseja alterar separadas por vírgula. Ex: nome, data, concluido, etc.");
        string infos = Console.ReadLine().ToLower();

        string[] listInfos = infos.Split(',');

        AgendaVO agendaVo = new AgendaVO();

        foreach (string info in listInfos)
        {
            switch (info.Trim())
            {
                case "nome":
                    Console.WriteLine("Informe o novo nome da tarefa: ");
                    input = Console.ReadLine();
                    agendaVo.nome = input;
                    break;
                case "data":
                    Console.WriteLine("Informe a nova data e hora da tarefa (formato DD-MM-AAAA HH:mm): ");
                    input = Console.ReadLine();
                    
                    if (DateTime.TryParseExact(input, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    {
                        agendaVo.data = data;
                    }
                    else
                    {
                        Console.WriteLine("Formato de data e hora inválido. A data não será definida.");
                    }
                    break;
                case "concluido":
                    Console.WriteLine("Informe se já concluiu. Digite [S] para sim ou [N] para não:");
                    input = Console.ReadLine();
                    input = input.ToLower();
                    
                    while (input != "s" && input != "n")
                    {
                        Console.WriteLine("Digite apenas [S] para sim ou [N] para não:");
                        input = Console.ReadLine();
                        input = input.ToLower();
                    }
                    bool concluido = (input == "s");
                    agendaVo.concluido = concluido;
                    break;
                default:
                    Console.WriteLine($"A propriedade '{info.Trim()}' não existe e será ignorada.");
                    break;
            }
        }
        
        AgendaController.Update(index - 1, agendaVo);
    }
    
    private static void DeleteAgenda()
    {
        Console.WriteLine("Informe o ID da tarefa: ");
        Console.WriteLine("Caso não saiba o ID, verifique na opção: [2. READ AGENDA] do menu anteior.");
        string selectIndex = Console.ReadLine();

        while (!RegexUtils.IsValidNumber(selectIndex))
        {
            Console.WriteLine("Digite apenas números.");
            selectIndex = Console.ReadLine();
        }
        int index = Convert.ToInt32(selectIndex);
            
        AgendaController.Delete(index-1);
    }
    
    private static void ToogleTaskStatus()
    {
        Console.WriteLine("Informe o ID que deseja que deseja alterar o status da tarefa: ");
        string selectIndex = Console.ReadLine();
        
        while (!RegexUtils.IsValidNumber(selectIndex))
        {
            Console.WriteLine("Digite apenas números.");
            selectIndex = Console.ReadLine();
        }
        int index = Convert.ToInt32(selectIndex);
        
        AgendaController.ToogleTaskStatus(index - 1);
    }
}