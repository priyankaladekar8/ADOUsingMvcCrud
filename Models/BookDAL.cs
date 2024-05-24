using System.Data.SqlClient;

namespace ADOCRUDMVCBook.Models
{
    public class BookDAL
    {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            private readonly IConfiguration configuration;
            public BookDAL(IConfiguration configuration)
            {
                this.configuration = configuration;
                string connstr = this.configuration.GetConnectionString("DefaultConnection");
                con = new SqlConnection(connstr);
            }
            // list
            public List<Book> GetBooks()
            {
                List<Book> booklist = new List<Book>();
                string qry = "select * from book";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Book book = new Book();
                        book.Id = Convert.ToInt32(dr["id"]);
                        book.Title = dr["Title"].ToString();
                        book.Price = Convert.ToDouble(dr["price"]);
                       book.Author = dr["Author"].ToString();
                        booklist.Add(book);
                    }
                }
                con.Close();
                return booklist;
            }
            // add
            public int AddBook(Book bk)
            {
                int result = 0;
                string qry = "insert into Book values(@Title,@Price,@Author)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Title", bk.Title);
                cmd.Parameters.AddWithValue("@Price",bk.Price);
                cmd.Parameters.AddWithValue("@Author", bk.Author);

            con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            //edit
            public int EditBook(Book bk )
            {
                int result = 0;
                string qry = "update Book set title=@Title,price=@Price, Author=@Author where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Title", bk.Title);
                cmd.Parameters.AddWithValue("@price", bk.Price);
                cmd.Parameters.AddWithValue("@Author", bk.Author);
                cmd.Parameters.AddWithValue("@id", bk.Id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            //select single emp
            public Book GetBookById(int id)
            {
                Book book = new Book();
                string qry = "select * from book where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        book.Id = Convert.ToInt32(dr["id"]);
                       book.Title = dr["Title"].ToString();
                        book.Price = Convert.ToDouble(dr["price"]);
                       book.Author = dr["Author"].ToString();
                }
                }
                con.Close();
                return book;
            }

            // delete
            public int DeleteBook(int id)
            {
                int result = 0;
                string qry = "delete from book where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

        }
    }
