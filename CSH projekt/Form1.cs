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
    
    public class Deck
    {

        //Singleton object with only one instance
        public static readonly Deck instance = new Deck();
        private Deck() { ShuffledDeck(); }

        private string[] suit = new string[] { "Diamonds \u2666", "Hearts \u2665", "Spades \u2660", "Clubs \u2663" };
        private string[] value = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        private List<string> items = new List<string>();
        private List<string> shuffledItems = new List<string>();

        public List<string> OrderedDeck()
        {
            foreach (string s in suit)
            {
                foreach (string v in value)
                {
                    items.Add(v + " of " + s);
                }
            }
          
            return items;
        }

        public List<string> ShuffledDeck()
        {
            OrderedDeck();
            
            List<string> temp = new List<string>();
            var random = new Random();

            for ( int i=51; i >= 0; --i)
            {
                var index = random.Next(0, i);
                temp.Add(items[index]);
                items.RemoveAt(index);
            }

            for (int i = 51; i >= 0; --i)
            {
                var index = random.Next(0, i);
                shuffledItems.Add(temp[index]);
                temp.RemoveAt(index);
            }

            return shuffledItems;
        }

        public string DrawOne()
        {
            if (shuffledItems.Count > 0)
            {
                var card = shuffledItems[0];
                shuffledItems.RemoveAt(0);
                return card;
            }
            else return "End of deck. Press Reshuffle to reset deck.";
        }

        public string DrawTwo()
        {
            if (shuffledItems.Count >= 2)
            {
                string cards= "";

                for (int i=0; i<2; i++)
                {
                    cards += shuffledItems[0] + "\n";
                    shuffledItems.RemoveAt(0);
                }
                
                return cards;
               
            }
            else if (shuffledItems.Count == 1)
            {
                var card1 = shuffledItems[0];
                shuffledItems.RemoveAt(0);
                
                return card1;
            }
            else
            {
                return "End of deck. Press Reshuffle to reset deck.";
            }  
        }

        public void Reshuffle()
        {
            ShuffledDeck();
        }
    }
}

