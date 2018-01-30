﻿
// 
//                                  _oo8oo_
//                                 o8888888o
//                                 88" . "88
//                                 (| -_- |)
//                                 0\  =  /0
//                               ___/'==='\___
//                             .' \\|     |// '.
//                            / \\|||  :  |||// \
//                           / _||||| -:- |||||_ \
//                          |   | \\\  -  /// |   |
//                          | \_|  ''\---/''  |_/ |
//                          \  .-\__  '-'  __/-.  /
//                        ___'. .'  /--.--\  '. .'___
//                     ."" '<  '.___\_<|>_/___.'  >' "".
//                    | | :  `- \`.:`\ _ /`:.`/ -`  : | |
//                    \  \ `-.   \_ __\ /__ _/   .-` /  /
//                =====`-.____`.___ \_____/ ___.`____.-`=====
//                                  `=---=`
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//           佛祖保佑      永不宕机       永无BUG        永不修改  
//                                    *
//                                    *
//                                    *
//                                初始化成功
//                                    *
//                                    *
//                                    *
//                             佛祖保佑属性激活
//                                    *
//                                    *
//                                    *
//

using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace System.DAL
{
    //facility
    public partial class facility
    {


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "facility");
        }

        /// <summary>
        /// 判断是否存在该条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from facility");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(System.Model.facility model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into facility(");
            strSql.Append("fid,types,no,statuses,pudate,isdel,identitycode");
            strSql.Append(") values (");
            strSql.Append("@fid,@types,@no,@statuses,@pudate,@isdel,@identitycode");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@fid", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@isdel", SqlDbType.Int,4) ,            
                        new SqlParameter("@identitycode", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.fid;
            parameters[1].Value = model.types;
            parameters[2].Value = model.no;
            parameters[3].Value = model.statuses;
            parameters[4].Value = model.pudate;
            parameters[5].Value = model.isdel;
            parameters[6].Value = model.identitycode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(System.Model.facility model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update facility set ");

            strSql.Append(" fid = @fid , ");
            strSql.Append(" types = @types , ");
            strSql.Append(" no = @no , ");
            strSql.Append(" statuses = @statuses , ");
            strSql.Append(" pudate = @pudate , ");
            strSql.Append(" isdel = @isdel , ");
            strSql.Append(" identitycode = @identitycode  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@fid", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@isdel", SqlDbType.Int,4) ,            
                        new SqlParameter("@identitycode", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.fid;
            parameters[2].Value = model.types;
            parameters[3].Value = model.no;
            parameters[4].Value = model.statuses;
            parameters[5].Value = model.pudate;
            parameters[6].Value = model.isdel;
            parameters[7].Value = model.identitycode;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from facility ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from facility ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public System.Model.facility GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, fid, types, no, statuses, pudate, isdel, identitycode  ");
            strSql.Append("  from facility ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            System.Model.facility model = new System.Model.facility();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fid"].ToString() != "")
                {
                    model.fid = int.Parse(ds.Tables[0].Rows[0]["fid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["types"].ToString() != "")
                {
                    model.types = int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
                }
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                if (ds.Tables[0].Rows[0]["statuses"].ToString() != "")
                {
                    model.statuses = int.Parse(ds.Tables[0].Rows[0]["statuses"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pudate"].ToString() != "")
                {
                    model.pudate = DateTime.Parse(ds.Tables[0].Rows[0]["pudate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isdel"].ToString() != "")
                {
                    model.isdel = int.Parse(ds.Tables[0].Rows[0]["isdel"].ToString());
                }
                model.identitycode = ds.Tables[0].Rows[0]["identitycode"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM facility ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM facility T");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM facility ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }




        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM facility T");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM facility T");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from facility T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 分页获取数据列表,联表查询
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string unionTables, string unionColumns, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  ");
            strSql.Append(unionColumns);
            strSql.Append(" from facility T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 不分页获取数据列表,联表查询
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, string unionTables, string unionColumns, params SqlParameter[] parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  ");
            strSql.Append(unionColumns);
            strSql.Append(" from facility T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


    }
}

