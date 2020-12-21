using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterFrequency
{
    public partial class Form1 : Form
    {
        public List<DataGridViewRow> characterList;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;

            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();

            Console.WriteLine(this.characterList);

            if (this.characterList != null)
            {
                this.characterList.Clear();
            }


            foreach (char character in textBox.Text)
            {
                Boolean exists = false;
                if (this.dataGridView1.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null) {
                            if (row.Cells[0].Value.ToString().Contains(character.ToString()))
                            {
                                exists = true;
                                row.Cells[1].Value = Convert.ToInt32(row.Cells[1].Value) + 1;
                            }
                        }
                    }
                }

                if (!exists)
                {
                    DataGridViewRow newRow = (DataGridViewRow)this.dataGridView1.Rows[0].Clone(); ;
                    newRow.Cells[0].Value = character;
                    newRow.Cells[1].Value = 1;
                    this.dataGridView1.Rows.Add(newRow);
                }
            }
        }
    }
}
