﻿namespace TiendaJuegos
{
    partial class MiCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiCuenta));
            this.btnvolverM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnvolverM
            // 
            this.btnvolverM.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvolverM.Location = new System.Drawing.Point(172, 302);
            this.btnvolverM.Name = "btnvolverM";
            this.btnvolverM.Size = new System.Drawing.Size(348, 52);
            this.btnvolverM.TabIndex = 19;
            this.btnvolverM.Text = "Volver";
            this.btnvolverM.UseVisualStyleBackColor = true;
            this.btnvolverM.Click += new System.EventHandler(this.btnvolverM_Click);
            // 
            // MiCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.btnvolverM);
            this.Name = "MiCuenta";
            this.Text = "MiCuenta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnvolverM;
    }
}