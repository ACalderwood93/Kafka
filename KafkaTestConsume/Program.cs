using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTestConsume {
    class Program {
        static void Main(string[] args) {


            var config = new Dictionary<string, string>() {

            };
            IAsyncConsumer<User> consumer = new DebugConsumer<User>(config);

            

            consumer.OnMessageRecieved += (User message) => {


                Console.WriteLine("Messaged Recieved");
            };

            consumer.OnConsumeError += (ConsumeException e) => {
                Console.WriteLine("Consume Error");
            };

            consumer.Consume("test");

            Console.ReadLine();


        }
    }
}
