using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.DBUtility;




namespace System.DAL
{
    public class publicDAL
    {
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="strSql">执行sql语句</param>
        /// <returns></returns>
        public int RunSqlW(string strSql)
        {
            return DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 执行Sql查询语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet RunSql(string strSql)
        {
            return DbHelperSQL.Query(strSql);
        }


        /// <summary>
        /// 获取sql语句记录总数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int GetRecordCount(string sql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM ({0}) AS tabinfo", sql);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public bool DeleteListByIds(string exchangeid)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@" DELETE FROM shop WHERE Id IN (" + exchangeid + ")");
                int n = DbHelperSQL.ExecuteSql(strSql.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }


        #region 执行SQL查询语句 得到最大值
        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="TableName">表名</param>
        /// <returns> 返回字段最大值(仅针对int类型字段)</returns>
        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        #endregion

    }
}
