
namespace Gui
{
    partial class BattleShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleShip));
            this.panel_Title = new System.Windows.Forms.Panel();
            this.label_Enemy = new System.Windows.Forms.Label();
            this.label_Host = new System.Windows.Forms.Label();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.textBox_EnemyShoot = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_ShootEnemy = new System.Windows.Forms.Panel();
            this.textBox_HostShoot = new System.Windows.Forms.TextBox();
            this.panel_Control = new System.Windows.Forms.Panel();
            this.button_StartStop = new System.Windows.Forms.Button();
            this.panel_Host = new System.Windows.Forms.Panel();
            this.panel_Split = new System.Windows.Forms.Panel();
            this.panel_Enemy = new System.Windows.Forms.Panel();
            this.panel_Title.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.panel_ShootEnemy.SuspendLayout();
            this.panel_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Title
            // 
            this.panel_Title.Controls.Add(this.label_Enemy);
            this.panel_Title.Controls.Add(this.label_Host);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(776, 38);
            this.panel_Title.TabIndex = 0;
            // 
            // label_Enemy
            // 
            this.label_Enemy.AutoSize = true;
            this.label_Enemy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Enemy.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Enemy.Location = new System.Drawing.Point(388, 0);
            this.label_Enemy.MinimumSize = new System.Drawing.Size(388, 36);
            this.label_Enemy.Name = "label_Enemy";
            this.label_Enemy.Size = new System.Drawing.Size(388, 36);
            this.label_Enemy.TabIndex = 1;
            this.label_Enemy.Text = "E N E M Y";
            this.label_Enemy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Host.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Host.Location = new System.Drawing.Point(0, 0);
            this.label_Host.MinimumSize = new System.Drawing.Size(388, 36);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(388, 36);
            this.label_Host.TabIndex = 0;
            this.label_Host.Text = "H O S T";
            this.label_Host.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel_Info.Controls.Add(this.textBox_EnemyShoot);
            this.panel_Info.Controls.Add(this.panel1);
            this.panel_Info.Controls.Add(this.panel_ShootEnemy);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Info.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Info.Location = new System.Drawing.Point(0, 38);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(776, 26);
            this.panel_Info.TabIndex = 1;
            // 
            // textBox_EnemyShoot
            // 
            this.textBox_EnemyShoot.BackColor = System.Drawing.Color.Red;
            this.textBox_EnemyShoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_EnemyShoot.Enabled = false;
            this.textBox_EnemyShoot.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_EnemyShoot.Location = new System.Drawing.Point(393, 0);
            this.textBox_EnemyShoot.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_EnemyShoot.Name = "textBox_EnemyShoot";
            this.textBox_EnemyShoot.ReadOnly = true;
            this.textBox_EnemyShoot.Size = new System.Drawing.Size(71, 26);
            this.textBox_EnemyShoot.TabIndex = 6;
            this.textBox_EnemyShoot.TabStop = false;
            this.textBox_EnemyShoot.Text = "S H O O T";
            this.textBox_EnemyShoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(383, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 26);
            this.panel1.TabIndex = 5;
            // 
            // panel_ShootEnemy
            // 
            this.panel_ShootEnemy.BackColor = System.Drawing.SystemColors.Info;
            this.panel_ShootEnemy.Controls.Add(this.textBox_HostShoot);
            this.panel_ShootEnemy.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_ShootEnemy.Location = new System.Drawing.Point(0, 0);
            this.panel_ShootEnemy.Name = "panel_ShootEnemy";
            this.panel_ShootEnemy.Size = new System.Drawing.Size(383, 26);
            this.panel_ShootEnemy.TabIndex = 0;
            // 
            // textBox_HostShoot
            // 
            this.textBox_HostShoot.BackColor = System.Drawing.Color.Red;
            this.textBox_HostShoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_HostShoot.Enabled = false;
            this.textBox_HostShoot.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_HostShoot.Location = new System.Drawing.Point(0, 0);
            this.textBox_HostShoot.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_HostShoot.Name = "textBox_HostShoot";
            this.textBox_HostShoot.ReadOnly = true;
            this.textBox_HostShoot.Size = new System.Drawing.Size(71, 26);
            this.textBox_HostShoot.TabIndex = 0;
            this.textBox_HostShoot.TabStop = false;
            this.textBox_HostShoot.Text = "S H O O T";
            this.textBox_HostShoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_Control
            // 
            this.panel_Control.Controls.Add(this.button_StartStop);
            this.panel_Control.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Control.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Control.Location = new System.Drawing.Point(0, 426);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(776, 45);
            this.panel_Control.TabIndex = 2;
            // 
            // button_StartStop
            // 
            this.button_StartStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_StartStop.BackColor = System.Drawing.Color.White;
            this.button_StartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_StartStop.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_StartStop.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StartStop.Location = new System.Drawing.Point(328, 6);
            this.button_StartStop.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartStop.Name = "button_StartStop";
            this.button_StartStop.Size = new System.Drawing.Size(120, 32);
            this.button_StartStop.TabIndex = 56;
            this.button_StartStop.TabStop = false;
            this.button_StartStop.Tag = "0";
            this.button_StartStop.Text = "Start";
            this.button_StartStop.UseVisualStyleBackColor = false;
            this.button_StartStop.Click += new System.EventHandler(this.button_StartStop_Click);
            // 
            // panel_Host
            // 
            this.panel_Host.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel_Host.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Host.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Host.Location = new System.Drawing.Point(0, 64);
            this.panel_Host.Name = "panel_Host";
            this.panel_Host.Size = new System.Drawing.Size(383, 362);
            this.panel_Host.TabIndex = 3;
            this.panel_Host.SizeChanged += new System.EventHandler(this.panel_Host_SizeChanged);
            // 
            // panel_Split
            // 
            this.panel_Split.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel_Split.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Split.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Split.Location = new System.Drawing.Point(383, 64);
            this.panel_Split.Name = "panel_Split";
            this.panel_Split.Size = new System.Drawing.Size(10, 362);
            this.panel_Split.TabIndex = 4;
            // 
            // panel_Enemy
            // 
            this.panel_Enemy.BackColor = System.Drawing.SystemColors.Info;
            this.panel_Enemy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Enemy.Enabled = false;
            this.panel_Enemy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel_Enemy.Location = new System.Drawing.Point(393, 64);
            this.panel_Enemy.Name = "panel_Enemy";
            this.panel_Enemy.Size = new System.Drawing.Size(383, 362);
            this.panel_Enemy.TabIndex = 5;
            this.panel_Enemy.SizeChanged += new System.EventHandler(this.panel_Enemy_SizeChanged);
            // 
            // BattleShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 471);
            this.Controls.Add(this.panel_Enemy);
            this.Controls.Add(this.panel_Split);
            this.Controls.Add(this.panel_Host);
            this.Controls.Add(this.panel_Control);
            this.Controls.Add(this.panel_Info);
            this.Controls.Add(this.panel_Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BattleShip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.Resize += new System.EventHandler(this.BattleShip_Resize);
            this.panel_Title.ResumeLayout(false);
            this.panel_Title.PerformLayout();
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.panel_ShootEnemy.ResumeLayout(false);
            this.panel_ShootEnemy.PerformLayout();
            this.panel_Control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Panel panel_Host;
        private System.Windows.Forms.Panel panel_Split;
        private System.Windows.Forms.Panel panel_Enemy;
        public System.Windows.Forms.Button button_StartStop;
        private System.Windows.Forms.TextBox textBox_HostShoot;
        private System.Windows.Forms.Panel panel_ShootEnemy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_EnemyShoot;
        private System.Windows.Forms.Label label_Enemy;
        private System.Windows.Forms.Label label_Host;
    }
}

