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

namespace FinalProject
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void buildAndDisplay(int pBookID)
        {
            try
            {
                //Step 1: Declare local variables for data access objects
                //   DataReader is instantiated by invoking "ExecuteReader" method
                //   on Command object

                //   SQL string is not passed as an argument to the constructor of
                //   the Command object...SP name will be assigned to the 
                //   Command object's Text property
                //   Also, the connection is assigned to the "Connection" property
                //   of the Command object ... not passed as second argument
                //   in constructor
                SqlConnection objConnection = new SqlConnection("Data Source=(local);initial catalog=DistributedLibraryAssign; User ID=sa;Password=Sql2014$");
                SqlCommand objCommand = new SqlCommand();
                SqlDataReader objReader;

                //Step 2:  Assign property values to Coomand object
                objCommand.Connection = objConnection;
                objCommand.CommandText = "procFinalProjUC2";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@book_ID", pBookID);


                //Step 3: Make DB connection
                objConnection.Open();

                //Step 4. Tell DBMS to execute SP and instantiate DataReader Class
                objReader = objCommand.ExecuteReader();




                //Step 5: Fetch data from result set 1 row at a time 
                //(connection open throughout).  Exit loop when reader fails.
                while (objReader.Read())
                {

                    var item1 = new ListViewItem(new[] { objReader[0].ToString(), objReader[1].ToString(), objReader[2].ToString() });
                    listView1.Items.Add(item1);
                }

                //objConnection.Close(); //unnecessary because local variable loses scope at end of

            }

            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    listView1.Items.Clear();
                    buildAndDisplay(id);
                    
                }
                else
                {
                    MessageBox.Show("Please Enter ID");
                    textBox1.Focus();
                }


            }
            catch
            {
                MessageBox.Show("Enter valid Book_ID");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtu.be/bcxbGcgRm-I");
            
        }
    }
}