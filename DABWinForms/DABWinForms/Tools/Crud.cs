using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DABWinForms.Tools
{
    internal class Crud : ICrud
    {
        public static string userName = string.Empty;
        public static string lastName = string.Empty;
        public static string fn = string.Empty;
        public static int attemptCount = 0;
        public static decimal balance = 0m;
        public static int cardNumber = 0;
        private static decimal globalBalance = 0m;
        private const decimal LOW = 100M;
        SqlConnection connection = DBCon.GetInstance();
        public bool LogIn(int numCarte, int pin)
        {
            try
            {
                string sql = "SELECT COUNT(*)  FROM Account WHERE CardNumber = @CardNumber AND Pin = @Pin and BlockedState = 0";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CardNumber", numCarte);
                command.Parameters.Add("@Pin", SqlDbType.Int).Value = pin;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(attemptCount == 6)
                {
                    try
                    {
                        blockCard(numCarte);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("card not found and can't be blocked stop entring wrong data" + numCarte, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("Card " + numCarte, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (dt.Rows[0][0].ToString() == "1")
                {
                    var userid = getUserId(numCarte, pin);
                    getUserDetails(userid);
                    globalBalance = getGlobalBalence();
                    return true;
                }
                else if (numCarte.ToString() == string.Empty || string.IsNullOrEmpty(pin.ToString()))
                {
                    MessageBox.Show("un des champs est vide ! ", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("somthing wrong please try again later", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    attemptCount++;
                    return false;
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the login process
                MessageBox.Show("An error occurred during login: " + ex.Message);
                return false;
            }
        }

        private bool blockCard(int cardNumber)
        {
            var success = true;
            try
            {
                string sql2 = "update account set  BlockedState = 1 where CardNumber = @amount ";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);


                cmd2.Parameters.Add("@amount", SqlDbType.Int).Value = cardNumber;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                int rows = cmd2.ExecuteNonQuery();
                if (rows < 0)
                {
                    success = false;

                }

            }
            catch (Exception)
            {
                throw;
            }
            return success;

        }
        private int getUserId(int numCarte, int pin)
        {
            DataTable dt = new DataTable();
            var userId = 0;
            try
            {

                string sql = "SELECT UserId, AccountBalance, fucntion, CardNumber FROM Account WHERE CardNumber = @CardNumber AND Pin = @Pin";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CardNumber", numCarte);
                cmd.Parameters.Add("@Pin", SqlDbType.Int).Value = pin;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    balance = Convert.ToDecimal(dt.Rows[0]["AccountBalance"]);
                    cardNumber = Convert.ToInt32(dt.Rows[0]["CardNumber"]);
                    fn = (string)dt.Rows[0]["fucntion"];
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return userId;
        }

        public int getGlobalBalence()
        {
            DataTable dt = new DataTable();
            var userId = 0;
            try
            {

                string sql = "SELECT [globalAmount] from detailsDAB";

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userId = Convert.ToInt32(dt.Rows[0]["globalAmount"]);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return userId;
        }

        private void getUserDetails(int id)
        {
            DataTable dt = new DataTable();
            //var userId = 0;
            try
            {

                string sql = "SELECT [CIN] ,[FirstName] ,[LastName] FROM [dbo].[UserInfo] where Cin = @id";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userName = dt.Rows[0]["FirstName"].ToString();
                    lastName = dt.Rows[0]["LastName"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        public bool setValueAfterWithdrawl(int cardNumber, decimal valueTowithdraw)
        {

            var success = true;
            if (valueTowithdraw <= 0 || valueTowithdraw > globalBalance || globalBalance == LOW)
            {
                MessageBox.Show("can't withdraw " + valueTowithdraw, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (balance < valueTowithdraw)
            {
                return false;
            }
            balance -= valueTowithdraw;
            //var userId = 0;
            try
            {
                string sql2 = "update Account set AccountBalance = @value  where CardNumber = @CardNumber";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);

                cmd2.Parameters.AddWithValue("@CardNumber", cardNumber);
                cmd2.Parameters.Add("@value", SqlDbType.Money).Value = balance;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                int rows = cmd2.ExecuteNonQuery();
                if (rows < 0)
                {
                    success = false;
                    globalBalance += valueTowithdraw;

                }
                else
                {
                    globalBalance -= valueTowithdraw;
                    setGlobalAmountAfterWithdrawl(valueTowithdraw);
                    balance = balance - valueTowithdraw;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return success;

        }

        public bool setValueForcheque(int numCheque, decimal montant, string bank)
        {

            var success = true;

            //var userId = 0;
            try
            {
                string sql2 = "EXEC InsertData @numero = @num, @banque = @bank, @montant = @value;";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);

                cmd2.Parameters.Add("@value", SqlDbType.Money).Value = montant;
                cmd2.Parameters.Add("@num", SqlDbType.Int).Value = numCheque;
                cmd2.Parameters.Add("@bank", SqlDbType.VarChar).Value = bank;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                int rows = cmd2.ExecuteNonQuery();
                if (rows < 0)
                {
                    success = false;


                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return success;

        }

        private bool setGlobalAmountAfterWithdrawl(decimal valueTowithdraw)
        {

            var success = true;

            globalBalance -= valueTowithdraw;
            //var userId = 0;
            try
            {
                string sql2 = "update detailsDAB set globalAmount = @value";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);

                cmd2.Parameters.Add("@value", SqlDbType.Money).Value = globalBalance;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                int rows = cmd2.ExecuteNonQuery();
                if (rows < 0)
                {
                    success = false;
                }
                else
                {
                    balance += valueTowithdraw;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return success;

        }

        public bool setGlobalAmount(decimal amount)
        {
            var success = true;
            try
            {
                string sql2 = "update detailsDAB set globalAmount =  globalAmount + @amount ";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);


                cmd2.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                int rows = cmd2.ExecuteNonQuery();
                if (rows < 0)
                {
                    success = false;

                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return success;
        }

        public DataTable getBlockedAccounts()
        {
            var dt = new DataTable();
            try
            {
                
                string sql2 = "select CardNumber , userId from Account where BlockedState = 1 ";

                SqlCommand cmd2 = new SqlCommand(sql2, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            return dt;
        }
    }
}
