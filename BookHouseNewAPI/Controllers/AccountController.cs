using BookHouseNewAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookHouseNewAPI.Controllers
{
    public class AccountController : ApiController
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        Account acc;
        [HttpGet]
        [Route("api/Account/Login/{user}/{pass}")]
        public IHttpActionResult Login(string user, string pass)
        {
            try
            {
                conn.Open();
                user = "'" + user + "'";
                pass = "'" + pass + "'";
                SqlCommand cmd = new SqlCommand("select accUsername from Account where accUsername = " + user + " and accPassword = " + pass, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return Ok(true);
                }
            }
            catch(Exception e)
            {
                return NotFound();
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return Ok(false);
        }


        [HttpGet]
        [Route("api/Account/GetUser/{user}")]
        public IHttpActionResult GetUser(string user)
        {
            try
            {
                conn.Open();
                user = "'" + user + "'";
                SqlCommand cmd = new SqlCommand("select * from Account where accUsername = "+ user, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    acc = new Account();
                    acc.accId = reader.GetInt32(0);
                    acc.accUsername = reader.GetString(1);
                    acc.accPassword = reader.GetString(2);
                    acc.accFullname = reader.GetString(3);
                    acc.accWallet = reader.GetDecimal(4);
                    acc.accDateEndVip = reader.GetDateTime(5);
                    acc.accRole = reader.GetString(6);
                    return Ok(acc);
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return NotFound();
        }



        [HttpPost]
        [Route("api/Account/AddUser/{user}/{pass}/{name}")]
        public IHttpActionResult AddUser(string user, string pass, string name)
        {
            try
            {
                conn.Open();
                user = "'" + user + "'";
                pass = "'" + pass + "'";
                name = "'" + name + "'";
                string query = "insert into Account (accUsername, accPassword, accFullname) Values (" + user + "," + pass + "," + name + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return Ok(true);
        }

        [HttpPost]
        [Route("api/Account/chargeBalance/{accId}/{amount}")]
        public IHttpActionResult chargeBalance(int accId, double amount)
        {
            try
            {
                conn.Open();
                string query = "Update Account Set accWallet = accWallet + "+amount+ "where accId =" + accId;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                string currentTime = DateTime.Now.ToString();
                currentTime = "'" + currentTime + "'";
                query = "Insert into[Transaction](accId, tranType, tranAmount, tranDatePaid) VALUES("+accId+", 1, "+amount+", "+currentTime+")";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return Ok(true);
        }
    }
}
