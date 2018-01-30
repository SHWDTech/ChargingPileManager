
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
	 	//order_info
		public partial class order_info
	{
   		
   		
   		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "order_info");
        }
   		
   		/// <summary>
        /// 判断是否存在该条数据
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from order_info");
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
		public int Add(System.Model.order_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into order_info(");			
            strSql.Append("serialNumber,facility,port,price,discount,customid,pudate,statuses,duration,types,stippleid");
			strSql.Append(") values (");
            strSql.Append("@serialNumber,@facility,@port,@price,@discount,@customid,@pudate,@statuses,@duration,@types,@stippleid");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@facility", SqlDbType.Int,4) ,            
                        new SqlParameter("@port", SqlDbType.Int,4) ,            
                        new SqlParameter("@price", SqlDbType.Money,8) ,            
                        new SqlParameter("@discount", SqlDbType.Float,8) ,            
                        new SqlParameter("@customid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@duration", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@stippleid", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.serialNumber;                        
            parameters[1].Value = model.facility;                        
            parameters[2].Value = model.port;                        
            parameters[3].Value = model.price;                        
            parameters[4].Value = model.discount;                        
            parameters[5].Value = model.customid;                        
            parameters[6].Value = model.pudate;                        
            parameters[7].Value = model.statuses;                        
            parameters[8].Value = model.duration;                        
            parameters[9].Value = model.types;                        
            parameters[10].Value = model.stippleid;                        
			   
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
		public bool Update(System.Model.order_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update order_info set ");
			                                                
            strSql.Append(" serialNumber = @serialNumber , ");                                    
            strSql.Append(" facility = @facility , ");                                    
            strSql.Append(" port = @port , ");                                    
            strSql.Append(" price = @price , ");                                    
            strSql.Append(" discount = @discount , ");                                    
            strSql.Append(" customid = @customid , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" statuses = @statuses , ");                                    
            strSql.Append(" duration = @duration , ");                                    
            strSql.Append(" types = @types , ");                                    
            strSql.Append(" stippleid = @stippleid  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@facility", SqlDbType.Int,4) ,            
                        new SqlParameter("@port", SqlDbType.Int,4) ,            
                        new SqlParameter("@price", SqlDbType.Money,8) ,            
                        new SqlParameter("@discount", SqlDbType.Float,8) ,            
                        new SqlParameter("@customid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@duration", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@stippleid", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.serialNumber;                        
            parameters[2].Value = model.facility;                        
            parameters[3].Value = model.port;                        
            parameters[4].Value = model.price;                        
            parameters[5].Value = model.discount;                        
            parameters[6].Value = model.customid;                        
            parameters[7].Value = model.pudate;                        
            parameters[8].Value = model.statuses;                        
            parameters[9].Value = model.duration;                        
            parameters[10].Value = model.types;                        
            parameters[11].Value = model.stippleid;                        
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
			strSql.Append("delete from order_info ");
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
			strSql.Append("delete from order_info ");
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
		public System.Model.order_info GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, serialNumber, facility, port, price, discount, customid, pudate, statuses, duration, types, stippleid  ");			
			strSql.Append("  from order_info ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			System.Model.order_info model=new System.Model.order_info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.serialNumber= ds.Tables[0].Rows[0]["serialNumber"].ToString();
																												if(ds.Tables[0].Rows[0]["facility"].ToString()!="")
				{
					model.facility=int.Parse(ds.Tables[0].Rows[0]["facility"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["port"].ToString()!="")
				{
					model.port=int.Parse(ds.Tables[0].Rows[0]["port"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["discount"].ToString()!="")
				{
					model.discount=decimal.Parse(ds.Tables[0].Rows[0]["discount"].ToString());
				}
																																				model.customid= ds.Tables[0].Rows[0]["customid"].ToString();
																												if(ds.Tables[0].Rows[0]["pudate"].ToString()!="")
				{
					model.pudate=DateTime.Parse(ds.Tables[0].Rows[0]["pudate"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["statuses"].ToString()!="")
				{
					model.statuses=int.Parse(ds.Tables[0].Rows[0]["statuses"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["duration"].ToString()!="")
				{
					model.duration=int.Parse(ds.Tables[0].Rows[0]["duration"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["types"].ToString()!="")
				{
					model.types=int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["stippleid"].ToString()!="")
				{
					model.stippleid=int.Parse(ds.Tables[0].Rows[0]["stippleid"].ToString());
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
			strSql.Append(" FROM order_info ");
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
            strSql.Append(" FROM order_info T");
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
			strSql.Append(" FROM order_info ");
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
			strSql.Append(" FROM order_info T");
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
			strSql.Append("select count(1) FROM order_info T");
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
			strSql.Append(")AS Row, T.*  from order_info T ");
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
            strSql.Append(" from order_info T ");
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
            strSql.Append(" from order_info T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

