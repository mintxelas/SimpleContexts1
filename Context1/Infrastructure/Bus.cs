using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Context1.Infrastructure
{
    public sealed class Bus
    {
        private readonly ConcurrentDictionary<Type, List<Action<object>>> subscribers = new ConcurrentDictionary<Type, List<Action<object>>>();

        public void Publish<T>(T @event) where T : class
        {
            var key = @event.GetType();
            if (subscribers.ContainsKey(key))
            {
                foreach (var handler in subscribers[key])
                {
                    handler(@event);
                }
            }
        }

        public void Subscribe<T>(Action<T> handler) where T : class
        {
            var key = typeof(T);
            var wrapper = new Action<object>(evt => handler((T)evt));

            subscribers.AddOrUpdate(key,
                new List<Action<object>> { wrapper },
                (type, handlers) => {
                    handlers.Add(wrapper);
                    return handlers;
                });
        }


        public void Dispose()
        {
            subscribers?.Clear();
        }
    }
}