using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.CreacionLog
{
    public class LogAplicacion
    {
        EventLog m_EventLog = null;
        public LogAplicacion()
        {
            try
            {
                if (m_EventLog == null)
                    m_EventLog = new EventLog("SMSLog");
                m_EventLog.Source = "SMS";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear Event Log"); ;
            }
        }
        private string Fuente { get; set; }

        public void Info(string mensaje)
        {
            try
            {
                m_EventLog.WriteEntry(mensaje, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al escribir" + ex.Message);
            }

        }

        public void Warning(string mensaje)
        {
            m_EventLog.WriteEntry(mensaje, EventLogEntryType.Warning);
        }

        public void Error(string mensaje)
        {
            m_EventLog.WriteEntry(mensaje, EventLogEntryType.Error);
        }

        public void gitIgnore()
        {
        }
    }
}
