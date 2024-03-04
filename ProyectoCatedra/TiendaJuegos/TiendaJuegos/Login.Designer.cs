namespace TiendaJuegos
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuarioL = new System.Windows.Forms.TextBox();
            this.txtContrasenaL = new System.Windows.Forms.TextBox();
            this.btniniciodesesion = new System.Windows.Forms.Button();
            this.btnregistrarcuenta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // txtUsuarioL
            // 
            this.txtUsuarioL.Location = new System.Drawing.Point(260, 107);
            this.txtUsuarioL.Multiline = true;
            this.txtUsuarioL.Name = "txtUsuarioL";
            this.txtUsuarioL.Size = new System.Drawing.Size(248, 31);
            this.txtUsuarioL.TabIndex = 7;
            // 
            // txtContrasenaL
            // 
            this.txtContrasenaL.Location = new System.Drawing.Point(260, 164);
            this.txtContrasenaL.Multiline = true;
            this.txtContrasenaL.Name = "txtContrasenaL";
            this.txtContrasenaL.PasswordChar = '*';
            this.txtContrasenaL.Size = new System.Drawing.Size(248, 31);
            this.txtContrasenaL.TabIndex = 8;
            // 
            // btniniciodesesion
            // 
            this.btniniciodesesion.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniniciodesesion.Location = new System.Drawing.Point(64, 260);
            this.btniniciodesesion.Name = "btniniciodesesion";
            this.btniniciodesesion.Size = new System.Drawing.Size(195, 52);
            this.btniniciodesesion.TabIndex = 11;
            this.btniniciodesesion.Text = "Iniciar sesión";
            this.btniniciodesesion.UseVisualStyleBackColor = true;
            this.btniniciodesesion.Click += new System.EventHandler(this.btniniciodesesion_Click);
            // 
            // btnregistrarcuenta
            // 
            this.btnregistrarcuenta.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistrarcuenta.Location = new System.Drawing.Point(353, 307);
            this.btnregistrarcuenta.Name = "btnregistrarcuenta";
            this.btnregistrarcuenta.Size = new System.Drawing.Size(232, 52);
            this.btnregistrarcuenta.TabIndex = 12;
            this.btnregistrarcuenta.Text = "Registrar cuenta";
            this.btnregistrarcuenta.UseVisualStyleBackColor = true;
            this.btnregistrarcuenta.Click += new System.EventHandler(this.btnregistrarcuenta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "¿No tienes cuenta?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 31);
            this.label4.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(539, 31);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inicia sesión para conocer nuestro catálogo";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(652, 399);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnregistrarcuenta);
            this.Controls.Add(this.btniniciodesesion);
            this.Controls.Add(this.txtContrasenaL);
            this.Controls.Add(this.txtUsuarioL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuarioL;
        private System.Windows.Forms.TextBox txtContrasenaL;
        private System.Windows.Forms.Button btniniciodesesion;
        private System.Windows.Forms.Button btnregistrarcuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}