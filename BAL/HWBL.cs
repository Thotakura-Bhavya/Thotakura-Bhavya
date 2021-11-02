using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BAL
{
    public class HWBL
    {
        public List<ProductDTO> GetAllDepartments()
        {
            try
            {
                HWDAL dalObj = new HWDAL();
                List<ProductDTO> results = dalObj.FetchAllDepartments();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
