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
    public class AuthorController : ApiController
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        Author aut;
        [HttpGet]
        [Route("api/Author/GetAllAuthor")]
        public IHttpActionResult GetAllAuthor()
        {
            try
            {
                conn.Open();
                string query = "Select * from Author";
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Author> lstAut = new List<Author>();
                while (reader.Read())
                {
                    aut = new Author();
                    if (!reader.IsDBNull(0))
                    {
                        aut.autId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        aut.autName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        aut.autAvatar = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        aut.autBirth = reader.GetDateTime(3);
                    }
                    lstAut.Add(aut);
                }
                return Ok(lstAut);
            }
            catch (Exception e)
            {
                return Ok(e);
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
            return Ok(false);
        }
    }
}
