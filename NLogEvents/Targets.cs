using NLog;
using NLog.Config;
using NLog.Targets;

namespace NLogEvents {
  /// <summary>
  /// NLog target that triggers `NLogEvents.Events.OnLog`.
  /// </summary>
  [Target("OnLogEvent")]
  class OnLogEvent : TargetWithLayout {
    /// <summary>
    /// Defines the value of the first argument of `NLogEvents.Events.OnLog`.
    /// The default is `null`.
    /// </summary>
    public string Event { get; set; }

    protected override void Write(LogEventInfo info) => Events.FireOnLog(Event, info);
  }
}
