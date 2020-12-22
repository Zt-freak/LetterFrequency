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
                Boolean capitalisable = false;
                Boolean capitalExists = false;

                if (Char.IsUpper(character) || Char.ToUpper(character) != character)
                {
                    capitalisable = true;
                }

                if (this.dataGridView1.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null) {
                            if (row.Cells[0].Value.ToString().Equals(character.ToString()))
                            {
                                exists = true;
                                row.Cells[1].Value = Convert.ToInt32(row.Cells[1].Value) + 1;
                            }
                            if (row.Cells[0].Value.ToString().Equals(Char.ToUpper(character).ToString() + " [Total]"))
                            {
                                row.Cells[1].Value = Convert.ToInt32(row.Cells[1].Value) + 1;
                            }
                        }
                    }
                }

                if (!exists)
                {
                    DataGridViewRow newRow = (DataGridViewRow)this.dataGridView1.Rows[0].Clone(); ;
                    newRow.Cells[0].Value = character.ToString();
                    newRow.Cells[1].Value = 1;
                    this.dataGridView1.Rows.Add(newRow);
                    if (capitalisable)
                    {
                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                if (row.Cells[0].Value.ToString().Equals(Char.ToUpper(character).ToString() + " [Total]"))
                                {
                                    capitalExists = true;
                                }
                            }
                        }
                        if (!capitalExists)
                        {
                            DataGridViewRow newCapRow = (DataGridViewRow)this.dataGridView1.Rows[0].Clone(); ;
                            newCapRow.Cells[0].Value = Char.ToUpper(character).ToString() + " [Total]";
                            newCapRow.Cells[1].Value = 1;
                            this.dataGridView1.Rows.Add(newCapRow);
                        }
                    }
                }
            }
        }
    }
}
