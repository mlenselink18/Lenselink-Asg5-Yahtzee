using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lenselink_Asg5_Yahtzee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetGame();
        }

        Hand playerHand = new Hand();
        PictureBox[] playerPictureBoxArray = new PictureBox[5];
        Label[] labelKeepArray = new Label[5];
        Game currentGame = new Game();

        private void resetGame()
        {
            currentGame.RollNumber = 0;
            resetScore();
            loadPictureBoxesIntoArray();
            loadLabelsIntoArray();
            resetImages();
            playerHand.resetHand();
            resetScoreLabels();
        }

        private void resetScore()
        {
            currentGame.UpperScore = 0;
            currentGame.LowerScore = 0;
            currentGame.BonusScore = 0;
        }

        private void resetScoreLabels()
        {
            labelUpperTotal.Visible = true;
            labelUpperTotal.Text = currentGame.UpperScore.ToString();
            labelLowerTotal.Visible = true;
            labelLowerTotal.Text = currentGame.LowerScore.ToString();
            labelBonus.Visible = true;
            labelBonus.Text = currentGame.BonusScore.ToString();
            labelGameTotal.Visible = true;
            labelGameTotal.Text = currentGame.getTotalScore().ToString();
        }

        private void loadPictureBoxesIntoArray()
        {
            playerPictureBoxArray[0] = pictureBoxDie1;
            playerPictureBoxArray[1] = pictureBoxDie2;
            playerPictureBoxArray[2] = pictureBoxDie3;
            playerPictureBoxArray[3] = pictureBoxDie4;
            playerPictureBoxArray[4] = pictureBoxDie5;
        }

        private void loadLabelsIntoArray()
        {
            labelKeepArray[0] = labelKeep1;
            labelKeepArray[1] = labelKeep2;
            labelKeepArray[2] = labelKeep3;
            labelKeepArray[3] = labelKeep4;
            labelKeepArray[4] = labelKeep5;
        }

        private void resetImages()
        {
            for (int i = 0; i < 5; i++)
            {
                playerPictureBoxArray[i].Image = imageListDice.Images[0];
            }
        }

        private void setImages()
        {
            for (int i = 0; i < 5; i++)
            {
                int imageIndex = playerHand.getDieValue(i) - 1;
                playerPictureBoxArray[i].Image = imageListDice.Images[imageIndex];
            }
        }

        private void roll()
        {
            currentGame.RollNumber++;
            if (currentGame.RollNumber >= 3)
                buttonRoll.Enabled = false;

            foreach(PictureBox pictureBox in playerPictureBoxArray)
            {
                pictureBox.Enabled = true;
            }
            playerHand.rollDice();
            setImages();
        }

        private void resetRound()
        {
            buttonRoll.Enabled = true;
            currentGame.RollNumber = 0;
            playerHand.resetHand();
            for (int i = 0; i < 5; i++)
            {
                labelKeepArray[i].Visible = false;
            }
        }

        private void countDice(int diceValue, Button button)
        {
            int score = 0;
            
            for (int i = 0; i < 5; i++)
            {
                if (playerHand.getDieValue(i) == diceValue)
                {
                    score += playerHand.getDieValue(i);
                }
            }

            button.Text = score.ToString();

            if (currentGame.UpperScore + score > 63)
            {
                int remainder = currentGame.UpperScore + score - 62;
                
                if(remainder <= 0)
                {
                    remainder = 0;
                }

                currentGame.addToUpper(remainder);
                currentGame.addToBonus(score = remainder);
                
            }
            else
            {
                currentGame.addToUpper(score);
            }
            button.Enabled = false;
            resetRound();
            labelUpperTotal.Text = currentGame.UpperScore.ToString();
        }

        private void ButtonRoll_Click(object sender, EventArgs e)
        {
            roll();
        }

        private void showHand()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                int value = playerHand.getDieValue(i);
                sb.Append(value);
                sb.Append(Environment.NewLine);
            }
            labelCurrentHand.Text = sb.ToString();
        }

        private void toggleKeepLabel(int i)
        {
            playerHand.toggleKeep(i);
            labelKeepArray[i].Visible = !labelKeepArray[i].Visible; 
        }

        private void PictureBoxDie1_Click(object sender, EventArgs e)
        {
            toggleKeepLabel(0);
        }

        private void PictureBoxDie2_Click(object sender, EventArgs e)
        {
            toggleKeepLabel(1);
        }

        private void PictureBoxDie3_Click(object sender, EventArgs e)
        {
            toggleKeepLabel(2);
        }

        private void PictureBoxDie4_Click(object sender, EventArgs e)
        {
            toggleKeepLabel(3);
        }

        private void PictureBoxDie5_Click(object sender, EventArgs e)
        {
            toggleKeepLabel(4);
        }

        private void ButtonShowHand_Click(object sender, EventArgs e)
        {
            showHand();
        }

        private void ButtonSetAces_Click(object sender, EventArgs e)
        {
            countDice(1, buttonSetAces);
        }

        private void ButtonSetTwos_Click(object sender, EventArgs e)
        {
            countDice(2, buttonSetTwos);
        }

        private void ButtonSetThrees_Click(object sender, EventArgs e)
        {
            countDice(3, buttonSetThrees);
        }

        private void ButtonSetFours_Click(object sender, EventArgs e)
        {
            countDice(4, buttonSetFours);
        }

        private void ButtonSetFives_Click(object sender, EventArgs e)
        {
            countDice(5, buttonSetFives);
        }

        private void ButtonSetSixes_Click(object sender, EventArgs e)
        {
            countDice(6, buttonSetSixes);
        }
    }
}
