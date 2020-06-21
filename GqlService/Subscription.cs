using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace GqlService
{
    public class Subscription
    {
        private readonly IDataRefValueReader _valueReader;
        public Subscription(IDataRefValueReader valueReader)
        {
            _valueReader = valueReader;
        }
        
        [SubscribeAndResolve]
        public async IAsyncEnumerable<ReferenceValueChange> References(string[] names, IResolverContext context, [Service]ITopicEventReceiver receiver)
        {
            foreach (var name in names)
            {
                var value = _valueReader.Read(name);
                yield return new ReferenceValueChange(name, value);
            }

            await foreach (var change in await receiver.SubscribeAsync<string, ReferenceValueChange>(ReferenceValueChange.Topic, context.RequestAborted))
            {
                if (names.Contains(change.Name))
                {
                    yield return change;
                }
            }
        }
    }
}