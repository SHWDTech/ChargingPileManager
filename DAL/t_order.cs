
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
	 	//t_order
		public partial class t_order
	{
   		     
		public bool Exists(string orderId,string shName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_order");
			strSql.Append(" where ");
			                                       strSql.Append(" orderId = @orderId and  ");
                                                                   strSql.Append(" shName = @shName  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.NVarChar,50),
					new SqlParameter("@shName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = orderId;
			parameters[1].Value = shName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.t_order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_order(");			
            strSql.Append("orderId,customId,sjId,shName,shPhone,shAdress,money,yhjId,zffs,pudate,zt,yhMoney,songDate,liuyan,pstype");
			strSql.Append(") values (");
            strSql.Append("@orderId,@customId,@sjId,@shName,@shPhone,@shAdress,@money,@yhjId,@zffs,@pudate,@zt,@yhMoney,@songDate,@liuyan,@pstype");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@orderId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shPhone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shAdress", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@money", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yhjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zffs", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yhMoney", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@songDate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@liuyan", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@pstype", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.orderId;                        
            parameters[1].Value = model.customId;                        
            parameters[2].Value = model.sjId;                        
            parameters[3].Value = model.shName;                        
            parameters[4].Value = model.shPhone;                        
            parameters[5].Value = model.shAdress;                        
            parameters[6].Value = model.money;                        
            parameters[7].Value = model.yhjId;                        
            parameters[8].Value = model.zffs;                        
            parameters[9].Value = model.pudate;                        
            parameters[10].Value = model.zt;                        
            parameters[11].Value = model.yhMoney;                        
            parameters[12].Value = model.songDate;                        
            parameters[13].Value = model.liuyan;                        
            parameters[14].Value = model.pstype;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.t_order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_order set ");
			                        
            strSql.Append(" orderId = @orderId , ");                                    
            strSql.Append(" customId = @customId , ");                                    
            strSql.Append(" sjId = @sjId , ");                                    
            strSql.Append(" shName = @shName , ");                                    
            strSql.Append(" shPhone = @shPhone , ");                                    
            strSql.Append(" shAdress = @shAdress , ");                                    
            strSql.Append(" money = @money , ");                                    
            strSql.Append(" yhjId = @yhjId , ");                                    
            strSql.Append(" zffs = @zffs , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" zt = @zt , ");                                    
            strSql.Append(" yhMoney = @yhMoney , ");                                    
            strSql.Append(" songDate = @songDate , ");                                    
            strSql.Append(" liuyan = @liuyan , ");                                    
            strSql.Append(" pstype = @pstype  ");            			
			strSql.Append(" where orderId=@orderId and shName=@shName  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@orderId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shPhone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shAdress", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@money", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yhjId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zffs", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@zt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yhMoney", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@songDate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@liuyan", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@pstype", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.orderId;                        
            parameters[1].Value = model.customId;                        
            parameters[2].Value = model.sjId;                        
            parameters[3].Value = model.shName;                        
            parameters[4].Value = model.shPhone;                        
            parameters[5].Value = model.shAdress;                        
            parameters[6].Value = model.money;                        
            parameters[7].Value = model.yhjId;                        
            parameters[8].Value = model.zffs;                        
            parameters[9].Value = model.pudate;                        
            parameters[10].Value = model.zt;                        
            parameters[11].Value = model.yhMoney;                        
            parameters[12].Value = model.songDate;                        
            parameters[13].Value = model.liuyan;                        
            parameters[14].Value = model.pstype;                        
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
		public bool Delete(string orderId,string shName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_order ");
			strSql.Append(" where orderId=@orderId and shName=@shName ");
						SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.NVarChar,50),
					new SqlParameter("@shName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = orderId;
			parameters[1].Value = shName;


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
		public System.Model.t_order GetModel(string orderId,string shName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select orderId, customId, sjId, shName, shPhone, shAdress, money, yhjId, zffs, pudate, zt, yhMoney, songDate, liuyan, pstype  ");			
			strSql.Append("  from t_order ");
			strSql.Append(" where orderId=@orderId and shName=@shName ");
						SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.NVarChar,50),
					new SqlParameter("@shName", SqlDbType.NVarChar,50)			};
			parameters[0].Value = orderId;
			parameters[1].Value = shName;

			
			System.Model.t_order model=new System.Model.t_order();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.orderId= ds.Tables[0].Rows[0]["orderId"].ToString();
																																model.customId= ds.Tables[0].Rows[0]["customId"].ToString();
																																model.sjId= ds.Tables[0].Rows[0]["sjId"].ToString();
																																model.shName= ds.Tables[0].Rows[0]["shName"].ToString();
																																model.shPhone= ds.Tables[0].Rows[0]["shPhone"].ToString();
																																model.shAdress= ds.Tables[0].Rows[0]["shAdress"].ToString();
																																model.money= ds.Tables[0].Rows[0]["money"].ToString();
																																model.yhjId= ds.Tables[0].Rows[0]["yhjId"].ToString();
																																model.zffs= ds.Tables[0].Rows[0]["zffs"].ToString();
																																model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.zt= ds.Tables[0].Rows[0]["zt"].ToString();
																																model.yhMoney= ds.Tables[0].Rows[0]["yhMoney"].ToString();
																																model.songDate= ds.Tables[0].Rows[0]["songDate"].ToString();
																																model.liuyan= ds.Tables[0].Rows[0]["liuyan"].ToString();
																												if(ds.Tables[0].Rows[0]["pstype"].ToString()!="")
				{
					model.pstype=int.Parse(ds.Tables[0].Rows[0]["pstype"].ToString());
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
			strSql.Append(" FROM t_order ");
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
            strSql.Append(" FROM t_order T");
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
			strSql.Append(" FROM t_order ");
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
			strSql.Append(" FROM t_order T");
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
			strSql.Append("select count(1) FROM t_order T");
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
			strSql.Append(")AS Row, T.*  from t_order T ");
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
            strSql.Append(" from t_order T ");
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
            strSql.Append(" from t_order T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

