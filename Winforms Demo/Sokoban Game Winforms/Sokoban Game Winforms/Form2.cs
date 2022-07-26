using SokobanGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban_Game_Winforms
{
    public partial class Form2 : Form
    {
        Controller controller;
        Control[] moveCount;
        Form1 form;
        public Form2(Controller cont, Form1 frm)
        {
            InitializeComponent();
            controller = cont;
            moveCount = this.Controls.Find("MoveCount2", true);
            moveCount[0].Text = controller.GetMoveCount().ToString();
            form = frm;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Restart();
            form.ResetLevel();
            form.SetCanMove(true);
            this.Close();
        }
    }
}
