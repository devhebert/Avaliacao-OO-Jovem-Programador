namespace Programa.Repositories;

public class FormigaRepositories
{
    public static void Create(CachorroModel cachorro)
    {
        if (cachorro == null)
        {
            Console.WriteLine("Erro!");
        }
            
        cachorroList.Add(cachorro);
    }
}