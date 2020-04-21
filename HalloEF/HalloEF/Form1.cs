using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NORTHWINDEntities context = new NORTHWINDEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.Where(x => x.BirthDate.Value.Year > 1900).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            context.SaveChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.DataBoundItem is Employee emp)
            {
                MessageBox.Show(string.Join(", ", emp.Territories.Select(x => x.TerritoryDescription.Trim())));

            }
        }
    }
}
