using System;

namespace PubSub
{
    public class EventListener1
    {
        private void OnEnable()
        {
            EventBus.Instance.Subscribe(EventCode.Event1, OnEvent1);
            EventBus.Instance.Subscribe(EventCode.Event2, OnEvent2);
        }

        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe(EventCode.Event1, OnEvent1);
            EventBus.Instance.Unsubscribe(EventCode.Event2, OnEvent2);
        }

        private void OnEvent1()
        {
            Console.WriteLine($"event 1 received");
        }
        
        private void OnEvent2()
        {
            Console.WriteLine($"event 2 received");
        }
    }
}