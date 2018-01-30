
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
	 	//v_hd_sq
		public partial class v_hd_sq
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_hd_sq");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.v_hd_sq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_hd_sq(");			
            strSql.Append("id,goodsId,hdId,money,zt,pudate,title,usesrId,xjMoney");
			strSql.Append(") values (");
            strSql.Append("@id,@goodsId,@hdId,@money,@zt,@pudate,@title,@usesrId,@xjMoney");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@goodsId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@hdId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@usesrId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xjMoney", SqlDbType.Money,8)             
              
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.goodsId;                        
            parameters[2].Value = model.hdId;                        
            parameters[3].Value = model.money;                        
            parameters[4].Value = model.zt;                        
            parameters[5].Value = model.pudate;                        
            parameters[6].Value = model.title;                        
            parameters[7].Value = model.usesrId;                        
            parameters[8].Value = model.xjMoney;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.v_hd_sq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_hd_sq set ");
			                        
            strSql.Append(" id = @id , ");                                    
            strSql.Append(" goodsId = @goodsId , ");                                    
            strSql.Append(" hdId = @hdId , ");                                    
            strSql.Append(" money = @money , ");                                    
            strSql.Append(" zt = @zt , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" usesrId = @usesrId , ");                                    
            strSql.Append(" xjMoney = @xjMoney  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@goodsId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@hdId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@usesrId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xjMoney", SqlDbType.Money,8)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.goodsId;                        
            parameters[2].Value = model.hdId;                        
            parameters[3].Value = model.money;                        
            parameters[4].Value = model.zt;                        
            parameters[5].Value = model.pudate;                        
            parameters[6].Value = model.title;                        
            parameters[7].Value = model.usesrId;                        
            parameters[8].Value = model.xjMoney;                        
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
		public bool Delete()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from v_hd_sq ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};


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
		public System.Model.v_hd_sq GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, goodsId, hdId, money, zt, pudate, title, usesrId, xjMoney  ");			
			strSql.Append("  from v_hd_sq ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			System.Model.v_hd_sq model=new System.Model.v_hd_sq();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.goodsId= ds.Tables[0].Rows[0]["goodsId"].ToString();
																																model.hdId= ds.Tables[0].Rows[0]["hdId"].ToString();
																																model.money= ds.Tables[0].Rows[0]["money"].ToString();
																																model.zt= ds.Tables[0].Rows[0]["zt"].ToString();
																																model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.title= ds.Tables[0].Rows[0]["title"].ToString();
																																model.usesrId= ds.Tables[0].Rows[0]["usesrId"].ToString();
																												if(ds.Tables[0].Rows[0]["xjMoney"].ToString()!="")
				{
					model.xjMoney=decimal.Parse(ds.Tables[0].Rows[0]["xjMoney"].ToString());
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
			strSql.Append(" FROM v_hd_sq ");
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
            strSql.Append(" FROM v_hd_sq T");
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
			strSql.Append(" FROM v_hd_sq ");
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
			strSql.Append(" FROM v_hd_sq T");
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
			strSql.Append("select count(1) FROM v_hd_sq T");
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
			strSql.Append(")AS Row, T.*  from v_hd_sq T ");
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
            strSql.Append(" from v_hd_sq T ");
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
            strSql.Append(" from v_hd_sq T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

