
namespace Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbPlayerShip = new System.Windows.Forms.PictureBox();
            this.TimeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.pbPlayerHealth = new System.Windows.Forms.ProgressBar();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerShip
            // 
            this.pbPlayerShip.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerShip.Image = global::Game.Properties.Resources.playerShip1_blue;
            this.pbPlayerShip.Location = new System.Drawing.Point(347, 339);
            this.pbPlayerShip.Name = "pbPlayerShip";
            this.pbPlayerShip.Size = new System.Drawing.Size(99, 75);
            this.pbPlayerShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlayerShip.TabIndex = 0;
            this.pbPlayerShip.TabStop = false;
            // 
            // TimeGameLoop
            // 
            this.TimeGameLoop.Enabled = true;
            this.TimeGameLoop.Tick += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // pbPlayerHealth
            // 
            this.pbPlayerHealth.BackColor = System.Drawing.Color.Gray;
            this.pbPlayerHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pbPlayerHealth.Location = new System.Drawing.Point(347, 420);
            this.pbPlayerHealth.Name = "pbPlayerHealth";
            this.pbPlayerHealth.Size = new System.Drawing.Size(100, 23);
            this.pbPlayerHealth.TabIndex = 1;
            this.pbPlayerHealth.Value = 100;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblScore.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblScore.Location = new System.Drawing.Point(690, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 26);
            this.lblScore.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game.Properties.Resources.blue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbPlayerHealth);
            this.Controls.Add(this.pbPlayerShip);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerShip;
        private System.Windows.Forms.ProgressBar pbPlayerHealth;
        private System.Windows.Forms.Timer TimeGameLoop;
        private System.Windows.Forms.Label lblScore;
    }
}

