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
    public partial class Form3 : Form
    {
        Controller controller;
        Form1 form;
        public Form3(Controller control, Form1 frm)
        {
            InitializeComponent();
            controller = control;
            form = frm;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form.SetCanMove(true);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.SaveGame();

            form.SetCanMove(true);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.LoadGame();
            form.ResetLevel();

            form.SetCanMove(true);
            this.Close();
        }
    }
}
