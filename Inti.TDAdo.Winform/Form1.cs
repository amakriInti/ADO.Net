using Inti.TDAdo.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inti.TDAdo.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BLArticle.Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var liste = BLArticle.GetArticles();
            for (int i = 0; i < liste.Count; i += 3)
            {
                listBox1.Items.Add(liste[i + 1]);
            }

        }
    }
}
