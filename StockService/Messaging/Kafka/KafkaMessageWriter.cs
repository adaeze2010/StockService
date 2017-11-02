using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockService.Messaging.Kafka
{
    public class KafkaMessageWriter : MessageWriter
    {
        // The Kafka endpoint address
        //todo: Move to configuration file
        private const string kafkaEndpoint = "127.0.0.1:9092";

        // The Kafka topic we'll be using
        //todo: Move to configuration file
        private const string kafkaTopic = "stock-import";

        private readonly Producer<Null, string> _producer;

        private readonly ILogger<KafkaMessageWriter> _logger;

        public KafkaMessageWriter(ILogger<KafkaMessageWriter> logger)
        {
            // Create the producer configuration
            var producerConfig = new Dictionary<string, object> { { "bootstrap.servers", kafkaEndpoint } };

            // Create the producer
            _producer = new Producer<Null, string>(producerConfig, null, new StringSerializer(Encoding.UTF8));

            _logger = logger;
        }

        public void Write(string message)
        {
            var result = _producer.ProduceAsync(kafkaTopic, null, message).GetAwaiter().GetResult();

            _logger.LogInformation("Event sent to partition: [{0}] with offset: [{1}]", result.TopicPartition, result.Offset);
        }
    }
}
