using Serilog;
using Amazon.CloudWatchLogs;
using Serilog.Sinks.AwsCloudWatch;
using Amazon;

namespace Logger
{
    public class LoggerFactory
    {
        private static readonly string logGroup = "URIS/logs";
        private static readonly RegionEndpoint region = RegionEndpoint.EUCentral1;
        private static IConfiguration _configuration;

        public static void AddConfiguration(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public static Serilog.Core.Logger GetLoggerAsync()
        {
            string awsAccessKeyId = _configuration["awsAccessKeyId"];
            string awsSecretAccessKey = _configuration["awsSecretAccessKey"];
            var client = new AmazonCloudWatchLogsClient(awsAccessKeyId: awsAccessKeyId, awsSecretAccessKey: awsSecretAccessKey, region: region);

            return new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.AmazonCloudWatch
                    (
                        logGroup: logGroup,
                        logStreamPrefix: DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"),
                        cloudWatchClient: client,
                        createLogGroup: false
                    )
                    .CreateLogger();
        }
    }
}
