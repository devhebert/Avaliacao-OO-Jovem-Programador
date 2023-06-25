using Programa.Repositories;

namespace Agenda.Models;

public class AgendaModel
{
    private string nome { get; set; }
    private DateTime data { get; set; }
    private bool concluido { get; set; }

    public AgendaModel(AgendaVO agenda)
    {
        this.nome = agenda.nome;
        this.data = (DateTime)agenda.data;
        this.concluido = (bool) agenda.concluido;
        
        AgendaRepository.Create(this);
    }
    
    public static List<AgendaModel> Read()
    {
        return AgendaRepository.Read();
    }
    
    public static AgendaModel? GetAgenda(int index)
    {
        return AgendaRepository.GetAgenda(index);
    }
    
    public static void Update(int index, AgendaVO agenda)
    {
        AgendaModel agendaModel = GetAgenda(index);
        if (agendaModel != null)
        {
            agendaModel.nome = agenda.nome ?? agendaModel.nome;
            agendaModel.data = agenda.data ?? agendaModel.data;
            agendaModel.concluido = agenda.concluido ?? agendaModel.concluido;

            AgendaRepository.Update(index, agendaModel);
        }
    }
    
    public static void Delete(int index)
    {
        AgendaModel agendaItem = GetAgenda(index);
        if (agendaItem != null)
        {
            AgendaRepository.Delete(index);
        }
    }
    
    public static void ToogleTaskStatus(int index)
    {
        AgendaModel agendaModel = GetAgenda(index);
        if (agendaModel != null)
        {
            agendaModel.concluido = !agendaModel.concluido;

            AgendaRepository.Update(index, agendaModel);
        }
    }
    
    public override string ToString()
    {
        string status = concluido ? "Sim" : "Não";
        return $"Nome: {nome}, Data: {data}, Concluído: {status}";
    }
}