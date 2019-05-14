using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaTestProduce {
    public class AsyncProducer {


        public event Action<string> OnMessageRecieved;

        public AsyncProducer(Dictionary<string,string> config) {

            
        }

        public void Produce(string message) {


            OnMessageRecieved.Invoke(message);

        }
    }
}
