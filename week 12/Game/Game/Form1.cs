using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
 
namespace Game
{
    public partial class Form1 : Form
    {
        PictureBox enemyBlack;
        PictureBox enemyBlue;
        Random rand = new Random();
        string enemyBlackDirection = "MovingRight";
        string enemyBlueDirection = "MovingLeft";
        List<PictureBox> playerFires = new List<PictureBox>();
        List<PictureBox> enemyFires = new List<PictureBox>();
        List<PictureBox> metorsList = new List<PictureBox>();

        int enmeyBlackLastTimeToFire = 15;
        int enemyBlueLastTimeToFire   = 20;
        int enemyBlueTimeToFire = 0 ;
        int enemyBlackTimeToFire = 0;
        bool isBlackAlive = true;
        bool isBlueAlive = true;
        int lastMetroidGenerationTime = 0;
        int metorGenerationTime = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void TimeGameLoop_Tick(object sender, EventArgs e)
        {
            if(isBlackAlive == false && isBlueAlive == false)
            {
                TimeGameLoop.Enabled = false;
                MessageBox.Show("You Won");
                this.Close();
            }
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pbPlayerShip.Left = pbPlayerShip.Left + 25;
                pbPlayerHealth.Left = pbPlayerHealth.Left + 25;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pbPlayerShip.Left = pbPlayerShip.Left - 25;
                pbPlayerHealth.Left = pbPlayerHealth.Left - 25;

            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image fireImage = Game.Properties.Resources.laserBlue05;
                PictureBox pbFire = createFires(fireImage, pbPlayerShip);
                playerFires.Add(pbFire);
                this.Controls.Add(pbFire);
            }
            foreach(PictureBox bullet in playerFires)
            {
                bullet.Top = bullet.Top - 20;
            }
            for(int idx =0; idx < playerFires.Count; idx++)
            {
                if(playerFires[idx].Bottom  < 0)
                {
                    playerFires.Remove(playerFires[idx]);
                }
            }
            moveEnemy(enemyBlack, ref enemyBlackDirection);
            moveEnemy(enemyBlue, ref enemyBlueDirection);
            moveFire(enemyFires);
            foreach (PictureBox bullets in enemyFires)
            {
               if(bullets.Bounds.IntersectsWith(pbPlayerShip.Bounds))
                {
                    if(pbPlayerHealth.Value > 0)
                    {
                        pbPlayerHealth.Value = pbPlayerHealth.Value - 10;
                    }
                }
            }
            foreach(PictureBox bullets in playerFires)
            {
                if(bullets.Bounds.IntersectsWith (enemyBlack.Bounds))
                {
                    enemyBlack.Hide();
                    isBlackAlive = false;
                }
                if (bullets.Bounds.IntersectsWith(enemyBlue.Bounds))
                {
                    enemyBlue.Hide();
                    isBlueAlive = false;
                }
            }
            lastMetroidGenerationTime++;
            if (lastMetroidGenerationTime >= metorGenerationTime)
            {
                Image img = Game.Properties.Resources.meteorBrown_med1;
                PictureBox pbMetor = createMetor(img);
                metorsList.Add(pbMetor);
                this.Controls.Add(pbMetor);
                lastMetroidGenerationTime = 0;
                //foreach(PictureBox metor in metorsList)
              //  {
                    //moveMetor(metor);
               // }
            }
            AddScore();
        }
        private PictureBox createEnemy (Image img)
        {
            PictureBox pbEnemy = new PictureBox();
            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);
            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Height = img.Height;
            pbEnemy.Width = img.Width;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;

        }
        private PictureBox createMetor(Image img)
        {
            PictureBox pbMetor = new PictureBox();
            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);
            pbMetor.Left = left;
            pbMetor.Top = top;
            pbMetor.Height = img.Height;
            pbMetor.Width = img.Width;
            pbMetor.BackColor = Color.Transparent;
            pbMetor.Image = img;
            return pbMetor;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enemyBlack = createEnemy(Game.Properties.Resources.enemyRed1);
            enemyBlue = createEnemy(Game.Properties.Resources.enemyGreen3);
            this.Controls.Add(enemyBlue);
            this.Controls.Add(enemyBlack);
        }
        private void moveEnemy(PictureBox enemy , ref string enemyDirection)
        {
            if(enemyDirection == "MovingRight")
            {
                enemy.Left = enemy.Left + 10;

            }
            if(enemyDirection == "MovingLeft")
            {
                enemy.Left = enemy.Left - 10;
            }
            if((enemy.Left + enemy.Width ) > this.Width)
            {
                enemyDirection = "MovingLeft";
            }
            if ((enemy.Left <= 2))
            {
                enemyDirection = "MovingRight";
            }

        }
        private void moveMetor(PictureBox metor)
        {
            for (int idx = 0; idx < metorsList.Count; idx++)
            {
                if (metorsList[idx].Top < this.Height)
                {
                    metorsList.Remove(metorsList[idx]);
                }
            }
            foreach (PictureBox bullets in metorsList)
            {
                bullets.Top = bullets.Top  + 20;
            }
    }
        private PictureBox createFires(Image fireImage , PictureBox source)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.Image = fireImage;
            pbFire.Width = fireImage.Width;
            pbFire.Height = fireImage.Height;
            pbFire.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation = new System.Drawing.Point();
            fireLocation.X = source.Left + (source.Width / 2) - 5;
            fireLocation.Y = source.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }
        private void moveFire(List<PictureBox> enemyFires)
        {
            enmeyBlackLastTimeToFire++;
            enemyBlueLastTimeToFire++;
            if (enemyBlueLastTimeToFire >= enemyBlackTimeToFire)
            {
                Image fireImage = Game.Properties.Resources.laserGreen10;
                PictureBox pbFire = createFires(fireImage, enemyBlue);
                enemyFires.Add(pbFire);
                this.Controls.Add(pbFire);
                enemyBlueLastTimeToFire = 0;
            }
            if (enmeyBlackLastTimeToFire >= enemyBlueTimeToFire)
            {
                Image fireImage = Game.Properties.Resources.laserRed06;
                PictureBox pbFire = createFires(fireImage, enemyBlack);
                enemyFires.Add(pbFire);
                this.Controls.Add(pbFire);
                enmeyBlackLastTimeToFire = 0;
            }
            for (int idx = 0; idx < enemyFires.Count; idx++)
            {
                if (enemyFires[idx].Top > this.Height)
                {
                    enemyFires.Remove(enemyFires[idx]);
                }
            }
            foreach (PictureBox bullets in enemyFires)
            {
                bullets.Top = bullets.Top + 20;
            }
        }
        private void AddScore ()
        {
            foreach(PictureBox bullet in playerFires)
            {
                bool removeBullet = false;
                foreach(PictureBox pbMetor in metorsList)
                {
                    if(pbMetor.Bounds.IntersectsWith(bullet.Bounds))
                    {
                        score = score + 5;
                        lblScore.Text = "Score : " + score.ToString();
                        pbMetor.Top = this.Height + 2000;
                        pbMetor.Hide();
                        removeBullet = true;
                    }
                }
                if (bullet.Bounds.IntersectsWith(enemyBlack.Bounds))
                {
                    enemyBlack.Hide();
                    isBlackAlive = false;
                    removeBullet = true;
                }
            }
          
        }     
        private void ShowGameEnd(Image img)
        {
            TimeGameLoop.Enabled = false;
            frmGameEnd gameOver = new frmGameEnd(img);
            DialogResult result = gameOver.ShowDialog();
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
            if(result == DialogResult.No)
            {
                Restart();
            }
        }
        private void Restart()
        {
             score = 0;
            this.Controls.Clear();
            Random rand = new Random();
             enemyBlackDirection = "MovingRight";
            enemyBlueDirection = "MovingLeft";
              playerFires = new List<PictureBox>();
            enemyFires = new List<PictureBox>();
           metorsList = new List<PictureBox>();

             enmeyBlackLastTimeToFire = 15;
             enemyBlueLastTimeToFire = 20;
             enemyBlueTimeToFire = 0;
             enemyBlackTimeToFire = 0;
             isBlackAlive = true;
             isBlueAlive = true;
             lastMetroidGenerationTime = 0;
             metorGenerationTime = 10;
           
        }
    }
}
