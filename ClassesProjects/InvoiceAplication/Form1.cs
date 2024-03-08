using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InvoiceApplication.BusinessLogic;

namespace InvoiceAplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;

            var content = File.ReadAllText(path);
            content = content.Replace(";", "\t");

            resultTextBox.Text = content;
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;

            var lines = File.ReadAllLines(path);

            var entries = new InvoiceProcessor().GroupByCategories(lines.ToList());
            
            resultTextBox.Clear();
            resultTextBox.Text += "Category\tAmount\r\n"; //avoid using \r\n
            foreach (var entry in entries)
            {
                resultTextBox.Text += $"{entry.Item1}\t{entry.Item2}{Environment.NewLine}";
            }
        }
    }
}
