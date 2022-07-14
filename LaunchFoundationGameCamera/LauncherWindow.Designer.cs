namespace LaunchFoundationGameCamera
{
    partial class LauncherWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherWindow));
            this.panel_Content = new System.Windows.Forms.Panel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.pictureBox_Github = new System.Windows.Forms.PictureBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.pictureBox_Discord = new System.Windows.Forms.PictureBox();
            this.panel_Middle = new System.Windows.Forms.Panel();
            this.label_Supportinfo = new System.Windows.Forms.Label();
            this.label_LoadingInfo = new System.Windows.Forms.Label();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Content.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Github)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Discord)).BeginInit();
            this.panel_Middle.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Content
            // 
            this.panel_Content.Controls.Add(this.panel_Bottom);
            this.panel_Content.Controls.Add(this.panel_Middle);
            this.panel_Content.Controls.Add(this.panel_Top);
            this.panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Content.Location = new System.Drawing.Point(0, 0);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(800, 450);
            this.panel_Content.TabIndex = 0;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.pictureBox_Github);
            this.panel_Bottom.Controls.Add(this.button_Start);
            this.panel_Bottom.Controls.Add(this.pictureBox_Discord);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 250);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(800, 182);
            this.panel_Bottom.TabIndex = 2;
            // 
            // pictureBox_Github
            // 
            this.pictureBox_Github.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Github.Image = global::LaunchFoundationGameCamera.Properties.Resources.github_logo_pixabayg767c696ab_640;
            this.pictureBox_Github.Location = new System.Drawing.Point(678, 137);
            this.pictureBox_Github.Name = "pictureBox_Github";
            this.pictureBox_Github.Size = new System.Drawing.Size(52, 43);
            this.pictureBox_Github.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Github.TabIndex = 2;
            this.pictureBox_Github.TabStop = false;
            this.pictureBox_Github.Click += new System.EventHandler(this.PictureBox_Github_Click);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button_Start.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.button_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Start.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Start.Location = new System.Drawing.Point(182, 41);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(436, 100);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "START";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // pictureBox_Discord
            // 
            this.pictureBox_Discord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Discord.Image = global::LaunchFoundationGameCamera.Properties.Resources.discord_logo_pixabay;
            this.pictureBox_Discord.Location = new System.Drawing.Point(736, 137);
            this.pictureBox_Discord.Name = "pictureBox_Discord";
            this.pictureBox_Discord.Size = new System.Drawing.Size(52, 43);
            this.pictureBox_Discord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Discord.TabIndex = 0;
            this.pictureBox_Discord.TabStop = false;
            this.pictureBox_Discord.Click += new System.EventHandler(this.PictureBox_Discord_Click);
            // 
            // panel_Middle
            // 
            this.panel_Middle.Controls.Add(this.label_Supportinfo);
            this.panel_Middle.Controls.Add(this.label_LoadingInfo);
            this.panel_Middle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Middle.Location = new System.Drawing.Point(0, 143);
            this.panel_Middle.Name = "panel_Middle";
            this.panel_Middle.Size = new System.Drawing.Size(800, 107);
            this.panel_Middle.TabIndex = 1;
            // 
            // label_Supportinfo
            // 
            this.label_Supportinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Supportinfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Supportinfo.Location = new System.Drawing.Point(0, 66);
            this.label_Supportinfo.Name = "label_Supportinfo";
            this.label_Supportinfo.Size = new System.Drawing.Size(800, 41);
            this.label_Supportinfo.TabIndex = 1;
            this.label_Supportinfo.Text = "For support, troubleshooting and sharing screen captures join the discord: <invit" +
    "e_link>";
            this.label_Supportinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Supportinfo.Click += new System.EventHandler(this.Label_Supportinfo_Click);
            // 
            // label_LoadingInfo
            // 
            this.label_LoadingInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_LoadingInfo.Location = new System.Drawing.Point(0, 0);
            this.label_LoadingInfo.Name = "label_LoadingInfo";
            this.label_LoadingInfo.Size = new System.Drawing.Size(800, 66);
            this.label_LoadingInfo.TabIndex = 0;
            this.label_LoadingInfo.Text = "To begin make sure that the game is running and the save has been fully loaded be" +
    "fore initiating FGC.";
            this.label_LoadingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.label1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(800, 143);
            this.panel_Top.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(253, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to FoundationGameCamera";
            // 
            // LauncherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Content);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LauncherWindow";
            this.Text = "Foundation Game Camera Launcher";
            this.Load += new System.EventHandler(this.LauncherWindow_Load);
            this.panel_Content.ResumeLayout(false);
            this.panel_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Github)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Discord)).EndInit();
            this.panel_Middle.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_Content;
        private Panel panel_Top;
        private Label label_LoadingInfo;
        private Panel panel_Middle;
        private Label label1;
        private Panel panel_Bottom;
        private PictureBox pictureBox_Discord;
        private Label label_Supportinfo;
        private Button button_Start;
        private PictureBox pictureBox_Github;
    }
}