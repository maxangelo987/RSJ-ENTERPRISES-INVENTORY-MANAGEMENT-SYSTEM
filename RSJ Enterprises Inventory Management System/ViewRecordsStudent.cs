using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Inventory_Management_System
{
    public partial class ViewRecordsStudent : Form
    {

        public ViewRecordsStudent()
        {
            InitializeComponent();
        }
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ProductsData st;
        UserData ut;
        private void ViewRecords_Load(object sender, EventArgs e)
        {


            ut = new UserData();
           
            try
            {
                    FileStream fs = new FileStream("c:/Confidential/GESMIS/User/" + "USER", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    ut = (UserData)b.Deserialize(fs);
                    fs.Close();
      
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }


            string barc = ut.barcode;


            string[] split = barc.Split(new Char[] { ' ' });
            foreach (string s in split)
            {
                if (s.Trim() != "") 
                {
                    if (File.Exists("c:/Confidential/GESMIS/Student/" + s))
                    {
                        FileStream fs = new FileStream("c:/Confidential/GESMIS/Student/" + s, FileMode.Open, FileAccess.Read);
                        BinaryFormatter b = new BinaryFormatter();
                        st = (ProductsData)b.Deserialize(fs);
                        fs.Close();

                        string[] row0 = { st.barcode, st.item, st.description, st.unit, st.quantity.ToString(), st.unitprice.ToString(), st.retailprice.ToString()};
                        dataGridView1.Rows.Add(row0);
                    }
                }
            }
        }
    }
}
