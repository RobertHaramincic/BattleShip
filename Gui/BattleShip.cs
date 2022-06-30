using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vsite.Battleship.Model;
using Vsite.BattleShip.Model;

namespace Gui
{
    public partial class BattleShip : Form
    {
        #region // Members
        private List<int> ShipLengths = new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
        private Vsite.Battleship.Model.Fleet HostFleet;
        private Vsite.Battleship.Model.Fleet EnemyFleet;
        private Vsite.Battleship.Model.Gunnery EnemyGunnery;
        private SquareEliminator squareEnemyEliminator;
        private List<Button> buttonssHostHit = new List<Button>();
        private List<int> shipsToShoot;

        private const int gridRow = 10;
        private const int gridColumn = 10;
        #endregion

        #region // C'tor
        public BattleShip()
        {
            InitializeComponent();
            this.BattleShip_Resize(this, null);

            var (buttonSize, startLocationX, startLocationY) = this.CalculateButtonSize();
            this.InitializeBattleField("Host", this.panel_Host, buttonSize, startLocationX, startLocationY);
            this.InitializeBattleField("Enemy", this.panel_Enemy, buttonSize, startLocationX, startLocationY);
        }
        #endregion

        #region // Initialization 
        private (int, int, int) CalculateButtonSize()
        {
            int startLocationX = 5;
            int startLocationY = 5;

            // Calculate button size (min 5pt from left & right and plus 9*2 space bettween buttons
            var optimalSquare = panel_Host.Size.Width;
            if (optimalSquare > panel_Host.Size.Height)
            {
                optimalSquare = panel_Host.Size.Height;
            }

            int buttonSize = (int)((optimalSquare - 2 * startLocationX - 18) / gridColumn);
            if (buttonSize < 5)
            {
                buttonSize = 5;
            }

            return (buttonSize, startLocationX, startLocationY);
        }

        private void InitializeBattleField(string fieldName, Panel panel, int buttonSize, int startLocationX, int startLocationY)
        {
            for (var row = 0; row < gridRow; ++row)
            {
                for (var col = 0; col < gridColumn; ++col)
                {
                    panel.Controls.Add(this.CreateButton(fieldName, row, col, buttonSize, startLocationX+5 + row * buttonSize + 2, startLocationY + col * buttonSize + 2));
                }
            }
        }

        private System.Windows.Forms.Button CreateButton(string fieldName, int row, int column, int size, int position_X, int position_Y)
        {
            var button = new System.Windows.Forms.Button();
            button.BackColor = System.Drawing.Color.White;
            button.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button.ForeColor = System.Drawing.Color.ForestGreen;
            button.Location = new System.Drawing.Point(position_X, position_Y);
            button.Margin = new System.Windows.Forms.Padding(2);
            button.Name = "button_Battle_" + column + "_" + row;
            button.Size = new System.Drawing.Size(size, size);
            button.Tag = new ButtonInfo(column, row);
            button.Text = "";
            button.UseVisualStyleBackColor = false;
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button.Enabled = fieldName != "Host";
            button.Click += new System.EventHandler(this.button_Click);

            return button;
        }

        private void ResetBattleFields()
        {
            this.button_StartStop.Tag = (int)0;
            this.button_StartStop.Text = "Start";
            this.button_StartStop.ForeColor = System.Drawing.Color.ForestGreen;

            // Initialize the Host battle field
            this.textBox_HostShoot.BackColor = Color.Red;
            foreach (Button button in this.panel_Host.Controls.OfType<Button>())
            {
                var buttonInfo = (ButtonInfo)button.Tag;
                buttonInfo.state = null;
                button.Tag = buttonInfo;
                button.BackColor = System.Drawing.Color.White;
                button.BackgroundImage = null;
            }

            // Initialize the Enemy battle field
            this.textBox_EnemyShoot.BackColor = Color.Red;
            foreach (Button button in this.panel_Enemy.Controls.OfType<Button>())
            {
                var buttonInfo = (ButtonInfo)button.Tag;
                buttonInfo.state = null;
                button.Tag = buttonInfo;
                button.BackColor = System.Drawing.Color.White;
                button.Enabled = true;
                button.BackgroundImage = null;
            }
        }
        #endregion

        #region // Resize Gui
        private void BattleShip_Resize(object sender, EventArgs e)
        {
            this.label_Host.MinimumSize = new Size((int)((this.Width - 16) * 0.5), this.label_Host.MinimumSize.Height);
            this.label_Enemy.MinimumSize = new Size(this.label_Host.MinimumSize.Width, this.label_Host.MinimumSize.Height);
            this.panel_Host.VerticalScroll.Value = 0;
            this.panel_Host.HorizontalScroll.Value = 0;
            this.panel_Host.Size = new System.Drawing.Size((int)((this.Width - 16 - this.panel_Split.Width) * 0.5), this.panel_Host.Height);
            this.panel_Enemy.VerticalScroll.Value = 0;
            this.panel_Enemy.HorizontalScroll.Visible = false;
            this.panel_ShootEnemy.Size = new System.Drawing.Size((int)((this.Width - 16 - this.panel_Split.Width) * 0.5), this.panel_ShootEnemy.Height);
            this.Refresh();
        }
        private void panel_Host_SizeChanged(object sender, EventArgs e)
        {
            this.ResizeButtons(this.panel_Host.Controls.OfType<Button>());
        }

        private void panel_Enemy_SizeChanged(object sender, EventArgs e)
        {
            this.ResizeButtons(this.panel_Enemy.Controls.OfType<Button>());
        }

        private void ResizeButtons(IEnumerable<Button> buttons)
        {
            this.Refresh();
            var (buttonSize, startLocationX, startLocationY) = this.CalculateButtonSize();
            foreach (Button button in buttons)
            {
                var buttonLocation = (ButtonInfo)button.Tag;
                button.Location = new System.Drawing.Point(startLocationX + buttonLocation.row * buttonSize + 2, startLocationY + buttonLocation.column * buttonSize + 2);
                button.Size = new System.Drawing.Size(buttonSize, buttonSize);
            }
        }
        #endregion

        #region // Battle is started 
        private void button_StartStop_Click(object sender, EventArgs e)
        {
            var buttonTag = Convert.ToInt32(this.button_StartStop.Tag);
            if (buttonTag == 0)
            {
                // Start the game
                this.button_StartStop.Tag = (int)1;
                this.button_StartStop.Text = "Stop";
                this.button_StartStop.ForeColor = System.Drawing.Color.Red;

                // Create the Host Fleet
                this.shipsToShoot = new List<int>(ShipLengths);
                this.squareEnemyEliminator = new SquareEliminator(gridRow, gridColumn);
                var shipwright = new Shipwright(gridRow, gridColumn, this.ShipLengths);
                this.HostFleet = shipwright.CreateFleet();
                foreach (var ship in this.HostFleet.Ships)
                {
                    foreach (var sq in ship.Squares)
                    {
                        var button = this.panel_Host.Controls.OfType<Button>().FirstOrDefault(b =>
                        {
                            var position = (ButtonInfo)b.Tag;
                            return position.row == sq.Row && position.column == sq.Column;
                        });
                        button.BackColor = Color.Green;
                    }
                }

                // Create the Enemy Fleet
                this.EnemyFleet = shipwright.CreateFleet();
                this.EnemyGunnery = new Gunnery(gridRow, gridColumn, this.ShipLengths);

                this.HostIsShooting();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure that you want to quit the game?", "In the middle of the war...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // Stop the game
                this.ResetBattleFields();
            }
        }

        private void HostIsShooting()
        {
            this.panel_Enemy.Enabled = true;
            this.textBox_EnemyShoot.BackColor = Color.Red;
            this.textBox_HostShoot.BackColor = Color.LightGreen;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            this.textBox_HostShoot.BackColor = Color.GreenYellow;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            this.textBox_HostShoot.BackColor = Color.LightGreen;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Host shooted
            this.panel_Enemy.Enabled = false;
            var hitButton = (Button)sender;
            hitButton.Enabled = false;

            var hitButtonInfo = (ButtonInfo)hitButton.Tag;
            var lastTarget = new Square(hitButtonInfo.row, hitButtonInfo.column);

            var hitResult = this.EnemyFleet.Shoot(lastTarget.Row, lastTarget.Column);
            switch (hitResult)
            {
                case HitResult.Missed:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.X;
                    hitButtonInfo.state = HitResult.Missed;
                    break;

                case HitResult.Hit:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.Boomb;
                    hitButtonInfo.state = HitResult.Hit;
                    break;

                case HitResult.Sunken:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.Boom;
                    hitButtonInfo.state = HitResult.Sunken;

                    // Eleminate all around avaible squares
                    var toEliminate = this.squareEnemyEliminator.ToEliminate(this.EnemyFleet.CurrentSunkenShip.Squares);
                    foreach (var sq in toEliminate)
                    {
                        var button = this.panel_Enemy.Controls.OfType<Button>().FirstOrDefault(b =>
                        {
                            var position = (ButtonInfo)b.Tag;
                            return position.row == sq.Row && position.column == sq.Column;
                        });

                        var buttonInfo = (ButtonInfo)button.Tag;

                        if(buttonInfo.state == null)
                        {
                            button.BackgroundImage = global::Gui.Properties.Resources.Xblack;
                            button.Enabled = false;
                            continue;
                        }

                        if (buttonInfo.state == HitResult.Hit)
                        {
                            button.BackgroundImage = global::Gui.Properties.Resources.Boom;
                        }
                    }

                    this.shipsToShoot.Remove(this.EnemyFleet.CurrentSunkenShip.Squares.Count());
                    break;
            }

            hitButton.Tag = hitButtonInfo;

            if (!this.shipsToShoot.Any())
            {
                // Host WON :((((
                MessageBox.Show("You won the game!", "WINNER !!!", MessageBoxButtons.OK);
                this.ResetBattleFields();
                return;
            }

            this.EnemyIsShooting();
        }

        private void EnemyIsShooting()
        {
            this.panel_Enemy.Enabled = false;
            this.textBox_HostShoot.BackColor = Color.Red;
            this.textBox_EnemyShoot.BackColor = Color.LightGreen;
            System.Threading.Thread.Sleep(100);
            this.textBox_EnemyShoot.BackColor = Color.GreenYellow;
            this.Refresh();
            System.Threading.Thread.Sleep(100);
            this.textBox_EnemyShoot.BackColor = Color.LightGreen;
            this.Refresh();
            System.Threading.Thread.Sleep(100);

            var target = this.EnemyGunnery.NextTarget();
            var hitResult = this.HostFleet.Shoot(target.Row, target.Column);

            // Change Button state
            var hitButton = this.panel_Host.Controls.OfType<Button>().FirstOrDefault(b =>
            {
                var position = (ButtonInfo)b.Tag;
                return position.row == target.Row && position.column == target.Column;
            });

            var buttonInfo = (ButtonInfo)hitButton.Tag;
            switch (hitResult)
            {
                case HitResult.Missed:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.X;
                    buttonInfo.state = HitResult.Missed;
                    break;

                case HitResult.Hit:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.Boomb;
                    buttonInfo.state = HitResult.Hit;
                    this.buttonssHostHit.Add(hitButton);
                    break;

                case HitResult.Sunken:
                    hitButton.BackgroundImage = global::Gui.Properties.Resources.Boom;
                    buttonInfo.state = HitResult.Sunken;

                    foreach(var bt in this.buttonssHostHit)
                    {
                        bt.BackgroundImage = global::Gui.Properties.Resources.Boom;
                    }

                    this.buttonssHostHit.Clear();
                    break;
            }

            if (this.EnemyGunnery.ProcessHitResult(hitResult) == false)
            {
                // Enemy WON :((((
                MessageBox.Show("Sorry, you lost the game!", "LOSER !!!", MessageBoxButtons.OK);
                this.ResetBattleFields();
                return;
            }

            this.HostIsShooting();
        }
        #endregion

        #region // Helper Class
        private class ButtonInfo
        {
            public int row;
            public int column;
            public HitResult? state;

            public ButtonInfo(int row, int column)
            {
                this.row = row;
                this.column = column;
                this.state = null;
            }
        }
        #endregion
    }
}
