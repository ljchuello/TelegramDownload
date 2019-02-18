namespace TelegramDownload
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
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.lblDescargados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(12, 29);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(296, 20);
            this.txtDestino.TabIndex = 0;
            this.txtDestino.Text = "C:\\Telegram";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ubicación de destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(12, 82);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(296, 20);
            this.txtToken.TabIndex = 2;
            this.txtToken.Text = "618455177:AAGy4lkSVAYzghUVulPr_oNhSZdBL5VCUsY";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 109);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(296, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(12, 138);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(296, 23);
            this.btnDetener.TabIndex = 5;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.Location = new System.Drawing.Point(13, 164);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(10, 13);
            this.lblEstatus.TabIndex = 6;
            this.lblEstatus.Text = "-";
            // 
            // lblDescargados
            // 
            this.lblDescargados.AutoSize = true;
            this.lblDescargados.Location = new System.Drawing.Point(13, 177);
            this.lblDescargados.Name = "lblDescargados";
            this.lblDescargados.Size = new System.Drawing.Size(10, 13);
            this.lblDescargados.TabIndex = 7;
            this.lblDescargados.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 218);
            this.Controls.Add(this.lblDescargados);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestino);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.Label lblDescargados;
    }
}

