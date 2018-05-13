namespace SMS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelEstado = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbOpcion = new System.Windows.Forms.ComboBox();
            this.tbTotalReparacion = new System.Windows.Forms.TextBox();
            this.tbNumeroCelular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumeroCelularPersonalizado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMensajePersonalizado = new System.Windows.Forms.TextBox();
            this.lblConteo = new System.Windows.Forms.Label();
            this.btnEnviarMensajePersonalizado = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEstado, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 333);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(3, 296);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 0;
            this.labelEstado.Text = "Estado:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 290);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEnviarMensaje);
            this.tabPage1.Controls.Add(this.cbOpcion);
            this.tabPage1.Controls.Add(this.tbTotalReparacion);
            this.tabPage1.Controls.Add(this.tbNumeroCelular);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mensaje Servicios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbOpcion
            // 
            this.cbOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpcion.FormattingEnabled = true;
            this.cbOpcion.Items.AddRange(new object[] {
            "Reparación Automóvil",
            "Servicio Externo"});
            this.cbOpcion.Location = new System.Drawing.Point(133, 135);
            this.cbOpcion.Name = "cbOpcion";
            this.cbOpcion.Size = new System.Drawing.Size(139, 21);
            this.cbOpcion.TabIndex = 5;
            // 
            // tbTotalReparacion
            // 
            this.tbTotalReparacion.Location = new System.Drawing.Point(133, 78);
            this.tbTotalReparacion.Name = "tbTotalReparacion";
            this.tbTotalReparacion.Size = new System.Drawing.Size(139, 20);
            this.tbTotalReparacion.TabIndex = 4;
            this.tbTotalReparacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTotalReparacion_KeyPress);
            // 
            // tbNumeroCelular
            // 
            this.tbNumeroCelular.Location = new System.Drawing.Point(134, 24);
            this.tbNumeroCelular.Name = "tbNumeroCelular";
            this.tbNumeroCelular.Size = new System.Drawing.Size(139, 20);
            this.tbNumeroCelular.TabIndex = 3;
            this.tbNumeroCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeroCelular_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Seleccione una Opción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número de Celular:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEnviarMensajePersonalizado);
            this.tabPage2.Controls.Add(this.lblConteo);
            this.tabPage2.Controls.Add(this.tbMensajePersonalizado);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbNumeroCelularPersonalizado);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mensaje Personalizado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Location = new System.Drawing.Point(90, 205);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(110, 23);
            this.btnEnviarMensaje.TabIndex = 6;
            this.btnEnviarMensaje.Text = "Enviar Mensaje";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Celular:";
            // 
            // tbNumeroCelularPersonalizado
            // 
            this.tbNumeroCelularPersonalizado.Location = new System.Drawing.Point(109, 29);
            this.tbNumeroCelularPersonalizado.Name = "tbNumeroCelularPersonalizado";
            this.tbNumeroCelularPersonalizado.Size = new System.Drawing.Size(136, 20);
            this.tbNumeroCelularPersonalizado.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mensaje:";
            // 
            // tbMensajePersonalizado
            // 
            this.tbMensajePersonalizado.Location = new System.Drawing.Point(3, 71);
            this.tbMensajePersonalizado.MaxLength = 160;
            this.tbMensajePersonalizado.Multiline = true;
            this.tbMensajePersonalizado.Name = "tbMensajePersonalizado";
            this.tbMensajePersonalizado.Size = new System.Drawing.Size(278, 94);
            this.tbMensajePersonalizado.TabIndex = 3;
            this.tbMensajePersonalizado.Text = "Clutch y Frenos Anguiano le informa";
            this.tbMensajePersonalizado.TextChanged += new System.EventHandler(this.tbMensajePersonalizado_TextChanged);
            // 
            // lblConteo
            // 
            this.lblConteo.AutoSize = true;
            this.lblConteo.Location = new System.Drawing.Point(9, 172);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Size = new System.Drawing.Size(49, 13);
            this.lblConteo.TabIndex = 4;
            this.lblConteo.Text = "0 de 160";
            // 
            // btnEnviarMensajePersonalizado
            // 
            this.btnEnviarMensajePersonalizado.Location = new System.Drawing.Point(90, 211);
            this.btnEnviarMensajePersonalizado.Name = "btnEnviarMensajePersonalizado";
            this.btnEnviarMensajePersonalizado.Size = new System.Drawing.Size(115, 23);
            this.btnEnviarMensajePersonalizado.TabIndex = 5;
            this.btnEnviarMensajePersonalizado.Text = "Enviar Mensaje";
            this.btnEnviarMensajePersonalizado.UseVisualStyleBackColor = true;
            this.btnEnviarMensajePersonalizado.Click += new System.EventHandler(this.btnEnviarMensajePersonalizado_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbNumeroCelular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbTotalReparacion;
        private System.Windows.Forms.ComboBox cbOpcion;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.TextBox tbMensajePersonalizado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumeroCelularPersonalizado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnviarMensajePersonalizado;
    }
}

