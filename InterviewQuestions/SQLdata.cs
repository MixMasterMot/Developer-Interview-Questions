using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;

namespace InterviewQuestions
{
    class SQLdata
    {
        public List<Question> getSqlData(string topic)
        {
            List<Question> questions = new List<Question>();
            string connectionString = initConnectionString();
            if (topic == "")
            {
                return questions;
            }
            string tableID = getTableID(topic, connectionString);

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string oString = "Select * from "+tableID;
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        string quest = oReader[1].ToString();
                        string ans = oReader[2].ToString();
                        Question q = new Question(quest, ans);
                        questions.Add(q);
                    }
                    myConnection.Close();
                }
            }
            return questions;
        }

        public List<string> getTopics()
        {
            string connectionString = initConnectionString();
            List<string> topics = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //get stock
                string oString = "Select * from Topics";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        topics.Add(oReader["topic"].ToString());
                    }
                    connection.Close();
                }
                return topics;
            }
        }

        public void checkAndUpdateData(string topic, List<Question> questions)
        {
            string connectionString = initConnectionString();
            if (checkIfExists(topic, connectionString))
            {
                //add option to update values
                DialogResult result = MessageBox.Show("The topic: "+topic+" already exists. Update the questions ?", "Caution", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //clear old values
                    clearTableData(topic, connectionString);
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                //create table
                createTable(topic, connectionString);
            }
            insertData(topic, questions, connectionString);
        }

        private void createTable(string topic, string connectionString)
        {
            int id = 0;
            string query = "Insert Into Topics output INSERTED.Id values(@topic)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@topic", topic);
                id = (int)command.ExecuteScalar();
                connection.Close();
            }

            query = ("CREATE TABLE a"+ id.ToString() + "(id INTEGER IDENTITY(1,1) PRIMARY KEY, question nvarchar(MAX), answer nvarchar(MAX))");
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                //command.Parameters.AddWithValue("@Topic", id.ToString());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void clearTableData(string topic, string connectionString)
        {
            string tableID = getTableID(topic, connectionString);
            string query = "delete from "+tableID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void insertData(string topic, List<Question> questions, string connectionString)
        {
            string tableID = getTableID(topic, connectionString);
            string query = ("INSERT INTO " + tableID + " values(@Question, @Answer)");
            foreach (Question q in questions)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Question", q.getQuestion());
                    command.Parameters.AddWithValue("@Answer", q.getAnswer());
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            
        }

        private string initConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["InterviewQuestions.Properties.Settings.QuestionsAndAnswersConnectionString"].ConnectionString;
        }

        private bool checkIfExists(string topic, string connectionString)
        {
            string id = "";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string oString = "Select * from Topics where topic=@topic";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@topic", topic);

                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        id = oReader["Id"].ToString();
                    }
                    myConnection.Close();
                }
            }
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string getTableID(string topic, string connectionString)
        {
            string id = "";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string oString = "Select * from Topics where topic=@topic";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@topic", topic);

                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        id = oReader["Id"].ToString();
                    }
                    myConnection.Close();
                }
            }
            return "a"+id;
        }
    }
}
