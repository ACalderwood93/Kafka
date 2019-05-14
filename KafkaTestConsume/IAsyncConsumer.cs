using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTestConsume {
    public interface IAsyncConsumer<T> {


        event Action<T> OnMessageRecieved;
        event Action<ConsumeException> OnConsumeError;
        Dictionary<string, string> Config { get; set; }
        void Consume(string topic);
        /// <summary>
        /// Consume with Type, This is for Passing A Key type into the consume method within Kafka
        /// </summary>
        /// <typeparam name="T1"> Type of Key</typeparam>
        /// <param name="topic"> Name of the topic you want to subscribe to</param>
        void Consume<T1>(string topic);
    }
}
