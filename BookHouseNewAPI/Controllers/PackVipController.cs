using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using BookHouseNewAPI.Models;

namespace BookHouseNewAPI.Controllers
{
    public class PackVipController : ApiController
    {

        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        PackVip packVip;

        //TinLM
        [HttpGet]
        [Route("api/PackVip/GetPackVip")]
        public IHttpActionResult GetPackVip()
        {
            List<PackVip> rs = new List<PackVip>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from PackVip", conn);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    packVip = new PackVip();
                    packVip.pvId = reader.GetInt32(0);
                    packVip.bookDate = reader.GetInt32(1);
                    packVip.pvCost = (double) reader.GetDecimal(2);

                    rs.Add(packVip);
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
            return Ok(rs);
        }
    }
}