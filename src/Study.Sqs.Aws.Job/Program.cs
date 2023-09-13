// See https://aka.ms/new-console-template for more information

using Study.Sqs.Aws.Job.Handler;

Console.WriteLine("Hello, World!");

Console.WriteLine("Iniciando envio de mensage...");
await HandleMessage.SendMessage("testando envio de mensagem");
Console.WriteLine("Mensagem enviada com sucesso");

Thread.Sleep(10000);

Console.WriteLine("Iniciando consumo de mensage...");
await HandleMessage.ConsumerMessage();
Console.WriteLine("Mensagem consumida com sucesso");