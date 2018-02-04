using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoicerContextMonitor;
using VoicerContextMonitor.Model;

namespace Voicer.ContextMonitorTester
{
    class Program
    {
        static void Main(string[] args)
        {
            long callId = 10640115;
            long contextId = 5;
            long phraseId = 104146;

            MonitoringContextMatchResult result = new MonitoringContextMatchResult();

            Voicer.Context.Monitor.IContextMonitorServices monitor = Voicer.Context.Monitor.VoicerContextMonitor.GetInstance();
            result = monitor.GetActionInfo(callId, contextId, phraseId);

            string teste = String.Empty;
        }
    }
}
