using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;
using System.Data.SqlClient;

namespace LiteCommerce.DataLayers.SQLServer
{
    public class CustomerDAL : _BaseDAL, ICustomerDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerDAL(string connectionString) : base(connectionString)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Customer data)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public bool Delete(int CustomerID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public Customer Get(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
            {
                searchValue = "%" + searchValue + "%";
            }
            List<Customer> data = new List<Customer>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from
                                    (
	                                    select *, ROW_NUMBER() OVER(Order by CustomerName) As RowNumber
	                                    from Customers
	                                    where (@searchValue= '')
		                                    or(
			                                    CustomerID Like @searchValue
			                                    or ContactName like @searchValue
			                                    or Address like @searchValue
			                                    or Email like @searchValue
			                                    )
                                    ) as s 
                                    where s.RowNumber between (@page -1)*@pageSize + 1 and @page*@pageSize";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                using (SqlDataReader dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = Convert.ToInt32(dbReader["CustomerID"]);
                        customer.CustomerName = Convert.ToString(dbReader["CustomerName"]);
                        customer.ContactName = Convert.ToString(dbReader["ContactName"]);
                        customer.Address = Convert.ToString(dbReader["Address"]);
                        customer.City = Convert.ToString(dbReader["City"]);
                        customer.PostalCode = Convert.ToString(dbReader["PostalCode"]);
                        customer.Country = Convert.ToString(dbReader["Country"]);
                        customer.Email = Convert.ToString(dbReader["Email"]);
                        customer.Password = Convert.ToString(dbReader["Password"]);
                        data.Add(customer);
                    }
                }
                cn.Close();
            }

            return data;
        }

        public bool Update(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
