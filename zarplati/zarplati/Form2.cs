using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace zarplati
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=303-16; Initial Catalog=Zarplati; Integrated Security=true;");

        public Form2()
        {
            InitializeComponent();
        }
        public int id;
        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From coeefs, grade Where coeefs.id = '{id}' AND coeefs.id=grade.id", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                textBox1.Text = dr["Junior"].ToString();
                textBox2.Text = dr["Middle"].ToString();
                textBox3.Text = dr["Senior"].ToString();
                textBox4.Text = dr["coef_analiz"].ToString();
                textBox5.Text = dr["coef_device"].ToString();
                textBox6.Text = dr["coef_service"].ToString();
                textBox7.Text = dr["coef_time"].ToString();
                textBox8.Text = dr["coef_complexity"].ToString();
                textBox9.Text = dr["coef_money"].ToString();
                dr.Close();
                
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            con.Open();
            
            {
                SqlCommand com = new SqlCommand($"UPDATE coeefs SET " +
                    $"[coef_analiz] = {textBox4.Text}, " +
                    $"[coef_device] = {textBox5.Text}, " +
                    $"[coef_service] = {textBox6.Text}, " +
                    $"[coef_time] = {textBox7.Text}, " +
                    $"[coef_complexity] = {textBox8.Text}, " +
                    $"[coef_money] = {textBox9.Text} " +
                    $"WHERE id = '{id}'", con);
                if (com.ExecuteNonQuery() != 0) MessageBox.Show("Коэфы изменены");
                else MessageBox.Show("Ошибка при добавлении");

            }
            con.Close();
        }
        
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
