
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
	 	//facility_stipple
		public partial class facility_stipple
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from facility_stipple");
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
		public int Add(System.Model.facility_stipple model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into facility_stipple(");			
            strSql.Append("name,no,referral,longitude,latitude,statuses,city1,city2,city3,pudate,isdel,img");
			strSql.Append(") values (");
            strSql.Append("@name,@no,@referral,@longitude,@latitude,@statuses,@city1,@city2,@city3,@pudate,@isdel,@img");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@referral", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@longitude", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@latitude", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@city1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@city2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@city3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@isdel", SqlDbType.Int,4) ,            
                        new SqlParameter("@img", SqlDbType.NVarChar,200)             
              
            };
			            
            parameters[0].Value = model.name;                        
            parameters[1].Value = model.no;                        
            parameters[2].Value = model.referral;                        
            parameters[3].Value = model.longitude;                        
            parameters[4].Value = model.latitude;                        
            parameters[5].Value = model.statuses;                        
            parameters[6].Value = model.city1;                        
            parameters[7].Value = model.city2;                        
            parameters[8].Value = model.city3;                        
            parameters[9].Value = model.pudate;                        
            parameters[10].Value = model.isdel;                        
            parameters[11].Value = model.img;                        
			   
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
		public bool Update(System.Model.facility_stipple model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update facility_stipple set ");
			                                                
            strSql.Append(" name = @name , ");                                    
            strSql.Append(" no = @no , ");                                    
            strSql.Append(" referral = @referral , ");                                    
            strSql.Append(" longitude = @longitude , ");                                    
            strSql.Append(" latitude = @latitude , ");                                    
            strSql.Append(" statuses = @statuses , ");                                    
            strSql.Append(" city1 = @city1 , ");                                    
            strSql.Append(" city2 = @city2 , ");                                    
            strSql.Append(" city3 = @city3 , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" isdel = @isdel , ");                                    
            strSql.Append(" img = @img  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@no", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@referral", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@longitude", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@latitude", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@statuses", SqlDbType.Int,4) ,            
                        new SqlParameter("@city1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@city2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@city3", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.DateTime) ,            
                        new SqlParameter("@isdel", SqlDbType.Int,4) ,            
                        new SqlParameter("@img", SqlDbType.NVarChar,200)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.name;                        
            parameters[2].Value = model.no;                        
            parameters[3].Value = model.referral;                        
            parameters[4].Value = model.longitude;                        
            parameters[5].Value = model.latitude;                        
            parameters[6].Value = model.statuses;                        
            parameters[7].Value = model.city1;                        
            parameters[8].Value = model.city2;                        
            parameters[9].Value = model.city3;                        
            parameters[10].Value = model.pudate;                        
            parameters[11].Value = model.isdel;                        
            parameters[12].Value = model.img;                        
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
			strSql.Append("delete from facility_stipple ");
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
			strSql.Append("delete from facility_stipple ");
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
		public System.Model.facility_stipple GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, name, no, referral, longitude, latitude, statuses, city1, city2, city3, pudate, isdel, img  ");			
			strSql.Append("  from facility_stipple ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			System.Model.facility_stipple model=new System.Model.facility_stipple();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.name= ds.Tables[0].Rows[0]["name"].ToString();
																																model.no= ds.Tables[0].Rows[0]["no"].ToString();
																																model.referral= ds.Tables[0].Rows[0]["referral"].ToString();
																												if(ds.Tables[0].Rows[0]["longitude"].ToString()!="")
				{
					model.longitude=decimal.Parse(ds.Tables[0].Rows[0]["longitude"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["latitude"].ToString()!="")
				{
					model.latitude=decimal.Parse(ds.Tables[0].Rows[0]["latitude"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["statuses"].ToString()!="")
				{
					model.statuses=int.Parse(ds.Tables[0].Rows[0]["statuses"].ToString());
				}
																																				model.city1= ds.Tables[0].Rows[0]["city1"].ToString();
																																model.city2= ds.Tables[0].Rows[0]["city2"].ToString();
																																model.city3= ds.Tables[0].Rows[0]["city3"].ToString();
																												if(ds.Tables[0].Rows[0]["pudate"].ToString()!="")
				{
					model.pudate=DateTime.Parse(ds.Tables[0].Rows[0]["pudate"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["isdel"].ToString()!="")
				{
					model.isdel=int.Parse(ds.Tables[0].Rows[0]["isdel"].ToString());
				}
																																				model.img= ds.Tables[0].Rows[0]["img"].ToString();
																										
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
			strSql.Append(" FROM facility_stipple ");
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
            strSql.Append(" FROM facility_stipple T");
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
			strSql.Append(" FROM facility_stipple ");
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
			strSql.Append(" FROM facility_stipple T");
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
			strSql.Append("select count(1) FROM facility_stipple T");
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
			strSql.Append(")AS Row, T.*  from facility_stipple T ");
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
            strSql.Append(" from facility_stipple T ");
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
            strSql.Append(" from facility_stipple T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

