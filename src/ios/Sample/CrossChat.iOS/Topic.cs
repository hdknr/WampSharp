﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Reactive.Subjects;
using WampSharp.V2;
using WampSharp.V2.PubSub;
using WampSharp.V2.Realm;
using WampSharp.V2.Client;
using WampSharp.V2.Core.Contracts;
using WampSharp.V2.Rpc;

using Newtonsoft.Json.Linq;

namespace CrossChat.iOS
{
	public class Topic
	{
		ISubject<JObject> _subject= null;
		IDisposable _subscription  = null;
		IWampChannel _channel = null;
		Settings settings = new Settings ();

		public Topic (Action<JObject> on_message)
		{

			var channelFactory = new DefaultWampChannelFactory();
			var auth = 	new WampCraClientAuthenticator(
				authenticationId:  settings.GetPreference("chat_user"),
				secret: settings.GetPreference("chat_token"));

			_channel = channelFactory.CreateJsonChannel(
				settings.GetPreference("chat_server"),
				settings.GetPreference("chat_realm"),
				auth);

			_channel.RealmProxy.Monitor.ConnectionEstablished += (
				object s, WampSessionCreatedEventArgs e) => {
				var realmProxy = _channel.RealmProxy;

				_subject = realmProxy.Services.GetSubject<JObject> (
					settings.GetPreference ("chat_topic"));

				_subscription = _subject.Subscribe (x => on_message (x));
			};

			_channel.Open().Wait();
		}

		public void Publish(string message){
			if (_channel != null) {
				var topic = _channel.RealmProxy.TopicContainer.GetTopicByUri (
					settings.GetPreference ("chat_topic")
				);
				topic.Publish(
					new PublishOptions() { Acknowledge = false },
					new object[]{ new Dictionary<string,string>{
							{"nick", settings.GetPreference ("chat_user")},
							{"message", message}
						}}).Wait();

			}
		}
	}
}
