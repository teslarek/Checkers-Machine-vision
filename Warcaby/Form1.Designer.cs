
namespace Warcaby
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_plik = new System.Windows.Forms.Button();
			this.button_Canny = new System.Windows.Forms.Button();
			this.button_Circles = new System.Windows.Forms.Button();
			this.button_Lines = new System.Windows.Forms.Button();
			this.button_Smooth = new System.Windows.Forms.Button();
			this.button_write_position = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.Cam = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(445, 382);
			this.pictureBox1.TabIndex = 81;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(767, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(445, 382);
			this.pictureBox2.TabIndex = 82;
			this.pictureBox2.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(463, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(298, 474);
			this.textBox1.TabIndex = 87;
			// 
			// button_plik
			// 
			this.button_plik.Location = new System.Drawing.Point(12, 443);
			this.button_plik.Name = "button_plik";
			this.button_plik.Size = new System.Drawing.Size(61, 40);
			this.button_plik.TabIndex = 88;
			this.button_plik.Text = "Load picture";
			this.button_plik.UseVisualStyleBackColor = true;
			this.button_plik.Click += new System.EventHandler(this.button_plik_Click);
			// 
			// button_Canny
			// 
			this.button_Canny.Location = new System.Drawing.Point(146, 443);
			this.button_Canny.Name = "button_Canny";
			this.button_Canny.Size = new System.Drawing.Size(61, 40);
			this.button_Canny.TabIndex = 90;
			this.button_Canny.Text = "Canny";
			this.button_Canny.UseVisualStyleBackColor = true;
			this.button_Canny.Click += new System.EventHandler(this.button_Canny_Click_1);
			// 
			// button_Circles
			// 
			this.button_Circles.Location = new System.Drawing.Point(213, 443);
			this.button_Circles.Name = "button_Circles";
			this.button_Circles.Size = new System.Drawing.Size(61, 40);
			this.button_Circles.TabIndex = 91;
			this.button_Circles.Text = "Get circles";
			this.button_Circles.UseVisualStyleBackColor = true;
			this.button_Circles.Click += new System.EventHandler(this.button_Circles_Click);
			// 
			// button_Lines
			// 
			this.button_Lines.Location = new System.Drawing.Point(280, 443);
			this.button_Lines.Name = "button_Lines";
			this.button_Lines.Size = new System.Drawing.Size(61, 40);
			this.button_Lines.TabIndex = 92;
			this.button_Lines.Text = "Draw lines";
			this.button_Lines.UseVisualStyleBackColor = true;
			this.button_Lines.Click += new System.EventHandler(this.button_Lines_Click);
			// 
			// button_Smooth
			// 
			this.button_Smooth.Location = new System.Drawing.Point(79, 443);
			this.button_Smooth.Name = "button_Smooth";
			this.button_Smooth.Size = new System.Drawing.Size(61, 40);
			this.button_Smooth.TabIndex = 93;
			this.button_Smooth.Text = "Smooth";
			this.button_Smooth.UseVisualStyleBackColor = true;
			this.button_Smooth.Click += new System.EventHandler(this.button_Smooth_Click);
			// 
			// button_write_position
			// 
			this.button_write_position.Location = new System.Drawing.Point(347, 443);
			this.button_write_position.Name = "button_write_position";
			this.button_write_position.Size = new System.Drawing.Size(61, 40);
			this.button_write_position.TabIndex = 94;
			this.button_write_position.Text = "Write position";
			this.button_write_position.UseVisualStyleBackColor = true;
			this.button_write_position.Click += new System.EventHandler(this.button_write_position_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(12, 489);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
			this.numericUpDown1.TabIndex = 95;
			// 
			// Cam
			// 
			this.Cam.Location = new System.Drawing.Point(9, 524);
			this.Cam.Name = "Cam";
			this.Cam.Size = new System.Drawing.Size(64, 42);
			this.Cam.TabIndex = 96;
			this.Cam.Text = "Camera";
			this.Cam.UseVisualStyleBackColor = true;
			this.Cam.Click += new System.EventHandler(this.Cam_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1235, 623);
			this.Controls.Add(this.Cam);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button_write_position);
			this.Controls.Add(this.button_Smooth);
			this.Controls.Add(this.button_Lines);
			this.Controls.Add(this.button_Circles);
			this.Controls.Add(this.button_Canny);
			this.Controls.Add(this.button_plik);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_plik;
        private System.Windows.Forms.Button button_Canny;
        private System.Windows.Forms.Button button_Circles;
        private System.Windows.Forms.Button button_Lines;
        private System.Windows.Forms.Button button_Smooth;
        private System.Windows.Forms.Button button_write_position;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button Cam;
	}
}

