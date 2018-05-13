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
using Utils.Correo;
using Utils.CreacionLog;
using System.IO;
using System.Net.NetworkInformation;

namespace SMS
{
    public partial class Form1 : Form
    {
        private int puertoCOM = 1;
        private GsmCommMain comm;
        string mensaje = string.Empty;
        public Form1()
        {
            InitializeComponent();
            labelEstado.Text = "BAM Conectada";
        }
        public void EnviarMensajeCliente(string numeroCelular,string mensaje)
        {
            string rutaCurl = ConfigurationManager.AppSettings["rutaCurl"];
            string respuestaCurl = ConfigurationManager.AppSettings["respuestaCurl"];
            decimal precio = Convert.ToDecimal(this.tbTotalReparacion.Text);
            mensaje += precio.ToString("N")+" "+"pesos.";
            try
            {
                if (PingHost("192.168.8.1"))//192.168.8.1 ip de BAM
                {
                    mensaje = QuitarAcentos(mensaje);
                    var lines = File.ReadAllLines(rutaCurl);//Ruta donde se guardara el archivo bash
                    lines[3] = "NUMBER=\"" + numeroCelular + "\"";//Se modifica la linea para agregar el celular ingresado
                    lines[4] = "MESSAGE=\"" + mensaje + "\"";//Se modifica la linea para agregar el mensaje por default 
                    File.WriteAllLines(rutaCurl, lines);//Ruta donde se guarda el de nueva cuenta el archivo esta es igual a la linea de un poco mas arriba
                    ProcessStartInfo p = new ProcessStartInfo(rutaCurl);//ruta para ejecutar el bash misma que la de arriba
                    p.CreateNoWindow = false;
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    Process process = Process.Start(p);
                    process.WaitForExit();
                    FileStream fs = new FileStream(respuestaCurl, FileMode.Open);//ruta de respuesta del request
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    string s = Encoding.ASCII.GetString(bytes);
                    bool b = s.Contains("OK");
                    if (b)
                    {
                        MessageBox.Show("Mensaje Enviado");
                        this.tbNumeroCelular.Text = "";
                        this.tbTotalReparacion.Text = "";
                        fs.Close();
                    }
                    else
                    {
                        if (string.Compare(s, "\n") != 0)
                        {
                            string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                            + " Mensaje: " + mensaje
                            + " Error: " + s;
                            new LogAplicacion().Error(error);
                            NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                            Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error));
                            thread.Start();
                            MessageBox.Show("Mensaje no Enviado, Ocurrio un error");
                            this.tbNumeroCelular.Text = "";
                            this.tbTotalReparacion.Text = "";
                            fs.Close();
                        }
                        else
                        {
                            s = "BAM No Conectada";
                            this.labelEstado.Text = "BAM No Conectada";
                            this.tbNumeroCelular.Text = "";
                            this.tbTotalReparacion.Text = "";
                            this.tbNumeroCelular.Enabled = false;
                            this.tbTotalReparacion.Enabled = false;
                            MessageBox.Show("BAM No Conectada. Cierre la aplicacion, conecta la BAM y ejecute la aplicacion.");
                            string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                            + " Mensaje: " + mensaje
                            + " Error: " + s;
                            new LogAplicacion().Error(error);
                            NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                            Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error));
                            thread.Start();
                            fs.Close();
                        }
                    }
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("Favor de Conectar la BAM");
                }
                //Process.Start(@"C:\Program Files\Git\git-bash.exe");//Ruta del archivo a ejecutar
                //SmsSubmitPdu pdu;
                //byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                //pdu = new SmsSubmitPdu(mensaje,numeroCelular, dcs);
                //comm.SendMessage(pdu, false);
            }
            catch (Exception ex)
            {
                string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                + " Mensaje: " + mensaje
                + " Error: " + ex;
                // + ", señal del dispositivo: " + comm.GetSignalQuality().SignalStrength;
                new LogAplicacion().Error(error);
                NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error));
                thread.Start();
                //ReiniciarConexionCOM();
            }
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
                        new LogAplicacion().Info("Conexion de BAM exitosa, señal del dispositivo: " + comm.GetSignalQuality().SignalStrength
                            + "\n Datos BAM: \n *" + nombreBAM + "\n *" + modelBAM + "\n *" + numRevisionBAM + "\n *" + numSerieBAM
                            );
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
                        NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                        Thread thread = new Thread(x=>notificacionCorreo.EnviarThread("Verifique que la banda ancha (bam) este conectada al equipo..!!<br></br>Se recomienda cerrar la aplicacion e intentar de nuevo <br></br>Error: " + ex));
                        thread.Start();
                        new LogAplicacion().Error(ex.Message);
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
                new LogAplicacion().Info("Reiniciando conexion de BAM...");
                comm.Close();
                LiberarPuertoCOM();
                Thread.Sleep(10000);
                CrearConexionCOM();
            }
            catch (Exception e)
            {
                new LogAplicacion().Error("Ocurrio un error al ejecutar la funcion ReiniciarConexionCOM() <br></br>Error: " + e);
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
                new LogAplicacion().Error("Ocurrio un error al ejecutar la funcion QuitarAcentos()" + e);
            }
            return mensaje;
        }
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            string numero = this.tbNumeroCelular.Text;
            string precio = this.tbTotalReparacion.Text;
            if (string.Compare(numero, "") != 0)
            {
                if (IsNumeric(numero))
                {
                    if (numero.Length < 10 || numero.Length > 10)
                    {
                        MessageBox.Show("El número debe contener 10 dígitos");
                    }
                    else
                    {
                        if (string.Compare(precio, "") == 0)
                        {
                            MessageBox.Show("Debe agregar el costo de la reparacion");
                        }
                        else
                        {
                            if (string.Compare(this.cbOpcion.Text, "Reparación Automóvil") == 0)
                            {
                                //Desde aqui enviar el mensaje que se desea enviar
                                mensaje = ConfigurationManager.AppSettings["MensajeReparacion"];
                                EnviarMensajeCliente(numero, mensaje);

                            }
                            else if (string.Compare(this.cbOpcion.Text, "Servicio Externo") == 0)
                            {
                                //Desde aqui enviar el mensaje que se desea enviar
                                mensaje = ConfigurationManager.AppSettings["MensajeServicio"];
                                EnviarMensajeCliente(numero, mensaje);
                            }
                            else
                            {
                                MessageBox.Show("Debe Seleccionar una Opción");
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Solo se permite el uso de números");
                }
            }
            else
            {
                MessageBox.Show("Debe de introducir un número de celular con 10 dígitos");
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
        private void tbTotalReparacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tbTotalReparacion.Text.Length; i++)
            {
                if (tbTotalReparacion.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void tbMensajePersonalizado_TextChanged(object sender, EventArgs e)
        {
            lblConteo.Text = tbMensajePersonalizado.Text.Length.ToString() +" de 160";
        }
        private void btnEnviarMensajePersonalizado_Click(object sender, EventArgs e)
        {
            string numero = this.tbNumeroCelularPersonalizado.Text;
            string mensajePersonalizado = tbMensajePersonalizado.Text;
            if (string.Compare(numero, "") != 0)
            {
                if (IsNumeric(numero))
                {
                    if (numero.Length < 10 || numero.Length > 10)
                    {
                        MessageBox.Show("El número debe contener 10 dígitos");
                    }
                    else
                    {
                        if (mensajePersonalizado.Length <= 36)
                        {
                            MessageBox.Show("Debe escribir un mensaje para el receptor");
                        }
                        else
                        {
                            EnviarMensajePersonalizado(numero, mensajePersonalizado);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Solo se permite el uso de números");
                }
            }
            else
            {
                MessageBox.Show("Debe de introducir un número de celular con 10 dígitos");
            }
        }
        public void EnviarMensajePersonalizado(string numeroCelular, string mensaje)
        {
            string rutaCurl = ConfigurationManager.AppSettings["rutaCurl"];
            string respuestaCurl = ConfigurationManager.AppSettings["respuestaCurl"];
            //decimal precio = Convert.ToDecimal(this.tbTotalReparacion.Text);
            //mensaje += precio.ToString("N") + " " + "pesos.";
            try
            {
                if (PingHost("192.168.8.1"))//192.168.8.1 ip de BAM
                {
                    mensaje = QuitarAcentos(mensaje);
                    var lines = File.ReadAllLines(rutaCurl);//Ruta donde se guardara el archivo bash
                    lines[3] = "NUMBER=\"" + numeroCelular + "\"";//Se modifica la linea para agregar el celular ingresado
                    lines[4] = "MESSAGE=\"" + mensaje + "\"";//Se modifica la linea para agregar el mensaje por default 
                    File.WriteAllLines(rutaCurl, lines);//Ruta donde se guarda el de nueva cuenta el archivo esta es igual a la linea de un poco mas arriba
                    ProcessStartInfo p = new ProcessStartInfo(rutaCurl);//ruta para ejecutar el bash misma que la de arriba
                    p.CreateNoWindow = false;
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    Process process = Process.Start(p);
                    process.WaitForExit();
                    FileStream fs = new FileStream(respuestaCurl, FileMode.Open);//ruta de respuesta del request
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    string s = Encoding.ASCII.GetString(bytes);
                    bool b = s.Contains("OK");
                    if (b)
                    {
                        MessageBox.Show("Mensaje Enviado");
                        this.tbNumeroCelularPersonalizado.Text = "";
                        this.tbMensajePersonalizado.Text = "Clutch y Frenos Anguiano le informa";
                        fs.Close();
                    }
                    else
                    {
                        if (string.Compare(s, "\n") != 0)
                        {
                            string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                            + " Mensaje: " + mensaje
                            + " Error: " + s;
                            new LogAplicacion().Error(error);
                            NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                            Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajePersonalizado() <br></br>Error: " + error));
                            thread.Start();
                            MessageBox.Show("Mensaje no Enviado, Ocurrio un error");
                            this.tbNumeroCelularPersonalizado.Text = "";
                            this.tbMensajePersonalizado.Text = "Clutch y Frenos Anguiano le informa";
                            fs.Close();
                        }
                        else
                        {
                            s = "BAM No Conectada";
                            this.labelEstado.Text = "BAM No Conectada";
                            this.tbNumeroCelularPersonalizado.Text = "";
                            this.tbNumeroCelularPersonalizado.Text = "Clutch y Frenos Anguiano le informa";
                            this.tbNumeroCelularPersonalizado.Enabled = false;
                            this.tbMensajePersonalizado.Enabled = false;
                            MessageBox.Show("BAM No Conectada. Cierre la aplicacion, conecta la BAM y ejecute la aplicacion.");
                            string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                            + " Mensaje: " + mensaje
                            + " Error: " + s;
                            new LogAplicacion().Error(error);
                            NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                            Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajePersonalizado() <br></br>Error: " + error));
                            thread.Start();
                            fs.Close();
                        }
                    }
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("Favor de Conectar la BAM");
                }
                //Process.Start(@"C:\Program Files\Git\git-bash.exe");//Ruta del archivo a ejecutar
                //SmsSubmitPdu pdu;
                //byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                //pdu = new SmsSubmitPdu(mensaje,numeroCelular, dcs);
                //comm.SendMessage(pdu, false);
            }
            catch (Exception ex)
            {
                string error = "Ocurrio un error al ejecutar la funcion EnviarMensajeCliente, Con los siguientes datos: Telefono :" + numeroCelular
                + " Mensaje: " + mensaje
                + " Error: " + ex;
                // + ", señal del dispositivo: " + comm.GetSignalQuality().SignalStrength;
                new LogAplicacion().Error(error);
                NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error));
                thread.Start();
                //ReiniciarConexionCOM();
            }
        }
    }
}
