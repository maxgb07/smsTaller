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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumeroCelular = new System.Windows.Forms.TextBox();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTotalReparacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Celular";
            // 
            // tbNumeroCelular
            // 
            this.tbNumeroCelular.Location = new System.Drawing.Point(131, 50);
            this.tbNumeroCelular.Name = "tbNumeroCelular";
            this.tbNumeroCelular.Size = new System.Drawing.Size(143, 20);
            this.tbNumeroCelular.TabIndex = 1;
            this.tbNumeroCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumeroCelular_KeyPress);
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Location = new System.Drawing.Point(96, 237);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(121, 23);
            this.btnEnviarMensaje.TabIndex = 2;
            this.btnEnviarMensaje.Text = "Enviar Mensaje";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado: ";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(46, 311);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(0, 13);
            this.labelEstado.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio Reparacion";
            // 
            // tbTotalReparacion
            // 
            this.tbTotalReparacion.Location = new System.Drawing.Point(131, 108);
            this.tbTotalReparacion.Name = "tbTotalReparacion";
            this.tbTotalReparacion.Size = new System.Drawing.Size(143, 20);
            this.tbTotalReparacion.TabIndex = 8;
            this.tbTotalReparacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTotalRepacacion_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 333);
            this.Controls.Add(this.tbTotalReparacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Controls.Add(this.tbNumeroCelular);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.TextBox tbNumeroCelular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTotalReparacion;
    }
}

