using NLog;
using System;

namespace Example {
  /// <summary>
  /// An example demonstrating the use of `NLogEvents.Events.OnLog`.
  /// </summary>
  class Example {
    static readonly Logger _log = LogManager.GetCurrentClassLogger();

    // Sample console output:
    //
    //   NLogEvents.Events.OnLog(My): Log Event: Logger='Example.Program' Level=Debug Message='Hello' SequenceID=1
    //   NLogEvents.Events.OnLog(My): Log Event: Logger='Example.Program' Level=Info Message='Bye' SequenceID=2
    //   2018-04-30 15:40:41.9128|DEBUG|Example.Program|Hello
    //   2018-04-30 15:40:41.9128|INFO|Example.Program|Bye
    static void Main(string[] args) {
      // This event will fire whenever a log is written to a target of type `OnLogEvent`.
      // There is one such target in NLog.config. Every log with `LogLevel >= Debug` is sent to it.
      NLogEvents.Events.OnLog += (string name, LogEventInfo info) => {
        // Note: If the event handler directly or indirectly creates log records, it may create a feedback loop
        // where a single log record results in a potentially infinite cascade of log records and events.
        Console.WriteLine("NLogEvents.Events.OnLog({0}): {1}", name, info);
      };
      _log.Debug("Hello");
      _log.Info("Bye");
    }
  }
}
