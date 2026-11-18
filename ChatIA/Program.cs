using OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;


var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

string ApiKey = config["OpenAI:ApiKey"] ?? throw new InvalidOperationException("OpenAI:ApiKey Não configurada.");

IChatClient cliente = new OpenAIClient(ApiKey) //Cliente Raiz(OpenAI)
                          .GetChatClient("gpt-4o-mini") //Cliente de chat(OpenAI)
                          .AsIChatClient(); //Microsoft Extensions AI

Console.WriteLine("Qual capital do peru?");

//var response = await cliente.GetResponseAsync("Qual capital do peru?");
//Console.WriteLine($"\nIA: {response.Text}");

//Console.WriteLine("O que é a luz?");
//Console.WriteLine("IA:");

while (true)
{
    Console.WriteLine("\n Você: ");
    string? pergunta = Console.ReadLine();

    if (string.IsNullOrEmpty(pergunta) || pergunta.Equals("sair", StringComparison.OrdinalIgnoreCase))
    {
        
        break;
    }
    Console.WriteLine("IA: ");
    await foreach (var item in cliente.GetStreamingResponseAsync(pergunta))
    {
        Console.Write(item.Text);
    }


}
