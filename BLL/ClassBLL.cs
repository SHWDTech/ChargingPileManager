using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public partial class ClassBLL
    {
        private readonly ClassDAL dal = new ClassDAL();

        public ClassBLL()
        { }

        public DataSet getDataSet(string sql)
        {
            return dal.getDataSet(sql);
        }
        public int Execute(string sql)
        {
            return dal.Execute(sql);
        }
        public DataTable RunProcedurezw(string storedProcName, IDataParameter[] parameters)
        {
            return dal.RunProcedurezw(storedProcName, parameters);
        }
    }
}
