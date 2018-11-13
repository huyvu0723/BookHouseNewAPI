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
    public class CategoryController : ApiController
    {

        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        Category cat;
        [HttpGet]
        [Route("api/Category/GetAllCat")]
        public IHttpActionResult GetAllCat()
        {
            try
            {
                conn.Open();
                string query = "Select catId, catName, catParent from Category";
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Category> lstCat = new List<Category>();
                while (reader.Read())
                {
                    cat = new Category();
                    if (!reader.IsDBNull(0))
                    {
                        cat.catId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        cat.catName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        cat.catParent = reader.GetInt32(2);
                    }
                    lstCat.Add(cat);
                }
                return Ok(lstCat);
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
