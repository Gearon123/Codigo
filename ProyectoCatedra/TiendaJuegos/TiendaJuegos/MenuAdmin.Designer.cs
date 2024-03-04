namespace TiendaJuegos
{
    partial class MenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.label5 = new System.Windows.Forms.Label();
            this.btnaddjuegos = new System.Windows.Forms.Button();
            this.btnmodclientes = new System.Windows.Forms.Button();
            this.btncerrarcuentaA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "¿Qué acción deseas realizar?";
            // 
            // btnaddjuegos
            // 
            this.btnaddjuegos.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddjuegos.Location = new System.Drawing.Point(71, 122);
            this.btnaddjuegos.Name = "btnaddjuegos";
            this.btnaddjuegos.Size = new System.Drawing.Size(348, 77);
            this.btnaddjuegos.TabIndex = 18;
            this.btnaddjuegos.Text = "Añadir juegos al catálogo";
            this.btnaddjuegos.UseVisualStyleBackColor = true;
            this.btnaddjuegos.Click += new System.EventHandler(this.btnaddjuegos_Click);
            // 
            // btnmodclientes
            // 
            this.btnmodclientes.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodclientes.Location = new System.Drawing.Point(71, 228);
            this.btnmodclientes.Name = "btnmodclientes";
            this.btnmodclientes.Size = new System.Drawing.Size(348, 85);
            this.btnmodclientes.TabIndex = 19;
            this.btnmodclientes.Text = "Añadir clientes manualmente";
            this.btnmodclientes.UseVisualStyleBackColor = true;
            // 
            // btncerrarcuentaA
            // 
            this.btncerrarcuentaA.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrarcuentaA.Location = new System.Drawing.Point(71, 355);
            this.btncerrarcuentaA.Name = "btncerrarcuentaA";
            this.btncerrarcuentaA.Size = new System.Drawing.Size(348, 52);
            this.btncerrarcuentaA.TabIndex = 20;
            this.btncerrarcuentaA.Text = "Cerrar sesión";
            this.btncerrarcuentaA.UseVisualStyleBackColor = true;
            this.btncerrarcuentaA.Click += new System.EventHandler(this.btncerrarcuentaA_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(491, 474);
            this.Controls.Add(this.btncerrarcuentaA);
            this.Controls.Add(this.btnmodclientes);
            this.Controls.Add(this.btnaddjuegos);
            this.Controls.Add(this.label5);
            this.Name = "MenuAdmin";
            this.Text = "MenuAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnaddjuegos;
        private System.Windows.Forms.Button btnmodclientes;
        private System.Windows.Forms.Button btncerrarcuentaA;
    }
}