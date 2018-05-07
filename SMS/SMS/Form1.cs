using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System.Configuration;
namespace SMS
{
    public partial class Form1 : Form
    {
        private int puertoCOM = 1;
        private GsmCommMain comm;
        string asunto = string.Empty;
        string cuerpo = string.Empty;
        string emisor = string.Empty;
        string destinatario = string.Empty;
        string servidor = string.Empty;
        string contrasena = string.Empty;
        int puerto;
        public Form1()
        {
            InitializeComponent();
            CrearLog();
            if (CrearConexionCOM())
            {
                labelEstado.Text = "BAM Conectada";
            }
            else
            {
                labelEstado.Text = "BAM Desconectada";
                btnEnviarMensaje.Enabled = false;
                tbNumeroCelular.Enabled = false;
            }

        }
        public void EnviarMensajeCliente(string numeroCelular)
        {
            String mensaje = ConfigurationManager.AppSettings["MensajeGSM"];
            try
            {
               
                mensaje = QuitarAcentos(mensaje);
                SmsSubmitPdu pdu;
                byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                pdu = new SmsSubmitPdu(mensaje,numeroCelular, dcs);
                comm.SendMessage(pdu, false);

            }
            catch (Exception ex)
            {
                string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                + " Mensaje: " //+ MensajeGSM
                + " Error: " + ex + ", señal del dispositivo: " + comm.GetSignalQuality().SignalStrength;
                eventLog1.WriteEntry(error, EventLogEntryType.Error);
                NotificacionCorreo("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error);
                ReiniciarConexionCOM();
            }
        }
        public void CrearLog()
        {
            if (!System.Diagnostics.EventLog.SourceExists("LogServicioMensajes"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "LogServicioMensajes", "NewLogServicioMensajes");
            }
            eventLog1.Source = "LogServicioMensajes";
            eventLog1.Log = "NewLogServicioMensajes";
            eventLog1.WriteEntry("Inicio de Aplicacion de SMS");
        }
        public bool CrearConexionCOM()
        {
            bool retry = true; ;
            do
            {
                comm = new GsmCommMain("COM" + puertoCOM, 9600, 150);
                try
                {
                    comm.Open();
                    if (comm.IsConnected())
                    {
                        //eventLog.WriteEntry("Conexion de BAM exitosa, señal del dispositivo: " + comm.GetSignalQuality().SignalStrength,EventLogEntryType.Information);
                        string nombreBAM = comm.IdentifyDevice().Manufacturer.ToUpper().ToString();
                        string modelBAM = comm.IdentifyDevice().Model.ToUpper().ToString();
                        string numRevisionBAM = comm.IdentifyDevice().Revision.ToUpper().ToString();
                        string numSerieBAM = comm.IdentifyDevice().SerialNumber.ToUpper().ToString();
                        eventLog1.WriteEntry("Conexion de BAM exitosa, señal del dispositivo: " + comm.GetSignalQuality().SignalStrength
                            + "\n Datos BAM: \n *" + nombreBAM + "\n *" + modelBAM + "\n *" + numRevisionBAM + "\n *" + numSerieBAM
                            , EventLogEntryType.Information);
                        return true;
                    }
                    else
                    {
                        comm.Close();
                        puertoCOM++;
                    }
                }
                catch (Exception ex)
                {
                    if (puertoCOM >= 50)//recorre hasta el puerto 50
                    {
                        NotificacionCorreo("Verifique que la banda ancha (bam) este conectada al equipo..!!<br></br>Se recomienda cerrar la aplicacion e intentar de nuevo <br></br>Error: " + ex);
                        eventLog1.WriteEntry(ex.Message, EventLogEntryType.Error);
                        return false;
                    }
                    puertoCOM++;
                    retry = true;
                }
            }
            while (retry);
            return false;
        }
        public void ReiniciarConexionCOM()
        {
            try
            {
                eventLog1.WriteEntry("Reiniciando conexion de BAM...", EventLogEntryType.Information);
                comm.Close();
                LiberarPuertoCOM();
                Thread.Sleep(10000);
                CrearConexionCOM();
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry("Ocurrio un error al ejecutar la funcion ReiniciarConexionCOM() <br></br>Error: " + e, EventLogEntryType.Error);
            }
        }
        public void LiberarPuertoCOM()
        {
            try
            {
                System.IO.Ports.SerialPort myPort = new System.IO.Ports.SerialPort("COM" + puertoCOM);
                myPort.Close();
                myPort.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            string numero = this.tbNumeroCelular.Text;

            if (IsNumeric(numero))
            {
                if (numero.Length < 10 || numero.Length > 10)
                {
                    MessageBox.Show("El número debe contener 10 dígitos");
                }
                else
                {
                    //EnviarMensajeCliente(numero);
                    MessageBox.Show("Ya casi");
                }
            }
            else
            {
                MessageBox.Show("Solo se permite el uso de números");
            }
        }

        private void tbNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }
        private bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public String QuitarAcentos(String mensaje)
        {
            try
            {
                string con = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
                string sin = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcC";
                for (int i = 0; i < con.Length; i++)
                {
                    mensaje = mensaje.Replace(con[i], sin[i]);
                }
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry("Ocurrio un error al ejecutar la funcion QuitarAcentos()" + e, EventLogEntryType.Error);
            }
            return mensaje;
        }
        public void NotificacionCorreo (String notificacion)
        {
            asunto = ConfigurationManager.AppSettings["asunto"];
            cuerpo = ConfigurationManager.AppSettings["cuerpo"];
            emisor = ConfigurationManager.AppSettings["emisor"];
            contrasena = ConfigurationManager.AppSettings["contrasena"];
            destinatario = ConfigurationManager.AppSettings["destinatario"];
            servidor = ConfigurationManager.AppSettings["servidor"];
            puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emisor);
                mail.IsBodyHtml = true;
                mail.Subject = asunto;
                mail.Body += cuerpo + "<br></br>" + notificacion;
                mail.To.Add(new MailAddress(destinatario));
                //mail.Bcc.Add(correoCopia);
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(emisor,contrasena);
                client.EnableSsl = true;
                client.Port = puerto;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = servidor;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(htmlView);
                client.Send(mail);
            }
            catch (Exception ex) { eventLog1.WriteEntry(ex.Message, EventLogEntryType.Error); }
        }
    }
}
