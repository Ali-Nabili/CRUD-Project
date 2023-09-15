using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Crud_CR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void cleartxt()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox1.Focus();
        }

        public db db1 = new db();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db1.Humans.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b==false)
           { 
            human human = new human()
            {
                name=textBox1.Text,
                family=textBox2.Text,
                age=Convert.ToByte(textBox3.Text)
            };

            bool b =human.register(human);
            if (b)
            {
                MessageBox.Show("اطلاعات ثبت شد");
            }
            else
            {
                MessageBox.Show("اطلاعات تکراری میباشد");
            }
                cleartxt();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db1.Humans.ToList();
            }
            else
            {
                human human = new human ()
                { 
                name = textBox1.Text,
                family = textBox2.Text,
                age = Convert.ToByte(textBox3.Text)
                };
                human.update(human, id);

                b = false;

                MessageBox.Show("عملیات آپدیت اطلاعات با موفقیت انجام شد");

                button1.Text = "register";

                cleartxt();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readall();
            }
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            human human = new human();
            if (textBox4.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readall();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readbyname(textBox4.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }
        public int id=0;
        bool b = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            human human1 = new human();  
            human1 =  human1.readbyid(id);
            textBox1.Text = human1.name;
            textBox2.Text = human1.family;
            textBox3.Text = (human1.age).ToString();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            human human = new human();
            if (id!=0)
            {
                DialogResult=MessageBox.Show("آیا مطمین هستید ؟","خطر",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (DialogResult==DialogResult.Yes) 
                { 
                
                human.delete(id); 
                id = 0;

                cleartxt();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readall();

                }
            }
        }

        //private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    b = true;
        //    button1.Text = "OK";
        //}

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            b = true;
            button1.Text = "Update";
        }
    }
}
