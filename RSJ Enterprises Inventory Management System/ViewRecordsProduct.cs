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
using Excel = Microsoft.Office.Interop.Excel;

using System.Runtime.InteropServices;

namespace Inventory_Management_System
{
    public partial class ViewRecordsProduct : Form
    {
        string productaddress = "C:/Users/user/OneDrive/Work and Jobs ᜵ ᜄᜏ ᜀᜆ᜔ ᜋᜅ ᜄᜏᜁᜈ᜔/Logiclude/RSJ-Enterprises-Inventory-Management-System/Confidential/RSJEIMS/Product/";
        string useraddress = "C:/Users/user/OneDrive/Work and Jobs ᜵ ᜄᜏ ᜀᜆ᜔ ᜋᜅ ᜄᜏᜁᜈ᜔/Logiclude/RSJ-Enterprises-Inventory-Management-System/Confidential/RSJEIMS/User/";

        public ViewRecordsProduct()
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
       // 
            ut = new UserData();
        
            try
            {
                    FileStream fs = new FileStream(useraddress + "USER", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();
                    ut = (UserData)b.Deserialize(fs);
                    fs.Close();
      
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }


            ///
            ExcelExample.logic.CreateExcelDoc excell_app = new ExcelExample.logic.CreateExcelDoc();
            ///

            excell_app.createHeaders(1, 1, "Barcode", "A1", "B1", 2, "YELLOW", true, 10, "n");
            excell_app.createHeaders(1, 3, "Item Description", "C1", "D1", 2, "YELLOW", true, 10, "n");
            string barc = ut.barcode;
        
            string[] split = barc.Split(new Char[] { ' ' });
            int  i = 2;
            foreach (string s in split)
            {
                if (s.Trim() != "") 
                {
                    if (File.Exists(productaddress + s))
                    {
                        FileStream fs = new FileStream(productaddress + s, FileMode.Open, FileAccess.Read);
                        BinaryFormatter b = new BinaryFormatter();
                        st = (ProductsData)b.Deserialize(fs);
                        fs.Close();

                        string[] row0 = { st.barcode, st.itemdescription, st.unit, st.quantity.ToString(), st.unitprice.ToString(), st.retailprice.ToString()};
                  
                        excell_app.createHeaders(i, 1, st.barcode.ToString(), "A" + i.ToString(), "B" + i.ToString(), 0, "GRAY", true, 10, "");
                        dataGridView1.Rows.Add(row0);
                        i++;
                    }
                }
            }
        }
    }
}
