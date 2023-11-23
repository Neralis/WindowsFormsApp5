using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory =
               Environment.CurrentDirectory;
                string path = saveFileDialog1.FileName;
                try
                {
                    StreamWriter potok_zap = new StreamWriter(path,
                    false, Encoding.Default);
                    potok_zap.WriteLine(textBox1.Text);

                    potok_zap.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка достпа к файлу" +
                    exc.ToString(), "Текстовый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                this.Text = "Сохраняем " + Path.GetFileName(path);
                textBox1.Modified = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Количество набранных символов = " + textBox1.TextLength.ToString();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory =
               Environment.CurrentDirectory;
                string path = openFileDialog1.FileName;
                try
                {

                    StreamReader potok = new StreamReader(path,
                    Encoding.Default);

                    textBox1.Text = potok.ReadToEnd();
                    potok.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения файла" +
                    exc.ToString(), "Текстоввый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                this.Text = "Открываем " + Path.GetFileName(path);
                openFileDialog1.FileName = string.Empty;

                textBox1.SelectionStart = textBox1.TextLength;
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            this.Text = "Новый документ";
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                if (!textBox1.Font.Equals(fontDialog1.Font))
                {
                    Font f = textBox1.Font;
                    textBox1.Font = fontDialog1.Font;
                    f.Dispose();
                }
        }

        private void выравниваниеТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Left;
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem gir = sender as ToolStripMenuItem;
            gir.Checked = !gir.Checked;
            FontStyle fs = textBox1.Font.Style;
            fs = gir.Checked ? (fs | gir.Font.Style) : (fs & ~gir.Font.Style);
            Font f = textBox1.Font;
            textBox1.Font = new Font(f, fs);
            f.Dispose();
        }

        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = colorDialog1.Color;
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = colorDialog1.Color;
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText=" ";
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =
Control.IsKeyLocked(Keys.CapsLock) ? "Нажата Caps Lock" : "";
            toolStripStatusLabel2.Text =
           DateTime.Now.ToLongTimeString();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Font currentFont = textBox1.Font;
            FontStyle newStyle = (textBox1.Font.Style.HasFlag(FontStyle.Bold)) ? FontStyle.Regular : FontStyle.Bold;
            textBox1.Font = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Font currentFont = textBox1.Font;
            FontStyle newStyle = (textBox1.Font.Style.HasFlag(FontStyle.Italic)) ? FontStyle.Regular : FontStyle.Italic;
            textBox1.Font = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
    }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (textBox1.Font.Underline)
            {
                textBox1.Font = new Font(textBox1.Font, textBox1.Font.Style & ~FontStyle.Underline);
            }
            else
            {
                textBox1.Font = new Font(textBox1.Font, textBox1.Font.Style | FontStyle.Underline);
            }
        }
    }
}
