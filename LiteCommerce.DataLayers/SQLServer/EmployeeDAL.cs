using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    /// <summary>
    /// Cài đặt các tính năng xử lý dữ liệu nhân viên trong CSDL SQL Server
    /// </summary>
    public class EmployeeDAL : _BaseDAL, IEmployeeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeDAL(string connectionString) : base(connectionString)
        {

        }
        public int Add(Employee data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public List<Employee> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
            {
                searchValue = "%" + searchValue + "%";
            }
            List<Employee> data = new List<Employee>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from
                                    (
	                                    select *, ROW_NUMBER() OVER(Order by FirstName) As RowNumber
	                                    from Employees
	                                    where (@searchValue= '')
		                                    or(
			                                    EmployeeID Like @searchValue
			                                    or FirstName like @searchValue
			                                    or LastName like @searchValue
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
                        Employee employee = new Employee();
                        employee.EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]);
                        employee.LastName = Convert.ToString(dbReader["LastName"]);
                        employee.FirstName = Convert.ToString(dbReader["FirstName"]);
                        employee.BirthDate = Convert.ToDateTime(dbReader["BirthDate"]);
                        employee.Photo = Convert.ToString(dbReader["Photo"]);
                        employee.Notes = Convert.ToString(dbReader["Notes"]);
                        employee.Email = Convert.ToString(dbReader["Email"]);
                        employee.Password = Convert.ToString(dbReader["Password"]);
                        data.Add(employee);
                    }
                }
                cn.Close();
            }

            return data;
        }

        public bool Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}
