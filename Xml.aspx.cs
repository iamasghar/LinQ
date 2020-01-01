using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace LinQ
{
    public partial class Xml : System.Web.UI.Page
    {
        String Filename = "D:/6th Sem/VP/LinQ/linq_Xml.xml";
        DataTable dt;
        XDocument xmldoc = XDocument.Load("D:/6th Sem/VP/LinQ/linq_Xml.xml");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindGrid()
        {
            //add xml document
            var bind = xmldoc.Descendants("Employee").Select(p => new
            {
                emp_id = p.Element("emp_id").Value,
                Name = p.Element("name").Value,
                Cell = p.Element("cell").Value,
                Address = p.Element("address").Value
            }).OrderBy(p => p.emp_id);
            GridView1.DataSource = bind;
            GridView1.DataBind();
        }
        public SqlConnection DbConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UL4JOR7;Initial Catalog=OfcDB;Integrated Security=True");
            return conn;
        }
        public DataTable search(String query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = DbConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                String exc = ex.Message;
            }
            return dt;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            XElement emp = new XElement("Employee",
                    new XElement("emp_id", id.Text),
                    new XElement("name", name.Text),
                    new XElement("cell", cell.Text),
                    new XElement("address", address.Text));
            xmldoc.Root.Add(emp);
            xmldoc.Save(Filename);
            BindGrid();
            Reset();
        }

        private void Reset()
        {
            id.Text = "";
            name.Text = "";
            cell.Text = "";
            address.Text = "";
            id.Focus();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            XElement emp = xmldoc.Descendants("Employee").FirstOrDefault(p => p.Element("emp_id").Value == id.Text);
            if (emp != null)
            {
                emp.Element("name").Value = name.Text;
                emp.Element("cell").Value = cell.Text;
                emp.Element("address").Value = address.Text;
                xmldoc.Save(Filename);
                BindGrid();
                Reset();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            XElement emp = xmldoc.Descendants("Employee").FirstOrDefault(p => p.Element("emp_id").Value == id.Text);
            if (emp != null)
            {
                emp.Remove();
                xmldoc.Save(Filename);
                BindGrid();
                Reset();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            XElement emp = xmldoc.Descendants("Employee").FirstOrDefault(p => p.Element("emp_id").Value == id.Text);
            if (emp != null)
            {
                name.Text = emp.Element("name").Value;
                cell.Text = emp.Element("cell").Value;
                address.Text = emp.Element("address").Value;

            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string qry = "select emp_id,name,cell,address from employee";
            dt = search(qry);
            XDocument xmlDoc = new XDocument(
                                  new XElement("Employees",
                                  from f in dt.AsEnumerable()
                                  select new XElement("Employee",
                                      new XElement("emp_id", f.Field<string>("emp_id")),
                                      new XElement("name", f.Field<string>("Name")),
                                      new XElement("cell", f.Field<string>("cell")),
                                      new XElement("address", f.Field<string>("address")))));

            xmlDoc.Save(Filename);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    XElement emp = new XElement(new XElement("emp_id",dt.Rows['emp_id'].ToString()));
            //}
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string qry = "select emp_id,name,cell,address from employee";
            dt = search(qry);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}