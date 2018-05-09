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

namespace SMS
{
    public partial class Form1 : Form
    {
        private int puertoCOM = 1;
        private GsmCommMain comm;
        public Form1()
        {
            InitializeComponent();
            if (CrearConexionCOM())
            {
                labelEstado.Text = "BAM Conectada";
                labelSenalBAM.Text = Convert.ToString(comm.GetSignalQuality().SignalStrength);
            }
            else
            {
                labelEstado.Text = "BAM Desconectada";
                labelSenalBAM.Text = "No Disponible";
                btnEnviarMensaje.Enabled = false;
                tbNumeroCelular.Enabled = false;
            }

        }
        public void EnviarMensajeCliente(string numeroCelular)
        {
            String mensaje = ConfigurationManager.AppSettings["MensajeGSM"];
            string precio = this.tbTotalRepacacion.Text;
            mensaje += precio;
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
                new LogAplicacion().Error(error);
                NotificacionCorreo notificacionCorreo = new NotificacionCorreo();
                Thread thread = new Thread(x => notificacionCorreo.EnviarThread("Ocurrio un error al ejecutar la funcion EnviarMensajeCliente() <br></br>Error: " + error));
                thread.Start();
                ReiniciarConexionCOM();
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
                    EnviarMensajeCliente(numero);
                    //MessageBox.Show("Ya casi");
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
                new LogAplicacion().Error("Ocurrio un error al ejecutar la funcion QuitarAcentos()" + e);
            }
            return mensaje;
        }
    }
}
