
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
	 	//V_order_details
		public partial class V_order_details
	{
   		
   		
   		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "V_order_details");
        }
   		
   		/// <summary>
        /// 判断是否存在该条数据
        /// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from V_order_details");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.V_order_details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into V_order_details(");			
            strSql.Append("id,duration,ftype,portno,fno,phone,sname,serialNumber,facility,port,price,discount,customid,pudate,paydate,paystatus,types,typename,ctype");
			strSql.Append(") values (");
            strSql.Append("@id,@duration,@ftype,@portno,@fno,@phone,@sname,@serialNumber,@facility,@port,@price,@discount,@customid,@pudate,@paydate,@paystatus,@types,@typename,@ctype");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@duration", SqlDbType.Int,4) ,            
                        new SqlParameter("@ftype", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@portno", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@fno", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@phone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@facility", SqlDbType.Int,4) ,            
                        new SqlParameter("@port", SqlDbType.Int,4) ,            
                        new SqlParameter("@price", SqlDbType.Money,8) ,            
                        new SqlParameter("@discount", SqlDbType.Float,8) ,            
                        new SqlParameter("@customid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@paydate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@paystatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@typename", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ctype", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.duration;                        
            parameters[2].Value = model.ftype;                        
            parameters[3].Value = model.portno;                        
            parameters[4].Value = model.fno;                        
            parameters[5].Value = model.phone;                        
            parameters[6].Value = model.sname;                        
            parameters[7].Value = model.serialNumber;                        
            parameters[8].Value = model.facility;                        
            parameters[9].Value = model.port;                        
            parameters[10].Value = model.price;                        
            parameters[11].Value = model.discount;                        
            parameters[12].Value = model.customid;                        
            parameters[13].Value = model.pudate;                        
            parameters[14].Value = model.paydate;                        
            parameters[15].Value = model.paystatus;                        
            parameters[16].Value = model.types;                        
            parameters[17].Value = model.typename;                        
            parameters[18].Value = model.ctype;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.V_order_details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update V_order_details set ");
			                        
            strSql.Append(" id = @id , ");                                    
            strSql.Append(" duration = @duration , ");                                    
            strSql.Append(" ftype = @ftype , ");                                    
            strSql.Append(" portno = @portno , ");                                    
            strSql.Append(" fno = @fno , ");                                    
            strSql.Append(" phone = @phone , ");                                    
            strSql.Append(" sname = @sname , ");                                    
            strSql.Append(" serialNumber = @serialNumber , ");                                    
            strSql.Append(" facility = @facility , ");                                    
            strSql.Append(" port = @port , ");                                    
            strSql.Append(" price = @price , ");                                    
            strSql.Append(" discount = @discount , ");                                    
            strSql.Append(" customid = @customid , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" paydate = @paydate , ");                                    
            strSql.Append(" paystatus = @paystatus , ");                                    
            strSql.Append(" types = @types , ");                                    
            strSql.Append(" typename = @typename , ");                                    
            strSql.Append(" ctype = @ctype  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@duration", SqlDbType.Int,4) ,            
                        new SqlParameter("@ftype", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@portno", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@fno", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@phone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@facility", SqlDbType.Int,4) ,            
                        new SqlParameter("@port", SqlDbType.Int,4) ,            
                        new SqlParameter("@price", SqlDbType.Money,8) ,            
                        new SqlParameter("@discount", SqlDbType.Float,8) ,            
                        new SqlParameter("@customid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@paydate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@paystatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@typename", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ctype", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.duration;                        
            parameters[2].Value = model.ftype;                        
            parameters[3].Value = model.portno;                        
            parameters[4].Value = model.fno;                        
            parameters[5].Value = model.phone;                        
            parameters[6].Value = model.sname;                        
            parameters[7].Value = model.serialNumber;                        
            parameters[8].Value = model.facility;                        
            parameters[9].Value = model.port;                        
            parameters[10].Value = model.price;                        
            parameters[11].Value = model.discount;                        
            parameters[12].Value = model.customid;                        
            parameters[13].Value = model.pudate;                        
            parameters[14].Value = model.paydate;                        
            parameters[15].Value = model.paystatus;                        
            parameters[16].Value = model.types;                        
            parameters[17].Value = model.typename;                        
            parameters[18].Value = model.ctype;                        
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
			strSql.Append("delete from V_order_details ");
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
		public System.Model.V_order_details GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, duration, ftype, portno, fno, phone, sname, serialNumber, facility, port, price, discount, customid, pudate, paydate, paystatus, types, typename, ctype  ");			
			strSql.Append("  from V_order_details ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			System.Model.V_order_details model=new System.Model.V_order_details();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["duration"].ToString()!="")
				{
					model.duration=int.Parse(ds.Tables[0].Rows[0]["duration"].ToString());
				}
																																				model.ftype= ds.Tables[0].Rows[0]["ftype"].ToString();
																																model.portno= ds.Tables[0].Rows[0]["portno"].ToString();
																																model.fno= ds.Tables[0].Rows[0]["fno"].ToString();
																																model.phone= ds.Tables[0].Rows[0]["phone"].ToString();
																																model.sname= ds.Tables[0].Rows[0]["sname"].ToString();
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
																																				model.paydate= ds.Tables[0].Rows[0]["paydate"].ToString();
																												if(ds.Tables[0].Rows[0]["paystatus"].ToString()!="")
				{
					model.paystatus=int.Parse(ds.Tables[0].Rows[0]["paystatus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["types"].ToString()!="")
				{
					model.types=int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
				}
																																				model.typename= ds.Tables[0].Rows[0]["typename"].ToString();
																												if(ds.Tables[0].Rows[0]["ctype"].ToString()!="")
				{
					model.ctype=int.Parse(ds.Tables[0].Rows[0]["ctype"].ToString());
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
			strSql.Append(" FROM V_order_details ");
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
            strSql.Append(" FROM V_order_details T");
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
			strSql.Append(" FROM V_order_details ");
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
			strSql.Append(" FROM V_order_details T");
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
			strSql.Append("select count(1) FROM V_order_details T");
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
			strSql.Append(")AS Row, T.*  from V_order_details T ");
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
            strSql.Append(" from V_order_details T ");
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
            strSql.Append(" from V_order_details T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

