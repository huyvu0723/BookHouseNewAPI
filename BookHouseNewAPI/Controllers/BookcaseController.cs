using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookHouseNewAPI.Models;

namespace BookHouseNewAPI.Controllers
{
    public class BookcaseController : ApiController
    {
        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        Bookcase bookcase;

        private void closeConnect()
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

        [HttpPost]
        [Route("api/Bookcase/postBookcase/{accId}/{bookId}")]
        public IHttpActionResult AddUser(int accId, int bookId)
        {
            try
            {
                conn.Open();
                string query = "insert into BookCase(accId, bookId) values( " + accId + "," + bookId +  ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                closeConnect();
            }
            return Ok(true);
        }

        [HttpGet]
        [Route("api/Bookcase/getBookCaseByUserId/{id}")]
        public IHttpActionResult GetBookCaseByUserId(string id)
        {
            try
            {
                conn.Open();
                id = "'" + id + "'";
                String url = "select b.bookId as bookId, b.bookName as bookName, b.bookImage as bookImage," +
                    " b.bookLink as bookLink, au.autName as autName," +
                    " bc.BookMark as bookMard, bc.Rate as rate,  b.bookDescription as bookDescription " +
                    "from BookCase bc, Book b, Account a, Author au " +
                    "where bc.accId = a.accId and bc.bookId = b.bookId and b.AuthorautId = au.autId " +
                    "and a.accId = " + id + " order by  b.bookName";
                SqlCommand cmd = new SqlCommand(url, conn);
                reader = cmd.ExecuteReader();
                List<Bookcase> lst = new List<Bookcase>();
                while (reader.Read())
                {
                    bookcase = new Bookcase();
                    bookcase.bookId = reader.GetInt32(0);
                    bookcase.name = reader.GetString(1);
                    if(!reader.IsDBNull(2))
                    {
                        bookcase.bookImage = reader.GetString(2);
                    }
                    
                    bookcase.bookLink = reader.GetString(3);
                    bookcase.autName = reader.GetString(4);
                    bookcase.bookMark = reader.GetInt32(5);
                    if (!reader.IsDBNull(6))
                    {
                        bookcase.rate = (double)reader.GetInt32(6);
                    }                        
                    if(!reader.IsDBNull(7))
                    {
                        bookcase.bookDescription = reader.GetString(7);
                    }
                    lst.Add(bookcase);



                    
                }
                return Ok(lst);
            }
            catch (Exception e)
            {
                
                return NotFound();
            }
            finally
            {
                closeConnect();
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/Bookcase/checkBookcase/{accId}/{bookId}")]
        public IHttpActionResult CheckBookcase(int accId, int bookId)
        {
            try
            {
                conn.Open();
                string query = "select accId from Bookcase where accId = " + accId + " and bookId = " + bookId;
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Ok(true);
                }
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                closeConnect();
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("api/Bookcase/deleteBookInBookcase/{accId}/{bookId}")]
        public IHttpActionResult deleteBookInBookcase(int accId, int bookId)
        {
            try
            {
                conn.Open();
                string query = "Delete bookcase where accId = " + accId + " and bookId = " + bookId;
                SqlCommand cmd = new SqlCommand(query, conn);
                
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return Ok(true);
                }
                
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                closeConnect();
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("api/Bookcase/getBookcaseRate/{id}")]
        public IHttpActionResult getBookcaseRate(string id)
        {
            try
            {
                conn.Open();
                id = "'" + id + "'";
                String url = "select AVG(Rate) as rate, count(bookId) as countNum from BookCase where bookId = " + id;
                SqlCommand cmd = new SqlCommand(url, conn);
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    bookcase = new Bookcase();
                    if(!reader.IsDBNull(0)) {
                        bookcase.rate = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        bookcase.countDownload = reader.GetInt32(1);
                    }
                    return Ok(bookcase);
                }
                
            }
            catch (Exception e)
            {

                return NotFound();
            }
            finally
            {
                closeConnect();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/Bookcase/UpdateBookMar/{mark}/{accId}/{bookId}")]
        public IHttpActionResult UpdateBookMar(int mark, int accId, int bookId)
        {
            try
            {
                conn.Open();
                string query = "update BookCase set BookMark = " + mark + " where accId = " + accId + " and bookId = " + bookId;
                SqlCommand cmd = new SqlCommand(query, conn);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return Ok(true);
                }
            }
            catch (Exception e)
            {
                return Ok(false);
            }
            finally
            {
                closeConnect();
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("api/Bookcase/GetMark/{accId}/{bookId}")]
        public IHttpActionResult GetMark(int accId, int bookId)
        {
            try
            {
                conn.Open();
                
                String url = "select BookMark from BookCase where accId = " + accId + " and bookId = " + bookId;
                SqlCommand cmd = new SqlCommand(url, conn);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bookcase = new Bookcase();
                    if (!reader.IsDBNull(0))
                    {
                        bookcase.bookMark = reader.GetInt32(0);
                    }
                   
                    return Ok(bookcase);
                }
            }
            catch (Exception e)
            {

                return NotFound();
            }
            finally
            {
                closeConnect();
            }
            return NotFound();
        }


    }
}