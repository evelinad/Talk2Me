using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.Configuration;

namespace Talk2Me_admin
{
    class ConnSQL
    {
        // value of connSQL
     /*   public String ConnectionString="Data Source=seqr2jopn3.database.windows.net;" +
                              "Initial Catalog=ImagineCup;" +
                              "User id=imaginecup;" +
                              "Password=1m4g1n3#1;";
       */
        public String ConnectionString = "Server=tcp:bbyrpg49dt.database.windows.net,1433;"+
            "Database=[talk2me];"+
            "User ID=talk2me@bbyrpg49dt;"+
            "Password={T1lkT0M3};" +
            "Trusted_Connection=False;"+
            "Encrypt=True;"+
            "Connection Timeout=30;";
        public String ConnectionString2 = "Driver={SQL Server Native Client 10.0};Server=tcp:bbyrpg49dt.database.windows.net,1433;Database=[talk2me];Uid=talk2me@bbyrpg49dt;Pwd={T1lkT0M3};Encrypt=yes;Connection Timeout=100;";
        public SqlConnectionStringBuilder SqlConnBuilder;
        // instance variables/attributes
        String sqlString;       // sql to execute
        public bool execCorrect;       // sql executed correctly
        public bool execDone;          // sql done executing
        public String errorMsg;         // error String
        public DataSet sqlDataSet = null;     // can be read directly

        public string result;
         
        System.Configuration.ConfigurationFileMap fileMap ;
        System.Configuration.Configuration config ;
        SqlConnectionStringBuilder SqlConnStrBuilder ;

       
       
        public bool authentication(string username, string password)
        {
            string _username, _password;
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());

                SqlCommand command = conn.CreateCommand();
                 
                        conn.Open();
                        string cmd = "SET IDENTITY_INSERT talk2me.dbo.Users ON;select * from talk2me.dbo.Administrators;SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                        command.CommandText = cmd;
                        SqlDataReader reader = command.ExecuteReader();
                        
                            while (reader.Read())
                            {
                                _username = reader["username"].ToString();
                                _password = reader["password"].ToString();
                                if (string.Compare(username, _username) == 0 && string.Compare(password, _password) == 0)
                                    return true;
                            }
                        
               conn.Close();
                    

                
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
            return false;

        }
        public string getUsers()
        {
            string _username, _password;
            string str = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());

                SqlCommand command = conn.CreateCommand();

                conn.Open();
                string cmd = "SET IDENTITY_INSERT talk2me.dbo.Users ON;select username from talk2me.dbo.Users;SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                command.CommandText = cmd;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _username = reader["username"].ToString();
                    str += _username + "|";
                }

                conn.Close();



            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
            return str;

        }
        public void deleteUser(string username)
        {

            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());
                SqlCommand command = conn.CreateCommand();

                conn.Open();
                string cmd = "set ansi_warnings off SET IDENTITY_INSERT talk2me.dbo.Users ON delete from talk2me.dbo.Users  where username ='" + username + "' SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                command.CommandText = cmd;
                command.ExecuteNonQuery();
                conn.Close();



            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }


        }
        public string  password_recovery(string username, string question, string answer)
        {
            string result = "";
            string _username, _question, _answer;
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());
                
                SqlCommand command = conn.CreateCommand();
                
                        conn.Open();
                        string cmd = "SET IDENTITY_INSERT talk2me.dbo.Users ON;select * from talk2me.dbo.Users;SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                        command.CommandText = cmd;
                        SqlDataReader reader = command.ExecuteReader();
                       
                            while (reader.Read())
                            {
                                _username = reader["username"].ToString();

                                _question = reader["secret_question"].ToString();
                                _answer = reader["secret_answer"].ToString();
                                if (string.Compare(username, _username) == 0 && string.Compare(question, _question) == 0 && string.Compare(answer, _answer) == 0)
                                {
                                    result += reader["email"].ToString() + "," + reader["password"].ToString();
                                    return result;
                                }
                            }
                        
                        conn.Close();
                    

                
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
            return null;

        }
        public void update(string username, string status)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());
                SqlCommand command = conn.CreateCommand() ;
                    
                        conn.Open();
                        string cmd = "set ansi_warnings off SET IDENTITY_INSERT talk2me.dbo.Users ON update talk2me.dbo.Users set status = '"+status+"'where username = '"+ username+"' SET IDENTITY_INSERT talk2me.dbo.Users OFF"; 
                        command.CommandText = cmd;
                        command.ExecuteNonQuery();
                        conn.Close();
                    

                
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }

        }

       
    
    
       
        public ConnSQL()
        {
             
             SqlConnStrBuilder = new SqlConnectionStringBuilder();
            // init sql conn object
            SqlConnStrBuilder.DataSource = "tcp:bbyrpg49dt.database.windows.net,1433";
            //Server=tcp:bbyrpg49dt.database.windows.net,1433;Database=[talk2me];User ID=talk2me@bbyrpg49dt;Password={your_password_here};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;
            SqlConnStrBuilder.InitialCatalog = "talk2me";
            SqlConnStrBuilder.Encrypt = true;
            SqlConnStrBuilder.TrustServerCertificate = false;
            SqlConnStrBuilder.UserID = "talk2me@bbyrpg49dt";
            SqlConnStrBuilder.Password = "T1lkT0M3";

      /*      using (SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString()))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    string cmd = "SET IDENTITY_INSERT talk2me.dbo.Users ON;select * from talk2me.dbo.Users;SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                    command.CommandText = cmd;
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             result+= reader["username"].ToString()+" ";
                        }
                    }
                    conn.Close();
                }
                
            }
            // start sql execution in another thread
            try
            {
             //   Parallel.Invoke(getData);
            }
            
            // in case of threading exception
            catch (AggregateException e)
            {
                execDone = true;
                execCorrect = false;
                errorMsg=e.InnerException.ToString();
            }*/
        } 

      
    }
}
