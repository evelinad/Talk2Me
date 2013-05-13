using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.Configuration;

namespace Talk2Me_login
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
           
        public void getData()
        {
            try
            {
                // connect to SQL database
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();    

                // execute sql and get results
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(@"" + sqlString, conn);
                DataSet sqlSet = new DataSet();
                sqlAdapt.Fill(sqlSet);
                
                // close SQL connection
                conn.Close();

                // correct execution
                execDone = true;
                execCorrect = true;
            }
            catch (Exception exc)
            {
                // exception generates an error
                errorMsg=exc.ToString();
                execDone = true;
                execCorrect = false;
            }

        }
        public Users getUser(string username, string password)
        {
            Users user=new Users();
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());
                SqlCommand command = conn.CreateCommand();
                conn.Open();
                string cmd = "SET IDENTITY_INSERT talk2me.dbo.Users ON;select * from talk2me.dbo.Users where username='"+username+"' and password = '"+password+"';SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                command.CommandText = cmd;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                
                    user.Username = reader["username"].ToString();
                    user.ID = Convert.ToInt16(reader["ID"].ToString());
                    user.Password = reader["password"].ToString();
                    user.Gender = reader["gender"].ToString();
                    user.Birtplace = reader["birthplace"].ToString();
                    user.Birthdate = reader["birthdate"].ToString();
                    user.Telephone = reader["telephone"].ToString();
                    user.PersonalInterest = reader["personal_interest"].ToString();
                    user.Education = reader["education"].ToString();
                    user.Workplace = reader["workplace"].ToString();
                    user.CurrentCity = reader["current_city"].ToString();
                    user.Country = reader["country"].ToString();
                    user.Address = reader["address"].ToString();
                    user.Nationality = reader["nationality"].ToString();
                    user.Languages = reader["languages"].ToString();
                    user.GroupsFriends = reader["groups_friends"].ToString();
                    user.SecretQuestion = reader["secret_question"].ToString();
                    user.SecretAnswer = reader["secret_answer"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Status = reader["status"].ToString();
                    user.FirstName = reader["first_name"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    
                    
                

                conn.Close();
                return user;
                
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
           
            return null;
        }
        public bool authentication(string username, string password)
        {
            string _username, _password;
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
        public int getID(string username)
        {
            int nr=0;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString()))
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        conn.Open();
                        string cmd = "set ansi_warnings off SET IDENTITY_INSERT talk2me.dbo.Users ON select id from talk2me.dbo.Users where  username= '"+username+"'SET IDENTITY_INSERT talk2me.dbo.Users OFF";
                        command.CommandText = cmd;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nr++;
                            }
                        }
                        conn.Close();
                    }

                }
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
            return nr;
        }
        public int selectAll()
        {
           
            int nr=0;
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
                                nr++;
                            }
                        
                        conn.Close();
                    

                
            }
            catch (Exception exc)
            {
                //MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
            return nr;

        }

        public void insert(Users user)
        {

            int nr = 0;
            try
            {
                SqlConnection conn = new SqlConnection(SqlConnStrBuilder.ToString());

                SqlCommand command = conn.CreateCommand();
                
                        conn.Open();
                        string cmd = "set ansi_warnings off SET IDENTITY_INSERT talk2me.dbo.Users ON insert into talk2me.dbo.Users (ID, username, password, gender, birthdate, birthplace, telephone, personal_interest, education, workplace, current_city, country, address, nationality, languages,  groups_friends,secret_question,secret_answer,email,status,first_name,last_name)values('" + user.ID + "','" + user.Username + "','" + user.Password + "','" + user.Gender + "','" + user.Birthdate + "','" + user.Birtplace + "','" + user.Telephone + "','" + user.PersonalInterest + "','" + user.Education + "','" + user.Workplace + "','" + user.CurrentCity + "','" + user.Country + "','" + user.Address + "','" + user.Nationality + "','" + user.Languages + "','" + user.GroupsFriends + "','" + user.SecretQuestion + "','" + user.SecretAnswer + "','" + user.Email + "','" + user.Status + "','" + user.FirstName + "','" + user.LastName + "')";
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
             fileMap = new ConfigurationFileMap("App1.config");
             config = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
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
