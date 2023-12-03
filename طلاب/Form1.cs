using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace طلاب
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"server = DESKTOP-8GE2EV0\SQLEXPRESS; initial catalog =laith; integrated security=true ");
        SqlDataAdapter d;
        SqlCommandBuilder cmd;
        DataTable dt = new DataTable();
        int i = 0, j = 0;
        DataTable dt2 = new DataTable();
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.Height = 635;
                this.MaximumSize = new Size(this.Width, 635);
                this.MinimumSize = new Size(this.Width, 635);
            }
            else
            {
                ;
                this.Height = 416;
                this.MaximumSize = new Size(this.Width, 416);
                this.MinimumSize = new Size(this.Width, 416);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d = new SqlDataAdapter("select * from students", con);
            cmd = new SqlCommandBuilder(d);
            d.Fill(dt);
            Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            i = 0;
            show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            i = dt.Rows.Count - 1;
            show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (i != dt.Rows.Count - 1)
            {
                i++;
                show();
            }
            else
            {
                i = 0;
                show();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i = dt.Rows.Count - 1;
                show();
            }
            else
            {
                i--;
                show();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد فعلا حذف السجل؟", "انتبة!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dt.Rows[i].Delete();
                d.Update(dt);
                i = 0;
                show();
            }

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dt.Rows[i]["student_id"] = Convert.ToInt32(t1.Text);
            dt.Rows[i]["student_name"] = t2.Text;
            dt.Rows[i]["father_name"] = t3.Text;
            dt.Rows[i]["average"] = Convert.ToSingle(t4.Text);
            dt.Rows[i]["address"] = t5.Text;
            d.Update(dt);
            show();
        }

        private void S_TextChanged(object sender, EventArgs e)
        {
            dt2.Rows.Clear();
            SqlDataAdapter d2 = new SqlDataAdapter("select * from students where student_name like'%" + s.Text + "%'", con);
            d2.Fill(dt2);
            showsertch();
        }
        private void showsertch()
        {
            try
            {
                t1.Text = dt2.Rows[j]["student_id"].ToString();
                t2.Text = dt2.Rows[j]["student_name"].ToString();
                t3.Text = dt2.Rows[j]["father_name"].ToString();
                t4.Text = dt2.Rows[j]["average"].ToString();
                t5.Text = dt2.Rows[j]["address"].ToString();
            }
            catch
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(j !=dt2.Rows.Count-1)
            {
                j++;
            }
            else
            {
                j = 0;
                showsertch();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if(a1.Text != "" && a2.Text != "" && a3.Text != "" && a4.Text != "" && a5.Text != "")
            {
                DataRow nr = dt.NewRow();
                nr["student_id"] = Convert.ToInt32(a1.Text);
                nr["student_name"] = Convert.ToString(a2.Text);
                nr["father_name"] = Convert.ToString(a3.Text);
                nr["average"] = Convert.ToString(a4.Text);
                nr["address"] = Convert.ToString(a5.Text);
                dt.Rows.Add(nr);



                a1.Clear();
                a2.Clear();
                a3.Clear();
                a4.Clear();
                a5.Clear();
                d.Update(dt);
                i = dt.Rows.Count - 1;
                show();
            }
            else
            {
                MessageBox.Show("يجب ملئ كافة الحقول");
            }
        }

        private void A1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                a2.Focus();
        }

        private void A2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                a3.Focus();
        }

        private void A3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                a4.Focus();
        }

        private void A4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                a5.Focus();
        }

        private void A5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button8.PerformClick();
        }

        private void show()
        {
            if (dt.Rows.Count == 0)
            {
                t1.Clear();
                t2.Clear();
                t3.Clear();
                t4.Clear();
                t5.Clear();
            }
            else
            {
                t1.Text = dt.Rows[i]["student_id"].ToString();
                t2.Text = dt.Rows[i]["student_name"].ToString();
                t3.Text = dt.Rows[i]["father_name"].ToString();
                t4.Text = dt.Rows[i]["average"].ToString();
                t5.Text = dt.Rows[i]["address"].ToString();


            }
        }
    }
}
