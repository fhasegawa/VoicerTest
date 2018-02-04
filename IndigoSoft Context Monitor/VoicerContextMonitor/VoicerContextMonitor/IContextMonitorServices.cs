using System;
using VoicerContextMonitor.Model;

namespace Voicer.Context.Monitor
{
    public interface IContextMonitorServices
    {
        MonitoringContextMatchResult GetActionInfo(long callId, long contextId, long phraseId);
    }
}