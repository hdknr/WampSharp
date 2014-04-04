﻿using Newtonsoft.Json.Linq;
using WampSharp.Binding;
using WampSharp.Core.Listener;
using WampSharp.Core.Serialization;
using WampSharp.Newtonsoft;
using WampSharp.V2.Adapters;
using WampSharp.V2.Core.Listener;
using WampSharp.V2.Realm;

namespace WampSharp.V1
{
    public class Wamp1Binding<TMessage> : JsonBinding<TMessage>
    {
        public Wamp1Binding(IWampTextMessageParser<TMessage> parser, IWampFormatter<TMessage> formatter) : 
            base(formatter, parser, "wamp")
        {
        }

        public override IWampBindingHost CreateHost(IWampRealmContainer realmContainer, IWampConnectionListener<TMessage> connectionListener)
        {
            return new Wamp1BindingHost<TMessage>(realmContainer, connectionListener, this.Formatter);
        }
    }

    public class Wamp1Binding : Wamp1Binding<JToken>
    {
        public Wamp1Binding() : 
            base(new JTokenMessageParser(), new JsonFormatter())
        {
        }
    }
}