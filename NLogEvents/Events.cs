using System;
using NLog;

namespace NLogEvents {
  public static class Events {
    /// <summary>
    /// Triggers whenever a log is written to a target of type `OnLogEvent`.
    /// The first argument is the target's `event` attribute.
    /// </summary>
    public static event Action<string, LogEventInfo> OnLog;

    internal static void FireOnLog(string name, LogEventInfo info) => OnLog?.Invoke(name, info);
  }
}
