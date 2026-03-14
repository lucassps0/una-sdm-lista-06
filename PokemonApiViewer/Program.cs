using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
  static async Task Main()
  {
    HttpClient client = new HttpClient();

    bool tentando = true;

    while (tentando)
    {
      Console.WriteLine("Digite o nome do Pokemon:");
      string nome = Console.ReadLine();
      string url = $"https://pokeapi.co/api/v2/pokemon/{nome}";


      try
      {

        var resposta = await client.GetStringAsync(url);

        var dados = JsonDocument.Parse(resposta);


        Console.WriteLine("ID: " + dados.RootElement.GetProperty("id"));
        Console.WriteLine("Nome: " + dados.RootElement.GetProperty("name"));
        Console.WriteLine("Altura: " + dados.RootElement.GetProperty("height"));
        Console.WriteLine("Peso: " + dados.RootElement.GetProperty("weight"));

        Console.WriteLine("Deseja consultar outro Pokemon? (s/n)");
        string respostaUsuario = Console.ReadLine().ToLower();
        if (respostaUsuario != "s")
        {
          tentando = false;
        }
      }
      catch
      {
        Console.WriteLine("Pokemon não encontrado. Verifique o nome e tente novamente.");
      }
    }
  }
}