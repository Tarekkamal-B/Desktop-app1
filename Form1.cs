using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seconed_Desktop_Application
{
    public partial class Form1 : Form
    {
        public SqlDataAdapter SqlDataAdapter { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Data Source=DESKTOP-O327GE5;Initial Catalog=DeskTopAPP;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string Insert = "insert into ProductInfo_Tab (ProductID, ItemName, Design, Color, InsertDate) values ('" + int.Parse(textBox1.Text) + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' ,  '" + comboBox1.Text + "' ,  '" + DateTime.Now + "' )";
            SqlCommand cmd = new SqlCommand(Insert, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sucessfuly Inserted");
            connection.Close();
            BindData();
        }

        void BindData()
        {
            string ConnectionString = "Data Source=DESKTOP-O327GE5;Initial Catalog=DeskTopAPP;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string command = "select *from ProductInfo_Tab;";
            SqlCommand cmd = new SqlCommand(command, connection);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-O327GE5;Initial Catalog=DeskTopAPP;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            string command = "update ProductInfo_Tab set ItemName ='"+ textBox2.Text + "' , Design = '"+ textBox3.Text + "', Color = '"+ comboBox1.Text + "', UpdateDate = '"+DateTime.Now+"'  where ProductID = '"+ int.Parse(textBox1.Text) + "';";
            SqlCommand cmd = new SqlCommand(command,connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sucessfuly Updated");
            BindData();
        }
    }
}
