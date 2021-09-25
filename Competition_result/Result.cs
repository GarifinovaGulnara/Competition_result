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

namespace Competition_result
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTableAsTXT = new OpenFileDialog();
            openTableAsTXT.Filter = "Документ TXT (*.txt) |*.txt";
            if (openTableAsTXT.ShowDialog() == DialogResult.OK)
            {
                tbResult.Text = File.ReadAllText(openTableAsTXT.FileName, Encoding.Default);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveTableAsCSV = new SaveFileDialog();
            saveTableAsCSV.Filter = "Документ TXT (*.txt) |*.txt";
            saveTableAsCSV.Title = "Сохранить результат расчетов";
            if (saveTableAsCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(saveTableAsCSV.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(file, Encoding.Default);
                    sw.Write(Surname.Text + " " + tbResult.Text + " " + Time.Text);
                    sw.WriteLine();
                    sw.Close();
                }
                catch { }
            }
        }
    }
}
