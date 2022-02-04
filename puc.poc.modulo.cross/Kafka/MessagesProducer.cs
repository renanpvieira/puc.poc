using KafkaFlow;
using puc.poc.modulo.cross.Kafka.Interfaces;
using System;
using System.Threading.Tasks;

namespace puc.poc.modulo.cross.Kafka
{
    public class MessagesProducer : IMessagesProducer
    {
        private readonly IMessageProducer<MessagesProducer> producer;

        public MessagesProducer(IMessageProducer<MessagesProducer> producer)
        {
            this.producer = producer;
        }

        public Task ProduceAync(IMessage message)
        {
            return this.producer.ProduceAsync(Guid.NewGuid().ToByteArray(), message);
        }
    }
}
