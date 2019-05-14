using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaTestProduce {
    class Program {
        public static void Main(string[] args) {

            var asyncP = new AsyncProducer(new Dictionary<string, string>());

            

            asyncP.OnMessageRecieved += (string s) => {

                Console.WriteLine($"Message Recieved : {s}");

            };

            asyncP.Produce("hello world");
            Console.ReadLine();

            //var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };

            //Action<DeliveryReport<Null, string>> handler = r =>
            //    Console.WriteLine(!r.Error.IsError
            //        ? $"Delivered message to {r.TopicPartitionOffset}"
            //        : $"Delivery Error: {r.Error.Reason}");

            //using (var p = new ProducerBuilder<Null, string>(conf).Build()) {
            //    for (int i = 0; i < 100; ++i) {
            //        p.ProduceAsync("my-topic", new Message<Null, string> { Value = i.ToString() });
            //    }

            //    // wait for up to 10 seconds for any inflight messages to be delivered.
            //    p.Flush(TimeSpan.FromSeconds(10));
            //}
        }
    }
}
