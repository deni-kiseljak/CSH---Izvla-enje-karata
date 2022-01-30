using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSH_projekt
{
    public class Deck
    {
        private string[] suit = new string[] { "Diamonds \u2666", "Hearts \u2665", "Spades \u2660", "Clubs \u2663" };
        private string[] value = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        private List<string> items = new List<string>();
        private string[] arrayOfItems;

        public string[] OrderedDeck()
        {
            foreach (string s in suit)
            {
                foreach (string v in value)
                {
                    items.Add(v +" of "+ s);
                }
            }
            arrayOfItems = items.ToArray();
            foreach (string s in arrayOfItems)
            {
                Console.WriteLine(s);
            }
            return arrayOfItems;
        }

    }
    public partial class Form1 : Form
    {  

    public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "Draw one or two cards";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instance = new Deck();
            string text= "";
            foreach (string s in instance.OrderedDeck())
            {
                text += s+"\n";
                richTextBox1.Text=text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

