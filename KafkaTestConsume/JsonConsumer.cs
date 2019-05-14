using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Threading;


namespace KafkaTestConsume {
    class JsonConsumer<t3> : IAsyncConsumer<t3> {


        public event Action<t3> OnMessageRecieved;
        public event Action<ConsumeException> OnConsumeError;

        public Dictionary<string, string> Config { get; set; }
        public string Topic { get; set; }
        public JsonConsumer(Dictionary<string, string> config) {
            this.Config = config;

        }

        public void Consume(string topic) {

            Thread consumeThread = new Thread(() => {

                _Consume(topic);
            });

            consumeThread.Start();

        }

        public void Consume<T1>(string topic) {

            Thread consumeThread = new Thread(() => {

                _Consume<T1>(topic);
            });

            consumeThread.Start();

        }
        private void _Consume(string topic) {

            using (var c = new ConsumerBuilder<Ignore, string>(Config).Build()) {
                c.Subscribe(topic);

                try {
                    while (true) {
                        try {
                            var cr = c.Consume();

                            var dMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<t3>(cr.Value);

                            OnMessageRecieved?.Invoke(dMessage);
                            // Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        } catch (ConsumeException e) {
                            OnConsumeError?.Invoke(e);
                            // Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                } catch (OperationCanceledException) {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }

        }

        private void _Consume<T1>(string topic) {

            using (var c = new ConsumerBuilder<T1, string>(Config).Build()) {
                c.Subscribe(topic);

                try {
                    while (true) {
                        try {
                            var cr = c.Consume();

                            var dMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<t3>(cr.Value);

                            OnMessageRecieved?.Invoke(dMessage);
                            // Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        } catch (ConsumeException e) {
                            OnConsumeError?.Invoke(e);
                            // Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                } catch (OperationCanceledException) {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }

        }
    }
}
