using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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

            var entries = new Dictionary<string, decimal>();

            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];

                var split = line.Split(";");

                var category = split[2];
                var price = decimal.Parse(split[1]);

                if (entries.ContainsKey(category))
                {
                    entries[category] += price;
                }
                else
                {
                    entries[category] = price;
                }
            }

            resultTextBox.Clear();
            resultTextBox.Text += "Category\tAmount\r\n"; //avoid using \r\n
            foreach (var entry in entries)
            {
                resultTextBox.Text += $"{entry.Key}\t{entry.Value}{Environment.NewLine}";
            }
        }
    }
}
