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
    public class BookController : ApiController
    {

        SqlConnection conn = new SqlConnection(Constants.CONNECTION_BOOKHOUSE);
        SqlDataReader reader;
        Book book;
        [HttpGet]
        [Route("api/Book/GetBookByDate")]
        public IHttpActionResult GetBookByDate()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select bookId, bookName, autName, datePublish, bookImage, bookLink, bookDescription, isVip from Book, Author where Book.AuthorautId = Author.autId order by datePublish desc", conn);
                reader = cmd.ExecuteReader();
                List<Book> lstBook = new List<Book>();
                while (reader.Read())
                {
                    book = new Book();
                    if(!reader.IsDBNull(0))
                    {
                        book.bookId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        book.bookName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        book.autName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        book.datePublish = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        book.bookImage = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        book.bookLink = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        book.bookDescription = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        //book.isVip = reader.GetBoolean(7);
                        if (reader.GetBoolean(7))
                        {
                            book.isVip = 1;
                        }
                        else
                        {
                            book.isVip = 0;
                        }
                    }
                    lstBook.Add(book);
                }
                return Ok(lstBook);
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


        [HttpGet]
        [Route("api/Book/GetBooksByAuthor/{autId}")]
        public IHttpActionResult GetBooksByAuthor(int autId)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select bookId, bookName, autName, datePublish, bookImage, bookLink, bookDescription, isVip  from Book, Author where Book.AuthorautId = Author.autId and Book.AuthorautId = "+autId+" order by datePublish desc", conn);
                reader = cmd.ExecuteReader();
                List<Book> lstBook = new List<Book>();
                while (reader.Read())
                {
                    book = new Book();
                    if (!reader.IsDBNull(0))
                    {
                        book.bookId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        book.bookName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        book.autName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        book.datePublish = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        book.bookImage = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        book.bookLink = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        book.bookDescription = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        //book.isVip = reader.GetBoolean(7);
                        if (reader.GetBoolean(7))
                        {
                            book.isVip = 1;
                        }
                        else
                        {
                            book.isVip = 0;
                        }
                    }
                    lstBook.Add(book);
                }
                return Ok(lstBook);
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


        [HttpGet]
        [Route("api/Book/GetBookByCat/{catId}")]
        public IHttpActionResult GetBookByCat(int catId)
        {
            try
            {
                conn.Open();
                string query = "select Book.bookId, bookName, autName, datePublish,bookImage, bookLink, bookDescription, Book.isVip  from Book, Author, Category_Book, Category  "
                    + "where Book.AuthorautId = Author.autId and Book.bookId = Category_Book.bookId and Category.catId = Category_Book.catId and (Category.catId = "+catId+" or catParent = "+catId+") "
                    + "group by Book.bookId, bookName, autName, datePublish,bookImage, bookLink, bookDescription, Book.isVip";
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Book> lstBook = new List<Book>();
                while (reader.Read())
                {
                    book = new Book();
                    if (!reader.IsDBNull(0))
                    {
                        book.bookId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        book.bookName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        book.autName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        book.datePublish = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        book.bookImage = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        book.bookLink = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        book.bookDescription = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        //book.isVip = reader.GetBoolean(7);
                        if (reader.GetBoolean(7))
                        {
                            book.isVip = 1;
                        }
                        else
                        {
                            book.isVip = 0;
                        }
                    }
                    lstBook.Add(book);
                }
                return Ok(lstBook);
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

        [HttpGet]
        [Route("api/Book/SearchBook/{keyWord}")]
        public IHttpActionResult SearchBook(string keyWord)
        {
            try
            {
                conn.Open();
                keyWord = "'%"+keyWord+"%'";
                string query = "select bookId, bookName, autName, datePublish, bookImage, bookLink, bookDescription, isVip from Book, Author where Book.AuthorautId = Author.autId and(bookname like "+keyWord+" or autName like "+keyWord+") order by datePublish desc";
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Book> lstBook = new List<Book>();
                while (reader.Read())
                {
                    book = new Book();
                    if (!reader.IsDBNull(0))
                    {
                        book.bookId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        book.bookName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        book.autName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        book.datePublish = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        book.bookImage = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        book.bookLink = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        book.bookDescription = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        //book.isVip = reader.GetBoolean(7);
                        if (reader.GetBoolean(7))
                        {
                            book.isVip = 1;
                        }
                        else
                        {
                            book.isVip = 0;
                        }
                    }
                    lstBook.Add(book);
                }
                return Ok(lstBook);
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



        [HttpGet]
        [Route("api/Book/SearchBookByID/{bokId}")]
        public IHttpActionResult SearchBookByID(int bokId)
        {
            try
            {
                conn.Open();
                string query = "select bookId, bookName, autName, datePublish, bookDescription, bookImage, bookLink , isVip from Book, Author where Book.AuthorautId = Author.autId and bookID = " + bokId;
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                List<Book> lstBook = new List<Book>();
                while (reader.Read())
                {
                    book = new Book();
                    if (!reader.IsDBNull(0))
                    {
                        book.bookId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        book.bookName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        book.autName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        book.datePublish = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        book.bookImage = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        book.bookLink = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        book.bookDescription = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        //book.isVip = reader.GetBoolean(7);
                        if (reader.GetBoolean(7))
                        {
                            book.isVip = 1;
                        }
                        else
                        {
                            book.isVip = 0;
                        }
                    }
                    lstBook.Add(book);
                }
                return Ok(lstBook);
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
