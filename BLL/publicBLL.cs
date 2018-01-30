using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DAL;
using System.Data;


namespace System.BLL
{
    public class publicBLL
    {
        publicDAL pdal = new publicDAL();

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="strSql">执行sql语句</param>
        /// <returns></returns>
        public int RunSqlW(string strSql)
        {
            return pdal.RunSqlW(strSql);
        }

        /// <summary>
        /// 执行Sql查询语句
        /// </summary>
        /// <param name="strSql">Sql查询语句</param>
        /// <returns></returns>
        public DataSet RunSql(string strSql)
        {
            return pdal.RunSql(strSql);
        }


       /// <summary>
        /// 执行Sql查询语句
        /// </summary>
        /// <param name="strSql">Sql查询语句</param>
        /// <returns></returns>
        public DataSet getDataSet(string strSql)
        {
            return pdal.RunSql(strSql);
        }
 



       
        /// <summary>
        /// 获取sql语句记录总数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int GetRecordCount(string sql)
        {
            return pdal.GetRecordCount(sql);
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="exid"></param>
        /// <returns></returns>
        public bool DeleteListByIds(string exid)
        {
            return pdal.DeleteListByIds(exid);
        }

        /// <summary>
        /// 查询最大id
        /// </summary>
        /// <param name="FieldName">字段</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public int GetMaxID(string FieldName, string TableName)
        {
            return pdal.GetMaxID(FieldName, TableName);
        }
    }
}
