using Agenda.Models;

namespace Programa.Repositories;

public class AgendaRepository
{
    private static List<AgendaModel> agendaList = new List<AgendaModel>();
    
    public static void Create(AgendaModel agenda)
    {
        if (agenda == null)
        {
            Console.WriteLine("Erro!");
        }
            
        agendaList.Add(agenda);
        Console.WriteLine("Tarefa adicionada na agenda com sucesso!");
    }
    
    public static List<AgendaModel> Read()
    {
        if (agendaList.Count == 0)
        {
            Console.WriteLine("A lista está vazia.");
        }
        return agendaList;
    }
    
    public static void Update(int index, AgendaModel agenda){
        agendaList[index] = agenda;
        Console.WriteLine($"Agenda atualizada com sucesso!");
    }

    public static AgendaModel GetAgenda(int index){
        if(index < 0 || index >= agendaList.Count){
            Console.WriteLine("Indice não encontrado.");
            return null;
        }
            
        return agendaList[index];
    }
    
    public static void Delete(int index){
        agendaList.RemoveAt(index);
        Console.WriteLine($"Tarefa excluída da agenda com sucesso!");
    }
}