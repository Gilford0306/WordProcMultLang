using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace WordProcMultLang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.ResetText();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                var filePath = string.Empty;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        this.textBox1.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDoc.PrintPage += printDoc_PrintPage;
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.textBox1.Text, this.textBox1.Font, Brushes.Black, 10, 25);
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {          
                int a = textBox1.SelectionLength;
                textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, a);

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            d = DateTime.Now;
            textBox1.Text += d.ToString("dd.MM.yyyy - HH:mm:ss");
        }

        private void increaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont('+');
        }

        private void decreaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont('-');
        }
        private void ChangeFont(char i)
        {
            float currentSize = this.textBox1.Font.Size;
            if (i == '+')
                currentSize += 2.0F;
            else if (i == '-')
                currentSize -= 2.0F;

            this.textBox1.Font = new Font(this.textBox1.Font.Name, currentSize, this.textBox1.Font.Style, this.textBox1.Font.Unit);
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void ChangeLanguage(string lang)
        {

            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
            ChangeLanguage(menuStrip1.Items);


            void ChangeLanguage(ToolStripItemCollection collection)
            {
                foreach (ToolStripItem item in collection)
                {
                    resources.ApplyResources(item, item.Name, new CultureInfo(lang));
                    if (item is ToolStripDropDownItem)
                        ChangeLanguage(((ToolStripDropDownItem)item).DropDownItems);
                }
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("");
        }
        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-Ru");
        }

        private void ukraineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk-Uk");
        }

        private void belarusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("be-BY");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.textBox1.Size = new Size(this.Size.Width - 18, this.Size.Height - 65);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.textBox1.Size = new Size(this.Size.Width - 18, this.Size.Height - 65);
        }
    }
}
