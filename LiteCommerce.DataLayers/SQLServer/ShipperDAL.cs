using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;
using System.Data.SqlClient;

namespace LiteCommerce.DataLayers.SQLServer
{
    public class ShipperDAL : _BaseDAL, IShipperDAL
    {
        public ShipperDAL(string connectionString) : base(connectionString)
        {

        }

        public int Add(Shipper data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int ShipperID)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int ShipperID)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
            {
                searchValue = "%" + searchValue + "%";
            }
            List<Shipper> data = new List<Shipper>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select ShipperID, ShipperName, Phone
                                    from
                                    (
	                                    select *, ROW_NUMBER() OVER(Order by ShipperName) As RowNumber
	                                    from Shippers
	                                    where (@searchValue= '')
		                                    or(
			                                    ShipperID Like @searchValue
			                                    or ShipperName like @searchValue
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
                        Shipper shipper = new Shipper();
                        shipper.ShipperID = Convert.ToInt32(dbReader["ShipperID"]);
                        shipper.ShipperName = Convert.ToString(dbReader["ShipperName"]);
                        shipper.Phone = Convert.ToString(dbReader["Phone"]);
                        data.Add(shipper);
                    }
                }
                cn.Close();
            }

            return data;
        }

        public bool Update(Shipper data)
        {
            throw new NotImplementedException();
        }
    }    
}
