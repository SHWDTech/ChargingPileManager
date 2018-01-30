
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
	 	//t_coupon
		public partial class t_coupon
	{
   		     
		public bool Exists(string yhjId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_coupon");
			strSql.Append(" where ");
			                                       strSql.Append(" yhjId = @yhjId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@yhjId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = yhjId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.t_coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_coupon(");			
            strSql.Append("yhjId,money,man,usersId,date1,date2,num,pudate,title");
			strSql.Append(") values (");
            strSql.Append("@yhjId,@money,@man,@usersId,@date1,@date2,@num,@pudate,@title");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@yhjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.Int,4) ,            
                        new SqlParameter("@man", SqlDbType.Int,4) ,            
                        new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@date1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@date2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@num", SqlDbType.Int,4) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,100)             
              
            };
			            
            parameters[0].Value = model.yhjId;                        
            parameters[1].Value = model.money;                        
            parameters[2].Value = model.man;                        
            parameters[3].Value = model.usersId;                        
            parameters[4].Value = model.date1;                        
            parameters[5].Value = model.date2;                        
            parameters[6].Value = model.num;                        
            parameters[7].Value = model.pudate;                        
            parameters[8].Value = model.title;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.t_coupon model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_coupon set ");
			                        
            strSql.Append(" yhjId = @yhjId , ");                                    
            strSql.Append(" money = @money , ");                                    
            strSql.Append(" man = @man , ");                                    
            strSql.Append(" usersId = @usersId , ");                                    
            strSql.Append(" date1 = @date1 , ");                                    
            strSql.Append(" date2 = @date2 , ");                                    
            strSql.Append(" num = @num , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" title = @title  ");            			
			strSql.Append(" where yhjId=@yhjId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@yhjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.Int,4) ,            
                        new SqlParameter("@man", SqlDbType.Int,4) ,            
                        new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@date1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@date2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@num", SqlDbType.Int,4) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,100)             
              
            };
						            
            parameters[0].Value = model.yhjId;                        
            parameters[1].Value = model.money;                        
            parameters[2].Value = model.man;                        
            parameters[3].Value = model.usersId;                        
            parameters[4].Value = model.date1;                        
            parameters[5].Value = model.date2;                        
            parameters[6].Value = model.num;                        
            parameters[7].Value = model.pudate;                        
            parameters[8].Value = model.title;                        
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
		public bool Delete(string yhjId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_coupon ");
			strSql.Append(" where yhjId=@yhjId ");
						SqlParameter[] parameters = {
					new SqlParameter("@yhjId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = yhjId;


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
		/// 得到一个对象实体
		/// </summary>
		public System.Model.t_coupon GetModel(string yhjId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select yhjId, money, man, usersId, date1, date2, num, pudate, title  ");			
			strSql.Append("  from t_coupon ");
			strSql.Append(" where yhjId=@yhjId ");
						SqlParameter[] parameters = {
					new SqlParameter("@yhjId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = yhjId;

			
			System.Model.t_coupon model=new System.Model.t_coupon();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.yhjId= ds.Tables[0].Rows[0]["yhjId"].ToString();
																												if(ds.Tables[0].Rows[0]["money"].ToString()!="")
				{
					model.money=int.Parse(ds.Tables[0].Rows[0]["money"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["man"].ToString()!="")
				{
					model.man=int.Parse(ds.Tables[0].Rows[0]["man"].ToString());
				}
																																				model.usersId= ds.Tables[0].Rows[0]["usersId"].ToString();
																																model.date1= ds.Tables[0].Rows[0]["date1"].ToString();
																																model.date2= ds.Tables[0].Rows[0]["date2"].ToString();
																												if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
				}
																																				model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.title= ds.Tables[0].Rows[0]["title"].ToString();
																										
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
			strSql.Append(" FROM t_coupon ");
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
            strSql.Append(" FROM t_coupon T");
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
			strSql.Append(" FROM t_coupon ");
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
			strSql.Append(" FROM t_coupon T");
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
			strSql.Append("select count(1) FROM t_coupon T");
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
			strSql.Append(")AS Row, T.*  from t_coupon T ");
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
            strSql.Append(" from t_coupon T ");
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
            strSql.Append(" from t_coupon T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

