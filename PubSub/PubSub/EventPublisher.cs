namespace PubSub
{
    public class EventPublisher
    {
        public void PublishEvent1()
        {
            EventBus.Instance.Publish(EventCode.Event1);
        }
        
        public void PublishEvent2()
        {
            EventBus.Instance.Publish(EventCode.Event2);
        }
    }
}