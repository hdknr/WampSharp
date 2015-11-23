# Experimental Xamarin Suppport

- ios is solution folder for working with Xamarin iOS

## Fleck.iOS

- forked version of [Fleck](https://github.com/hdknr/Fleck) for building Xamarin.iOS library
- refered by WampSharp.Fleck

## WampSharp

- working compile option : `TRACE;DEBUG;NET45;LIBLOG_PORTABLE LIBLOG_PUBLIC;PCL;XAMARIN` 
- `XAMARIN` is swith for enabling `WampSharp.WAMP2.V2.Client.Session.WampCraClientAuthenticator` 
  and `WampSharp.Core.Cra.WampCraHelpers`


## WampSharp.Default.Client

- working compile option :  `DEBUG;NET45;NOMSGPACK`
- `NOMSGPACK` is disabling MsgPack.


## WampSharp.Default.Router

- working compile option :  `DEBUG;NET45;NOMSGPACK`
- `NOMSGPACK` is disabling MsgPack.

## CrossChat.iOS

- iOS Sample working with `crossbar.io` (https://github.com/hdknr/crosschat)
- Simple Single View iOS application
- Subscribes a topic and echoes back received messages to the same topic.

## TODO

- Andoroid version
