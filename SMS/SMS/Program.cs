using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new Form1().PingHost("192.168.8.1"))//192.168.8.1
            {
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Favor de Conectar la BAM y abrir de nuevo la aplicacion");
                Application.Exit();
            }
        }
    }
}
