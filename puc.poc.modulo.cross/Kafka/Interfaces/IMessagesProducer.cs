using System.Threading.Tasks;

namespace puc.poc.modulo.cross.Kafka.Interfaces
{
    public interface IMessagesProducer
    {
       public Task ProduceAync(IMessage message);
    }
}