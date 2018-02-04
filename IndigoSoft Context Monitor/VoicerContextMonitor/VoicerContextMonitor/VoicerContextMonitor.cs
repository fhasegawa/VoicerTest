using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoicerContextMonitor.Model;

namespace Voicer.Context.Monitor
{
    public class VoicerContextMonitor : IContextMonitorServices
    {
        private static VoicerContextMonitor _monitor;
        readonly private string _connection;

        private VoicerContextMonitor()
        {
            this._connection = "Server=192.168.12.8\\SQLVOICER;Database=VoicerPlatformQueue;User Id=usr_indigo;Password=!nd!g0s0ft;";
        }

        static public VoicerContextMonitor GetInstance()
        {
            if (_monitor == null)
                _monitor = new VoicerContextMonitor();
            return _monitor;
        }

        public MonitoringContextMatchResult GetActionInfo(long callId, long contextId, long phraseId)
        {
            MonitoringContextMatchResult result = new MonitoringContextMatchResult();
            try
            {
                using (var cn = new SqlConnection(_connection))
                {
                    cn.Open();
                    using (var cm = new SqlCommand("[icc_Digital_Monitoring].[dbo].[usp_GetActionByCallId]", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@CallId", callId);
                        cm.Parameters.AddWithValue("@ContextId", contextId);
                        cm.Parameters.AddWithValue("@PhraseId", phraseId);

                        using (var dr = cm.ExecuteReader())
                            while (dr.Read())
                            {
                                result.Action = dr["Action"]?.ToString();
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }
    }
}
