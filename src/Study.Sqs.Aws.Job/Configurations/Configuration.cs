using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Collections.Specialized;
using System.Configuration;

namespace Study.Sqs.Aws.Job.Configurations
{
    public static class Configuration
    {
        private static string AccessKey => GetAppSettings().GetValues(nameof(AccessKey))?.FirstOrDefault() ?? String.Empty;
        private static string SecretyAccessKey => GetAppSettings().GetValues(nameof(SecretyAccessKey))?.FirstOrDefault() ?? String.Empty;
        private static string QueueUrl => GetAppSettings().GetValues(nameof(QueueUrl))?.FirstOrDefault() ?? String.Empty;
        private static RegionEndpoint RegionEndpoint => RegionEndpoint.SAEast1;

        private static NameValueCollection GetAppSettings()
            => ConfigurationManager.AppSettings;

        public static AmazonSQSClient GetCredentials()
            => new AmazonSQSClient(AccessKey, SecretyAccessKey, RegionEndpoint);

        public static string GetQueueUrl()
            => QueueUrl;

        public static ReceiveMessageRequest ReceiveMessageRequest
            => new ReceiveMessageRequest
            {
                QueueUrl = QueueUrl
            };

        public static SendMessageRequest GetSendMessageRequest(string message)
            => new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody = message
            };
    }
}
