﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha_2._0
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();

      
        List<string> icons = new List<string>()

    {
        "!", "!", "N", "N", "o", "o", "k", "k",
        "b", "b", "v", "v", "j", "j", "p", "p"

    };
       
        private void AssignIconsToSquares()
        {
        
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
      
        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }
        private void CheckForWinner()
        {
           
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

           
            MessageBox.Show("Você conseguiu encontrar todos os pares!", "Parabens");
            Close();
        }

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                
            
                
                timer1.Stop();


                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;

                firstClicked = null;
                secondClicked = null;
            
        }
    }
}
