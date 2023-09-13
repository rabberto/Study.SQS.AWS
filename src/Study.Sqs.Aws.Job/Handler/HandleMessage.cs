using Amazon.SQS;
using Study.Sqs.Aws.Job.Configurations;

namespace Study.Sqs.Aws.Job.Handler
{
    public static class HandleMessage
    {
        public static async Task SendMessage(string message)
        {
            using (AmazonSQSClient amazonSQSClient = Configuration.GetCredentials())
            {
                var sendMessageRequest = Configuration.GetSendMessageRequest(message);

                await amazonSQSClient.SendMessageAsync(sendMessageRequest);
            }
        }

        public static async Task ConsumerMessage()
        {
            using (AmazonSQSClient amazonSQSClient = Configuration.GetCredentials())
            {
                var receiveMessageRequest = Configuration.ReceiveMessageRequest;

                var response = await amazonSQSClient.ReceiveMessageAsync(receiveMessageRequest);

                foreach (var mensagem in response.Messages)
                {
                    Console.WriteLine(mensagem.Body);
                    await amazonSQSClient.DeleteMessageAsync(Configuration.GetQueueUrl(), mensagem.ReceiptHandle);
                }
            }
        }
    }
}
