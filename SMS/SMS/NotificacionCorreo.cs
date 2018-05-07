using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    public class NotificacionCorreo
    {
        string asunto = string.Empty;
        string cuerpo = string.Empty;
        string emisor = string.Empty;
        string destinatario = string.Empty;
        string servidor = string.Empty;
        string contrasena = string.Empty;
        int puerto;
        public void EnviarThread(string notificacion)
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
                client.Credentials = new NetworkCredential(emisor, contrasena);
                client.EnableSsl = true;
                client.Port = puerto;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = servidor;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body.ToString(), Encoding.UTF8, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(htmlView);
                client.Send(mail);
            }
            catch (Exception ex)
            {
                //eventLog1.WriteEntry(ex.Message, EventLogEntryType.Error); 
            }
        }
    }
}
