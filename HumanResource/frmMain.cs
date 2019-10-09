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

namespace HumanResource
{
    public partial class frmMain : Form
    {
        DBUtilities dBUtilities;

        public frmMain()
        {
            InitializeComponent();
            ConnectToDb();
        }

        private void ConnectToDb()
        {
            dBUtilities = new DBUtilities();
            DataTable dt = dBUtilities.QueryTable(
                            "SELECT e.*, p.PositionName " +
                            "FROM tblEmployees e INNER JOIN tblPosition p " +
                            "ON e.PositionID = p.PositionID " +
                            "ORDER BY ID;");

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ID"].ToString());
                item.SubItems.Add(row["FirstName"].ToString());
                item.SubItems.Add(row["LastName"].ToString());
                item.SubItems.Add(row["MiddleName"].ToString());
                item.SubItems.Add(row["PositionName"].ToString());
                item.SubItems.Add(row["Gender"].ToString());

                string bdate = Convert.ToDateTime(row["BDate"].ToString()).ToString("MMM dd, yyy");

                item.SubItems.Add(bdate);
                item.SubItems.Add(row["HomeAddress"].ToString());
                item.SubItems.Add(row["TellNo"].ToString());
                item.SubItems.Add(row["MobileNo"].ToString());
                item.SubItems.Add(row["EmailAddress"].ToString());

                lstEmployees.Items.Add(item);
            }

        }

        
        
    

    
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuAddPosition_Click(object sender, EventArgs e)
        {
            
        }
    }
}
