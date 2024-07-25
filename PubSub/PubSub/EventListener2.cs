using System;

namespace PubSub
{
    public class EventListener2
    {
        private void OnEnable()
        {
            EventBus.Instance.Subscribe(EventCode.Event2, OnEvent1);
        }

        private void OnDisable()
        {
            EventBus.Instance.Unsubscribe(EventCode.Event2, OnEvent1);
        }

        private void OnEvent1()
        {
            Console.WriteLine($"event 2 received");
        }
    }
}