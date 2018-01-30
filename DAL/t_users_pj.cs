
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
	 	//t_users_pj
		public partial class t_users_pj
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_users_pj");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(System.Model.t_users_pj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_users_pj(");			
            strSql.Append("customId,usersId,xj,pudate,orderId,fwtd,wlsd,texts,evaluate");
			strSql.Append(") values (");
            strSql.Append("@customId,@usersId,@xj,@pudate,@orderId,@fwtd,@wlsd,@texts,@evaluate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xj", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@orderId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@fwtd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@wlsd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@texts", SqlDbType.Text) ,            
                        new SqlParameter("@evaluate", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.customId;                        
            parameters[1].Value = model.usersId;                        
            parameters[2].Value = model.xj;                        
            parameters[3].Value = model.pudate;                        
            parameters[4].Value = model.orderId;                        
            parameters[5].Value = model.fwtd;                        
            parameters[6].Value = model.wlsd;                        
            parameters[7].Value = model.texts;                        
            parameters[8].Value = model.evaluate;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(System.Model.t_users_pj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_users_pj set ");
			                                                
            strSql.Append(" customId = @customId , ");                                    
            strSql.Append(" usersId = @usersId , ");                                    
            strSql.Append(" xj = @xj , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" orderId = @orderId , ");                                    
            strSql.Append(" fwtd = @fwtd , ");                                    
            strSql.Append(" wlsd = @wlsd , ");                                    
            strSql.Append(" texts = @texts , ");                                    
            strSql.Append(" evaluate = @evaluate  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xj", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@orderId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@fwtd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@wlsd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@texts", SqlDbType.Text) ,            
                        new SqlParameter("@evaluate", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.customId;                        
            parameters[2].Value = model.usersId;                        
            parameters[3].Value = model.xj;                        
            parameters[4].Value = model.pudate;                        
            parameters[5].Value = model.orderId;                        
            parameters[6].Value = model.fwtd;                        
            parameters[7].Value = model.wlsd;                        
            parameters[8].Value = model.texts;                        
            parameters[9].Value = model.evaluate;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_users_pj ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_users_pj ");
			strSql.Append(" where ID in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public System.Model.t_users_pj GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, customId, usersId, xj, pudate, orderId, fwtd, wlsd, texts, evaluate  ");			
			strSql.Append("  from t_users_pj ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			System.Model.t_users_pj model=new System.Model.t_users_pj();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.customId= ds.Tables[0].Rows[0]["customId"].ToString();
																																model.usersId= ds.Tables[0].Rows[0]["usersId"].ToString();
																																model.xj= ds.Tables[0].Rows[0]["xj"].ToString();
																																model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.orderId= ds.Tables[0].Rows[0]["orderId"].ToString();
																																model.fwtd= ds.Tables[0].Rows[0]["fwtd"].ToString();
																																model.wlsd= ds.Tables[0].Rows[0]["wlsd"].ToString();
																																model.texts= ds.Tables[0].Rows[0]["texts"].ToString();
																												if(ds.Tables[0].Rows[0]["evaluate"].ToString()!="")
				{
					model.evaluate=int.Parse(ds.Tables[0].Rows[0]["evaluate"].ToString());
				}
																														
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM t_users_pj ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append(" FROM t_users_pj T");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM t_users_pj ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		
		
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder, params SqlParameter[] parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM t_users_pj T");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere, params SqlParameter[] parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_users_pj T");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from t_users_pj T ");
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
            strSql.Append(" from t_users_pj T ");
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
            strSql.Append(" from t_users_pj T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

