using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Threading;

namespace KafkaTestConsume {
    public class DebugConsumer<T> : IAsyncConsumer<T> where T : User {
        public Dictionary<string, string> Config { get; set; }

        public event Action<T> OnMessageRecieved;
        public event Action<ConsumeException> OnConsumeError;

        public DebugConsumer(Dictionary<string, string> config) {
            this.Config = config;

        }
        public void Consume(string topic) {

            var consumerThread = new Thread(() => {


                var rand = new Random();

                while (true) {

                    int i = rand.Next(10);

                    if (i >= 5) {

                        var newUser = new User() {
                            Firstname = "dg",
                            Surname = " sdfg"
                        };

                        OnMessageRecieved.Invoke(newUser as T);
                    } else {
                        OnConsumeError.Invoke(null);
                    }

                }


            });

            consumerThread.Start();

        }

        public void Consume<T1>(string topic) {
            throw new NotImplementedException();
        }
    }
}
