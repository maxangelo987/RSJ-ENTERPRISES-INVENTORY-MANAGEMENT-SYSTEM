using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Inventory_Management_System
{
    public partial class Admins : Form
    {

        string productaddress = "C:/Users/user/OneDrive/Work and Jobs ᜵ ᜄᜏ ᜀᜆ᜔ ᜋᜅ ᜄᜏᜁᜈ᜔/Logiclude/RSJ-Enterprises-Inventory-Management-System/Confidential/RSJEIMS/Product/";
        string useraddress = "C:/Users/user/OneDrive/Work and Jobs ᜵ ᜄᜏ ᜀᜆ᜔ ᜋᜅ ᜄᜏᜁᜈ᜔/Logiclude/RSJ-Enterprises-Inventory-Management-System/Confidential/RSJEIMS/User/";
        string adminaddress = "C:/Users/user/OneDrive/Work and Jobs ᜵ ᜄᜏ ᜀᜆ᜔ ᜋᜅ ᜄᜏᜁᜈ᜔/Logiclude/RSJ-Enterprises-Inventory-Management-System/Confidential/RSJEIMS/Admin/";

        public Admins()
        {
            InitializeComponent();
       //     TrainerBox.SelectedIndex = 0;
            //teachingfield.SelectedIndex = 0;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            TeacherPassword.UseSystemPasswordChar = false;
            TeacherPassword2.UseSystemPasswordChar = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProfilePic_Click(object sender, EventArgs e)
        {

        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void CertificateBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ContactBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContactBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FatherBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnrollmentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        

        private void TeacherProfilePic1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void TeacherName_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void TeacherId_TextChanged(object sender, EventArgs e)
        {

        }

        private void TeacherId_Enter(object sender, EventArgs e)
        {

        }

        TeacherData tc;
        private void button3_Click(object sender, EventArgs e)
        {
            tc = new TeacherData();
            tc.Username = TeacherUsername.Text;
            tc.Password = TeacherPassword.Text;
         

           
            if (!Directory.Exists(adminaddress))
            {
                Directory.CreateDirectory(adminaddress);
            }
            try
            {
                if (File.Exists(adminaddress + tc.Username))
                {
                    MessageBox.Show("This Id  Is Already Exist...Sorry");
                }
                else if (TeacherUsername.Text == "")
                {
                    MessageBox.Show("Teacher Id Can Not Be Empty..!!!");
                }
                else
                {

                    FileStream fs = new FileStream(adminaddress + tc.Username, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, tc);
                    fs.Close();
                    MessageBox.Show("Teacher Has Been Added Successfully... Thank You...!!!");
                    button2.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPanel lp = new LoginPanel();
            lp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(adminaddress + TeacherUsername2.Text))
            {
                MessageBox.Show("Sorry Invalid Id...!!!");
            }

            else
            {
                try
                {
                    FileStream fs = new FileStream(adminaddress+ TeacherUsername2.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    tc = (TeacherData)b.Deserialize(fs);
                    fs.Close();
                    TeacherUsername2.Text = tc.Username;
                    TeacherPassword2.Text = tc.Password;
                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
  
        }

        private void button7_Click(object sender, EventArgs e)
        {

            tc.Username = TeacherUsername2.Text;
            tc.Password = TeacherPassword2.Text;
        
            try
            {
                FileStream fs = new FileStream(adminaddress + TeacherUsername2.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fs, tc);
                fs.Close();
                MessageBox.Show("Teacher Has Been Updated Successfully... Thank You...!!!");
                button5.PerformClick();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            TeacherUsername2.Clear();
            TeacherPassword2.Clear();
         

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!File.Exists(adminaddress + Teacher_Username.Text))
            {
                MessageBox.Show("Sorry Invalid Id...!!!");
                button8.PerformClick();
            }
            else
            {
                try
                {
                    FileStream fs = new FileStream(adminaddress + Teacher_Username.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    tc = (TeacherData)b.Deserialize(fs);
                    fs.Close();
                    Teacher_Username.Text = tc.Username;

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            TeacherUsername.Clear();
            TeacherPassword.Clear();
         
        }

        private void TeacherProfilePic2_Click(object sender, EventArgs e)
        {
           
        }

    

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(adminaddress + Teacher_Username.Text);
                MessageBox.Show("Trainer Record Has Been Deleted From Our Database");
                button8.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Teacher_Username.Clear();
          
        }

    

        private void teachingfield_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void labShow_MouseHover(object sender, EventArgs e)
        {
            TeacherPassword.UseSystemPasswordChar = true;
        }

        private void labShow_MouseLeave(object sender, EventArgs e)
        {
            TeacherPassword.UseSystemPasswordChar = false;
        }



        private void labshow2_MouseHover_1(object sender, EventArgs e)
        {
            TeacherPassword2.UseSystemPasswordChar = true;
        }

        private void labshow2_MouseLeave_1(object sender, EventArgs e)
        {
            TeacherPassword2.UseSystemPasswordChar = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPanel lp = new LoginPanel();
            lp.Show();
        }
    }
}

