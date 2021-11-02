using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HWDAL
    {
        //Reference Variable : Class Level : Member Variables
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        SqlDataReader sqlDataReaderObj;
        public HWDAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }
        public List<ProductDTO> FetchAllDepartments()
        {
            try
            {
                //Setting up the connectionstring to the connection object
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["AdventureWorks"].ConnectionString;
                //SEtting up the command text for the command object
                sqlCmdObj.CommandText = @"select Name from Production.Product where ListPrice > 10";
                sqlCmdObj.Connection = sqlConObj;

                //Execute
                sqlConObj.Open();//COnnection should be open not command
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<ProductDTO> lstDept = new List<ProductDTO>();

                ProductDTO newepartObj = new ProductDTO();

                while (sqlDataReaderObj.Read())
                {
                    //newepartObj.DeptName = sqlDataReaderObj[0].ToString();
                    //newepartObj.DeptGroupName = sqlDataReaderObj[1].ToString();
                    //lstDept.Add(newepartObj);

                    lstDept.Add(new ProductDTO()
                    {
                        ProductName = sqlDataReaderObj[0].ToString(),
                        
                    });

                }
                return lstDept;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }



    }
}
