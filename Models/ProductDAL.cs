using System.Data.SqlClient;

namespace ADOCrudMVCProduct.Models
{
    public class ProductDAL
    {
      
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            private readonly IConfiguration configuration;
            public ProductDAL(IConfiguration configuration)
            {
                this.configuration = configuration;
                string connstr = this.configuration.GetConnectionString("DefaultConnection");
                con = new SqlConnection(connstr);
            }
            // list
            public List<Product> GetProducts()
            {
                List<Product> productlist = new List<Product>();
                string qry = "select * from product";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Product product = new Product();
                        product.Id = Convert.ToInt32(dr["id"]);
                        product.Name = dr["name"].ToString();
                        product.Price = Convert.ToDouble(dr["price"]);
                        productlist.Add(product);
                    }
                }
                con.Close();
                return productlist;
            }
            // add
            public int AddProduct(Product pro)
            {
                int result = 0;
                string qry = "insert into product values(@Name,@Price)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Name", pro.Name);
                cmd.Parameters.AddWithValue("@price", pro.Price);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            //edit
            public int EditProduct(Product pro)
            {
                int result = 0;
                string qry = "update product set name=@Name,price=@Price where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@price", pro.Price);
                cmd.Parameters.AddWithValue("@id", pro.Id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            //select single emp
            public Product GetProductById(int id)
            {
                Product product = new Product();
                string qry = "select * from product where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        product.Id = Convert.ToInt32(dr["id"]);
                        product.Name = dr["name"].ToString();
                        product.Price = Convert.ToDouble(dr["price"]);
                    }
                }
                con.Close();
                return product;
            }

            // delete
            public int DeleteProduct(int id)
            {
                int result = 0;
                string qry = "delete from product where id=@Id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

        }
    }
