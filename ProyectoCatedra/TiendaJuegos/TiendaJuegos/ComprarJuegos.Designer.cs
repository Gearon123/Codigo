namespace TiendaJuegos
{
    partial class ComprarJuegos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprarJuegos));
            this.btnvolver = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvjuegosdisponibles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvjuegosdisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnvolver
            // 
            this.btnvolver.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvolver.Location = new System.Drawing.Point(89, 427);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(225, 52);
            this.btnvolver.TabIndex = 18;
            this.btnvolver.Text = "Volver";
            this.btnvolver.UseVisualStyleBackColor = true;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(591, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "JUEGOS DISPONIBLES EN NUESTRO CATÁLOGO";
            // 
            // dgvjuegosdisponibles
            // 
            this.dgvjuegosdisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvjuegosdisponibles.Location = new System.Drawing.Point(89, 90);
            this.dgvjuegosdisponibles.Name = "dgvjuegosdisponibles";
            this.dgvjuegosdisponibles.RowHeadersWidth = 62;
            this.dgvjuegosdisponibles.RowTemplate.Height = 28;
            this.dgvjuegosdisponibles.Size = new System.Drawing.Size(594, 301);
            this.dgvjuegosdisponibles.TabIndex = 20;
            // 
            // ComprarJuegos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(829, 509);
            this.Controls.Add(this.dgvjuegosdisponibles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnvolver);
            this.Name = "ComprarJuegos";
            this.Text = "ComprarJuegos";
            this.Load += new System.EventHandler(this.ComprarJuegos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvjuegosdisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvjuegosdisponibles;
    }
}