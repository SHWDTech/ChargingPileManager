
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
	 	//Member_Charge_Withdraw
		public partial class Member_Charge_Withdraw
	{
   		
   		
   		/// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "Member_Charge_Withdraw");
        }
   		
   		/// <summary>
        /// 判断是否存在该条数据
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Member_Charge_Withdraw");
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
		public int Add(System.Model.Member_Charge_Withdraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Member_Charge_Withdraw(");			
            strSql.Append("serialNumber,memberid,paytype,paystatus,typename,statusname,types,tpSerialNumber,moneyes,pudate,paydate,remarks");
			strSql.Append(") values (");
            strSql.Append("@serialNumber,@memberid,@paytype,@paystatus,@typename,@statusname,@types,@tpSerialNumber,@moneyes,@pudate,@paydate,@remarks");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@memberid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@paytype", SqlDbType.Int,4) ,            
                        new SqlParameter("@paystatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@typename", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@statusname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@tpSerialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@moneyes", SqlDbType.Money,8) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@paydate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remarks", SqlDbType.NVarChar,200)             
              
            };
			            
            parameters[0].Value = model.serialNumber;                        
            parameters[1].Value = model.memberid;                        
            parameters[2].Value = model.paytype;                        
            parameters[3].Value = model.paystatus;                        
            parameters[4].Value = model.typename;                        
            parameters[5].Value = model.statusname;                        
            parameters[6].Value = model.types;                        
            parameters[7].Value = model.tpSerialNumber;                        
            parameters[8].Value = model.moneyes;                        
            parameters[9].Value = model.pudate;                        
            parameters[10].Value = model.paydate;                        
            parameters[11].Value = model.remarks;                        
			   
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
		public bool Update(System.Model.Member_Charge_Withdraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Member_Charge_Withdraw set ");
			                                                
            strSql.Append(" serialNumber = @serialNumber , ");                                    
            strSql.Append(" memberid = @memberid , ");                                    
            strSql.Append(" paytype = @paytype , ");                                    
            strSql.Append(" paystatus = @paystatus , ");                                    
            strSql.Append(" typename = @typename , ");                                    
            strSql.Append(" statusname = @statusname , ");                                    
            strSql.Append(" types = @types , ");                                    
            strSql.Append(" tpSerialNumber = @tpSerialNumber , ");                                    
            strSql.Append(" moneyes = @moneyes , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" paydate = @paydate , ");                                    
            strSql.Append(" remarks = @remarks  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@serialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@memberid", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@paytype", SqlDbType.Int,4) ,            
                        new SqlParameter("@paystatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@typename", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@statusname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@types", SqlDbType.Int,4) ,            
                        new SqlParameter("@tpSerialNumber", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@moneyes", SqlDbType.Money,8) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@paydate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@remarks", SqlDbType.NVarChar,200)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.serialNumber;                        
            parameters[2].Value = model.memberid;                        
            parameters[3].Value = model.paytype;                        
            parameters[4].Value = model.paystatus;                        
            parameters[5].Value = model.typename;                        
            parameters[6].Value = model.statusname;                        
            parameters[7].Value = model.types;                        
            parameters[8].Value = model.tpSerialNumber;                        
            parameters[9].Value = model.moneyes;                        
            parameters[10].Value = model.pudate;                        
            parameters[11].Value = model.paydate;                        
            parameters[12].Value = model.remarks;                        
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
			strSql.Append("delete from Member_Charge_Withdraw ");
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
			strSql.Append("delete from Member_Charge_Withdraw ");
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
		public System.Model.Member_Charge_Withdraw GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, serialNumber, memberid, paytype, paystatus, typename, statusname, types, tpSerialNumber, moneyes, pudate, paydate, remarks  ");			
			strSql.Append("  from Member_Charge_Withdraw ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			System.Model.Member_Charge_Withdraw model=new System.Model.Member_Charge_Withdraw();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.serialNumber= ds.Tables[0].Rows[0]["serialNumber"].ToString();
																																model.memberid= ds.Tables[0].Rows[0]["memberid"].ToString();
																												if(ds.Tables[0].Rows[0]["paytype"].ToString()!="")
				{
					model.paytype=int.Parse(ds.Tables[0].Rows[0]["paytype"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["paystatus"].ToString()!="")
				{
					model.paystatus=int.Parse(ds.Tables[0].Rows[0]["paystatus"].ToString());
				}
																																				model.typename= ds.Tables[0].Rows[0]["typename"].ToString();
																																model.statusname= ds.Tables[0].Rows[0]["statusname"].ToString();
																												if(ds.Tables[0].Rows[0]["types"].ToString()!="")
				{
					model.types=int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
				}
																																				model.tpSerialNumber= ds.Tables[0].Rows[0]["tpSerialNumber"].ToString();
																												if(ds.Tables[0].Rows[0]["moneyes"].ToString()!="")
				{
					model.moneyes=decimal.Parse(ds.Tables[0].Rows[0]["moneyes"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["pudate"].ToString()!="")
				{
					model.pudate=DateTime.Parse(ds.Tables[0].Rows[0]["pudate"].ToString());
				}
																																				model.paydate= ds.Tables[0].Rows[0]["paydate"].ToString();
																																model.remarks= ds.Tables[0].Rows[0]["remarks"].ToString();
																										
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
			strSql.Append(" FROM Member_Charge_Withdraw ");
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
            strSql.Append(" FROM Member_Charge_Withdraw T");
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
			strSql.Append(" FROM Member_Charge_Withdraw ");
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
			strSql.Append(" FROM Member_Charge_Withdraw T");
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
			strSql.Append("select count(1) FROM Member_Charge_Withdraw T");
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
			strSql.Append(")AS Row, T.*  from Member_Charge_Withdraw T ");
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
            strSql.Append(" from Member_Charge_Withdraw T ");
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
            strSql.Append(" from Member_Charge_Withdraw T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

