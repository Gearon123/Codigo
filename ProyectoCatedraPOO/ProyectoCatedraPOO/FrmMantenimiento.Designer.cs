namespace ProyectoCatedraPOO
{
    partial class FrmMantenimiento
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
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnJuegos = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(52, 88);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(145, 124);
            this.btnCategoria.TabIndex = 0;
            this.btnCategoria.Text = "Categorias";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnJuegos
            // 
            this.btnJuegos.Location = new System.Drawing.Point(237, 88);
            this.btnJuegos.Name = "btnJuegos";
            this.btnJuegos.Size = new System.Drawing.Size(145, 124);
            this.btnJuegos.TabIndex = 1;
            this.btnJuegos.Text = "Juegos";
            this.btnJuegos.UseVisualStyleBackColor = true;
            this.btnJuegos.Click += new System.EventHandler(this.btnJuegos_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 48;
            this.button2.Text = "Cerrar sesion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 263);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnJuegos);
            this.Controls.Add(this.btnCategoria);
            this.Name = "FrmMantenimiento";
            this.Text = "FrmMantenimiento";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnJuegos;
        private System.Windows.Forms.Button button2;
    }
}