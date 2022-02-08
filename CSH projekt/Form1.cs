using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CSH_projekt.Program;

namespace CSH_projekt
{
    
    public partial class Form1 : Form
    {

    public Form1()
        {
            InitializeComponent();
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "\n\n\n\nDeck of cards! \nPress a button to draw one or two cards at a time.\n ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "\n\n\n\n" + Deck.instance.DrawOne();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "\n\n\n\n" + Deck.instance.DrawTwo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deck.instance.Reshuffle();
            richTextBox1.Text = "\n\n\n\nReshuffled";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
    
    
}

