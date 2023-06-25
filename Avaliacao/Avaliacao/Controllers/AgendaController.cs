using Agenda.Models;

namespace Programa.Controllers;

public class AgendaController
{
    public static void Create(AgendaVO agendaVo)
    {
        try
        {
            foreach (var property in typeof(AgendaVO).GetProperties())
            {
                var value = property.GetValue(agendaVo);
        
                if (value == null)
                {
                    Console.WriteLine($"A propriedade '{property.Name}' está nula.");
                    Console.WriteLine($"Volte e insira todas as informações solicitadas.");
                    return;
                }
            }

            new AgendaModel(agendaVo);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu uma erro ao criar a tarefa na agenda: " + e.Message);
            throw;
        }
    }
    
    public static List<AgendaModel> Read()
    {
        return AgendaModel.Read();
    }

    public static void Update(int index, AgendaVO agendaVo)
    {
        try
        {
            if (index == null)
            {
                Console.WriteLine($"Erro! {index} não existente!");
                return;
            }
            
            if (agendaVo.nome == null && agendaVo.data == null && agendaVo.concluido == null)
            {
                Console.WriteLine("Digite as informações corretamente.");
                return;
            }

            AgendaModel.Update(index, agendaVo);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu uma erro ao atualizar a agenda: " + e.Message);
            throw;
        }
    }
    
    public static void Delete(int index)
    {
        try
        {
            if (index == null)
            {
                Console.WriteLine($"Erro! {index} não existente!");
                return;
            }
            
            AgendaModel.Delete(index);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu uma erro ao deletar a tarefa da agenda: " + e.Message);
            throw;
        }
    }
    
    public static void ToogleTaskStatus(int index)
    {
        try
        {
            if (index == null)
            {
                Console.WriteLine($"Erro! {index} não existente!");
                return;
            }
        
            AgendaModel.ToogleTaskStatus(index);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu uma erro ao atualizar o status da a tarefa: " + e.Message);
            throw;
        }
    }
}