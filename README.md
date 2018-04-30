# NLogEvents
This .NET library defines an event that triggers whenever a log record is sent to NLog. It provides an easy to use API for intercepting logs.

## Usage

1.  Add a nuget dependency on [NLog.Events](https://www.nuget.org/packages/NLog.Events/).
2.  Define a target with type `OnLogEvent` in your `NLog.config`, and a rule that sends some logs to it.
3.  Subscribe to `NLogEvents.Events.OnLog` event. It'll fire whenever a log record is sent to the `OnLogEvent` you've defined.

See [Example](https://github.com/romkatv/NLogEvents/blob/master/Example).
