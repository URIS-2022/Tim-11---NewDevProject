namespace AuctionMS.Communication
{
    using System.Text;
    using RabbitMQ.Client;

    public class LoggerProvider
    {
        public LoggerProvider()
        {
            
        }

        public static void PublishLogMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var Channel = connection.CreateModel();

            Channel.QueueDeclare(queue: "logs",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            Channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "logs",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[x] Sent {message}");
        }
    }
}
