using System;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Sting
{
    /// <summary>
    /// イベントを発行します。
    /// </summary>
    public abstract class Publisher
    {
        protected static EventAggregator EventAggregator { get; } = new EventAggregator();

        /// <summary>
        /// イベントを発行する
        /// </summary>
        /// <typeparam name="T">イベントの引数型</typeparam>
        public static void Publish<T>(T args)
        {
            EventAggregator
                .GetEvent<PubSubEvent<T>>()
                .Publish(args);
        }
    }

    /// <summary>
    /// イベントを受け止めます。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Subscriber<T> : Publisher, IDisposable
    {
        private static int _listenerCounter;

        private readonly SubscriptionToken _token;

        public Subscriber(Action<T> action, ThreadOption option = ThreadOption.UIThread)
        {
            _token = EventAggregator
                .GetEvent<PubSubEvent<T>>()
                .Subscribe(action, option);

            _listenerCounter++;
        }

        public void Dispose()
        {
            _token.Dispose();
            _listenerCounter--;
        }
    }
}