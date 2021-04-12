using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến nhân viên
    /// </summary>
    public interface IEmployeeDAL
    {
        /// <summary>
        /// lấy danh sách toàn bộ nhân viên
        /// </summary>
        /// <returns></returns>
        List<Employee> List();
    }
}
