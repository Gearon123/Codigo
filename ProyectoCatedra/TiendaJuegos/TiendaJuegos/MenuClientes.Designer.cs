namespace TiendaJuegos
{
    partial class MenuClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuClientes));
            this.label5 = new System.Windows.Forms.Label();
            this.btnrealizarcompra = new System.Windows.Forms.Button();
            this.btnverC = new System.Windows.Forms.Button();
            this.btncerrarcuentaC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 31);
            this.label5.TabIndex = 16;
            this.label5.Text = "¿Qué acción deseas realizar?";
            // 
            // btnrealizarcompra
            // 
            this.btnrealizarcompra.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrealizarcompra.Location = new System.Drawing.Point(76, 120);
            this.btnrealizarcompra.Name = "btnrealizarcompra";
            this.btnrealizarcompra.Size = new System.Drawing.Size(348, 52);
            this.btnrealizarcompra.TabIndex = 17;
            this.btnrealizarcompra.Text = "Realizar una compra";
            this.btnrealizarcompra.UseVisualStyleBackColor = true;
            this.btnrealizarcompra.Click += new System.EventHandler(this.btnrealizarcompra_Click);
            // 
            // btnverC
            // 
            this.btnverC.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverC.Location = new System.Drawing.Point(76, 215);
            this.btnverC.Name = "btnverC";
            this.btnverC.Size = new System.Drawing.Size(348, 52);
            this.btnverC.TabIndex = 18;
            this.btnverC.Text = "Ver mi cuenta";
            this.btnverC.UseVisualStyleBackColor = true;
            this.btnverC.Click += new System.EventHandler(this.btnverC_Click);
            // 
            // btncerrarcuentaC
            // 
            this.btncerrarcuentaC.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrarcuentaC.Location = new System.Drawing.Point(76, 303);
            this.btncerrarcuentaC.Name = "btncerrarcuentaC";
            this.btncerrarcuentaC.Size = new System.Drawing.Size(348, 52);
            this.btncerrarcuentaC.TabIndex = 19;
            this.btncerrarcuentaC.Text = "Cerrar sesión";
            this.btncerrarcuentaC.UseVisualStyleBackColor = true;
            this.btncerrarcuentaC.Click += new System.EventHandler(this.btncerrarcuentaC_Click);
            // 
            // MenuClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(539, 423);
            this.Controls.Add(this.btncerrarcuentaC);
            this.Controls.Add(this.btnverC);
            this.Controls.Add(this.btnrealizarcompra);
            this.Controls.Add(this.label5);
            this.Name = "MenuClientes";
            this.Text = "MenuClientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnrealizarcompra;
        private System.Windows.Forms.Button btnverC;
        private System.Windows.Forms.Button btncerrarcuentaC;
    }
}