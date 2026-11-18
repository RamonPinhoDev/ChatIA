using OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;


var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

string ApiKey = config["OpenAI:ApiKey"] ?? throw new InvalidOperationException("OpenAI:ApiKey Não configurada.");

IChatClient cliente = new OpenAIClient(ApiKey) //Cliente Raiz(OpenAI)
                          .GetChatClient("gpt-4o-mini") //Cliente de chat(OpenAI)
                          .AsIChatClient(); //Microsoft Extensions AI

Console.WriteLine("Qual capital do peru?");

var response = await cliente.GetResponseAsync("Qual capital do peru?");
Console.WriteLine($"\nIA: {response.Text}");


//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