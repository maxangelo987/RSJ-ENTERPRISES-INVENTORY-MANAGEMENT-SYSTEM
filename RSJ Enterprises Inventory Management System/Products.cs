using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Inventory_Management_System
{
    public partial class Products : Form
    {

        UserData us;
        string productaddress = "C:/Confidential/GESMIS/Student/";

        public Products()
        {
            InitializeComponent();

            
        }

        private void Student_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }




        ProductsData pt;
        UserData ut;
        string barc;
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            pt = new ProductsData();
            ut = new UserData();
    

            if (!Directory.Exists("c:/Confidential/GESMIS/User/"))
            {
                Directory.CreateDirectory("c:/Confidential/GESMIS/User/");
            }

            try
            {
                FileStream fs3 = new FileStream("c:/Confidential/GESMIS/User/" + "USER", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter b3 = new BinaryFormatter();
                ut = (UserData)b3.Deserialize(fs3);
                pt.barcode = BarcodeBox.Text;
                pt.item = ItemBox.Text;
                pt.description = DescriptionBox.Text;
                pt.unit = UnitBox.Text;
                pt.quantity = long.Parse(QuantityBox.Text);
                pt.unitprice = double.Parse(UnitPriceBox.Text);
                pt.retailprice = double.Parse(RetailPriceBox.Text);

                ut.barcode = String.Concat(BarcodeBox.Text+" ", ut.barcode); ;
           
                fs3.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            if (!Directory.Exists(productaddress))
            {
                Directory.CreateDirectory(productaddress);
            }
           
            try
            {
                if (File.Exists(productaddress + pt.barcode))
                {
                    MessageBox.Show("This BARCODE is already exist. Please allot another one.");
                }
                else if (BarcodeBox.Text == "")
                {
                    MessageBox.Show("Barcode ID can not be empty!");
                }
                else
                {
                    FileStream fs = new FileStream(productaddress + pt.barcode, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, pt);
                    fs.Close();
                    MessageBox.Show("Product Has Been Added Successfully,Thank You");

                    FileStream fs2 = new FileStream("c:/Confidential/GESMIS/User/" + "USER", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b2 = new BinaryFormatter();
                    b2.Serialize(fs2, ut);
                    fs2.Close();
                    ClearButton.PerformClick();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void ContactBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                
                    File.Delete(productaddress +(BarcodeBox3.Text) );
                    MessageBox.Show(ItemBox3.Text + " Has Been Deleted From Our Database..!!!");
                    BarcodeBox3.Clear();
                    ItemBox3.Clear();
                    DescriptionBox3.Clear();
              

            }
            catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            BarcodeBox.Clear();
            ItemBox.Clear();
            DescriptionBox.Clear();
            UnitBox.Clear();
            QuantityBox.Clear();
            UnitPriceBox.Clear();
            RetailPriceBox.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pt = new ProductsData();
            pt.barcode = BarcodeBox2.Text;
            pt.item = ItemBox2.Text;
            pt.description = DescriptionBox2.Text;
            pt.unit = UnitBox2.Text;
            pt.quantity = long.Parse(QuantityBox2.Text);
            pt.unitprice = double.Parse(UnitPriceBox2.Text);
            pt.retailprice = double.Parse(RetailPriceBox2.Text);
          

            if (!Directory.Exists(productaddress))
            {
                Directory.CreateDirectory(productaddress);
            }
            try
            {
                    FileStream fs = new FileStream(productaddress + BarcodeBox2.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, pt);
                    fs.Close();
                    MessageBox.Show("Product Has Been Updated Successfully,Thank You");
                    ClearButton2.PerformClick();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BarcodeBox2.Clear();
            ItemBox2.Clear();
            DescriptionBox2.Clear();
            UnitBox2.Clear();
            QuantityBox2.Clear();
            UnitPriceBox2.Clear();
            RetailPriceBox2.Clear();

        }
    
        private void button1_Click_2(object sender, EventArgs e)
        {
            pt = new ProductsData();
            ut = new UserData();
            try
            {
                if (!File.Exists(productaddress + BarcodeBox2.Text))
                {
                    MessageBox.Show("Sorry The Id You Have Entered Is Not Valid");
                }
                else
                {
                    FileStream fs = new FileStream(productaddress + BarcodeBox2.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    pt = (ProductsData)b.Deserialize(fs);
                    fs.Close();
                    ItemBox2.Text = pt.item;
                    DescriptionBox2.Text = pt.description;
                    UnitBox2.Text = pt.unit;

              
                    QuantityBox2.Text = pt.quantity.ToString();
                    UnitPriceBox2.Text = pt.unitprice.ToString();
                    RetailPriceBox2.Text = pt.retailprice.ToString();

                    FileStream fs2 = new FileStream("c:/Confidential/GESMIS/User/" + "USER", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b2 = new BinaryFormatter();
                    ut = (UserData)b2.Deserialize(fs2);
                    fs2.Close();
                    
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }




           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            pt = new ProductsData();
            try
            {
                

                    FileStream fs = new FileStream(productaddress + BarcodeBox3.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    pt = (ProductsData)b.Deserialize(fs);
                    fs.Close();
                    ItemBox3.Text = pt.item;
                    DescriptionBox3.Text = pt.description;
    
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CertificateBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnrollmentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FatherBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label_unitprice_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

