using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoCertWebSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnQuickTest_Click(object sender, EventArgs e)
        {
            SimulateUrlVisit();

            var x = 3;
            var y = 4;
            var z = x + y;

            var super = "super";
            var batman = "batman";
        }
        protected void btnRandomNumber_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            lblRandomNumber.Text = rand.Next(1, 100).ToString();
        }
        protected void btnMySettings_Click(object sender, EventArgs e)
        {
            string key = "mysettings";
            string value = ConfigurationManager.AppSettings[key];

            lblMySettings.Text = value.ToString();
        }



        //----------------------------------------------------------
        private void SimulateUrlVisit()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://externalsite.com?id=12345&sessionid=abc123");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://martinnordkvist.com");

            request.Method = "GET";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                for (int i = 0; i < 20; i++)
                {

                    string result = reader.ReadToEnd();
                    // Process the response text if you need to...
                }
            }
        }
        private void CallDataBase()
        {
            string key = "martinDB";
            string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            // Provide the query string with a parameter placeholder.
            string queryString = @"SELECT [Comment] FROM [dbo].[Comments]";


            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    string x = "";
                    while (reader.Read())
                    {
                        x = reader[0].ToString();

                    }
                    reader.Close();
                    lblQuickTest.Text = x;
                }
                catch (Exception ex)
                {
                    lblQuickTest.Text = ex.Message.ToString();
                }


            }
        }

    }
}