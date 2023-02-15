using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Logger
{
    public class EventConsumer
    {
        private static Serilog.Core.Logger _logger;

        public EventConsumer(Serilog.Core.Logger logger)
        {
            _logger = logger;
        }

        public static void Setup()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "logs",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                _logger.Information("[*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    _logger.Information(message);
                };

                channel.BasicConsume(queue: "logs",
                                     autoAck: true,
                                     consumer: consumer);
            }
            catch(Exception e)
            {
                _logger.Error(e.ToString());
            }
        }
    }
}
