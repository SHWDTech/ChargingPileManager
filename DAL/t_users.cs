
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
	 	//t_users
		public partial class t_users
	{
   		     
		public bool Exists(string usersId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_users");
			strSql.Append(" where ");
			                                       strSql.Append(" usersId = @usersId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@usersId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = usersId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.t_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_users(");			
            strSql.Append("usersId,name,phone,code,pwd,roleId,pudate,imgUrl,adress,jingdu,weidu,jieshao,hbImg,lx,xj,customId,yyDate1,yyDate2,xxDate1,xxDate2,money,yyZt,schoolid,managecity,mprovince,managearea,schoolname,notice,man,shippingfee,shoptag");
			strSql.Append(") values (");
            strSql.Append("@usersId,@name,@phone,@code,@pwd,@roleId,@pudate,@imgUrl,@adress,@jingdu,@weidu,@jieshao,@hbImg,@lx,@xj,@customId,@yyDate1,@yyDate2,@xxDate1,@xxDate2,@money,@yyZt,@schoolid,@managecity,@mprovince,@managearea,@schoolname,@notice,@man,@shippingfee,@shoptag");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@phone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@code", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@roleId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@imgUrl", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@adress", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@jingdu", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@weidu", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@jieshao", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@hbImg", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@lx", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xj", SqlDbType.Int,4) ,            
                        new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yyDate1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yyDate2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xxDate1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xxDate2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.Money,8) ,            
                        new SqlParameter("@yyZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@schoolid", SqlDbType.Int,4) ,            
                        new SqlParameter("@managecity", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@mprovince", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@managearea", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@schoolname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@notice", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@man", SqlDbType.Money,8) ,            
                        new SqlParameter("@shippingfee", SqlDbType.Money,8) ,            
                        new SqlParameter("@shoptag", SqlDbType.NVarChar,50)             
              
            };
			            
            parameters[0].Value = model.usersId;                        
            parameters[1].Value = model.name;                        
            parameters[2].Value = model.phone;                        
            parameters[3].Value = model.code;                        
            parameters[4].Value = model.pwd;                        
            parameters[5].Value = model.roleId;                        
            parameters[6].Value = model.pudate;                        
            parameters[7].Value = model.imgUrl;                        
            parameters[8].Value = model.adress;                        
            parameters[9].Value = model.jingdu;                        
            parameters[10].Value = model.weidu;                        
            parameters[11].Value = model.jieshao;                        
            parameters[12].Value = model.hbImg;                        
            parameters[13].Value = model.lx;                        
            parameters[14].Value = model.xj;                        
            parameters[15].Value = model.customId;                        
            parameters[16].Value = model.yyDate1;                        
            parameters[17].Value = model.yyDate2;                        
            parameters[18].Value = model.xxDate1;                        
            parameters[19].Value = model.xxDate2;                        
            parameters[20].Value = model.money;                        
            parameters[21].Value = model.yyZt;                        
            parameters[22].Value = model.schoolid;                        
            parameters[23].Value = model.managecity;                        
            parameters[24].Value = model.mprovince;                        
            parameters[25].Value = model.managearea;                        
            parameters[26].Value = model.schoolname;                        
            parameters[27].Value = model.notice;                        
            parameters[28].Value = model.man;                        
            parameters[29].Value = model.shippingfee;                        
            parameters[30].Value = model.shoptag;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.t_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_users set ");
			                        
            strSql.Append(" usersId = @usersId , ");                                    
            strSql.Append(" name = @name , ");                                    
            strSql.Append(" phone = @phone , ");                                    
            strSql.Append(" code = @code , ");                                    
            strSql.Append(" pwd = @pwd , ");                                    
            strSql.Append(" roleId = @roleId , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" imgUrl = @imgUrl , ");                                    
            strSql.Append(" adress = @adress , ");                                    
            strSql.Append(" jingdu = @jingdu , ");                                    
            strSql.Append(" weidu = @weidu , ");                                    
            strSql.Append(" jieshao = @jieshao , ");                                    
            strSql.Append(" hbImg = @hbImg , ");                                    
            strSql.Append(" lx = @lx , ");                                    
            strSql.Append(" xj = @xj , ");                                    
            strSql.Append(" customId = @customId , ");                                    
            strSql.Append(" yyDate1 = @yyDate1 , ");                                    
            strSql.Append(" yyDate2 = @yyDate2 , ");                                    
            strSql.Append(" xxDate1 = @xxDate1 , ");                                    
            strSql.Append(" xxDate2 = @xxDate2 , ");                                    
            strSql.Append(" money = @money , ");                                    
            strSql.Append(" yyZt = @yyZt , ");                                    
            strSql.Append(" schoolid = @schoolid , ");                                    
            strSql.Append(" managecity = @managecity , ");                                    
            strSql.Append(" mprovince = @mprovince , ");                                    
            strSql.Append(" managearea = @managearea , ");                                    
            strSql.Append(" schoolname = @schoolname , ");                                    
            strSql.Append(" notice = @notice , ");                                    
            strSql.Append(" man = @man , ");                                    
            strSql.Append(" shippingfee = @shippingfee , ");                                    
            strSql.Append(" shoptag = @shoptag  ");            			
			strSql.Append(" where usersId=@usersId  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@usersId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@name", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@phone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@code", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pwd", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@roleId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@imgUrl", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@adress", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@jingdu", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@weidu", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@jieshao", SqlDbType.NVarChar,2000) ,            
                        new SqlParameter("@hbImg", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@lx", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xj", SqlDbType.Int,4) ,            
                        new SqlParameter("@customId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yyDate1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@yyDate2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xxDate1", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@xxDate2", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@money", SqlDbType.Money,8) ,            
                        new SqlParameter("@yyZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@schoolid", SqlDbType.Int,4) ,            
                        new SqlParameter("@managecity", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@mprovince", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@managearea", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@schoolname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@notice", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@man", SqlDbType.Money,8) ,            
                        new SqlParameter("@shippingfee", SqlDbType.Money,8) ,            
                        new SqlParameter("@shoptag", SqlDbType.NVarChar,50)             
              
            };
						            
            parameters[0].Value = model.usersId;                        
            parameters[1].Value = model.name;                        
            parameters[2].Value = model.phone;                        
            parameters[3].Value = model.code;                        
            parameters[4].Value = model.pwd;                        
            parameters[5].Value = model.roleId;                        
            parameters[6].Value = model.pudate;                        
            parameters[7].Value = model.imgUrl;                        
            parameters[8].Value = model.adress;                        
            parameters[9].Value = model.jingdu;                        
            parameters[10].Value = model.weidu;                        
            parameters[11].Value = model.jieshao;                        
            parameters[12].Value = model.hbImg;                        
            parameters[13].Value = model.lx;                        
            parameters[14].Value = model.xj;                        
            parameters[15].Value = model.customId;                        
            parameters[16].Value = model.yyDate1;                        
            parameters[17].Value = model.yyDate2;                        
            parameters[18].Value = model.xxDate1;                        
            parameters[19].Value = model.xxDate2;                        
            parameters[20].Value = model.money;                        
            parameters[21].Value = model.yyZt;                        
            parameters[22].Value = model.schoolid;                        
            parameters[23].Value = model.managecity;                        
            parameters[24].Value = model.mprovince;                        
            parameters[25].Value = model.managearea;                        
            parameters[26].Value = model.schoolname;                        
            parameters[27].Value = model.notice;                        
            parameters[28].Value = model.man;                        
            parameters[29].Value = model.shippingfee;                        
            parameters[30].Value = model.shoptag;                        
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
		public bool Delete(string usersId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_users ");
			strSql.Append(" where usersId=@usersId ");
						SqlParameter[] parameters = {
					new SqlParameter("@usersId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = usersId;


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
		public System.Model.t_users GetModel(string usersId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select usersId, name, phone, code, pwd, roleId, pudate, imgUrl, adress, jingdu, weidu, jieshao, hbImg, lx, xj, customId, yyDate1, yyDate2, xxDate1, xxDate2, money, yyZt, schoolid, managecity, mprovince, managearea, schoolname, notice, man, shippingfee, shoptag  ");			
			strSql.Append("  from t_users ");
			strSql.Append(" where usersId=@usersId ");
						SqlParameter[] parameters = {
					new SqlParameter("@usersId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = usersId;

			
			System.Model.t_users model=new System.Model.t_users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.usersId= ds.Tables[0].Rows[0]["usersId"].ToString();
																																model.name= ds.Tables[0].Rows[0]["name"].ToString();
																																model.phone= ds.Tables[0].Rows[0]["phone"].ToString();
																																model.code= ds.Tables[0].Rows[0]["code"].ToString();
																																model.pwd= ds.Tables[0].Rows[0]["pwd"].ToString();
																																model.roleId= ds.Tables[0].Rows[0]["roleId"].ToString();
																																model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.imgUrl= ds.Tables[0].Rows[0]["imgUrl"].ToString();
																																model.adress= ds.Tables[0].Rows[0]["adress"].ToString();
																																model.jingdu= ds.Tables[0].Rows[0]["jingdu"].ToString();
																																model.weidu= ds.Tables[0].Rows[0]["weidu"].ToString();
																																model.jieshao= ds.Tables[0].Rows[0]["jieshao"].ToString();
																																model.hbImg= ds.Tables[0].Rows[0]["hbImg"].ToString();
																																model.lx= ds.Tables[0].Rows[0]["lx"].ToString();
																												if(ds.Tables[0].Rows[0]["xj"].ToString()!="")
				{
					model.xj=int.Parse(ds.Tables[0].Rows[0]["xj"].ToString());
				}
																																				model.customId= ds.Tables[0].Rows[0]["customId"].ToString();
																																model.yyDate1= ds.Tables[0].Rows[0]["yyDate1"].ToString();
																																model.yyDate2= ds.Tables[0].Rows[0]["yyDate2"].ToString();
																																model.xxDate1= ds.Tables[0].Rows[0]["xxDate1"].ToString();
																																model.xxDate2= ds.Tables[0].Rows[0]["xxDate2"].ToString();
																												if(ds.Tables[0].Rows[0]["money"].ToString()!="")
				{
					model.money=decimal.Parse(ds.Tables[0].Rows[0]["money"].ToString());
				}
																																				model.yyZt= ds.Tables[0].Rows[0]["yyZt"].ToString();
																												if(ds.Tables[0].Rows[0]["schoolid"].ToString()!="")
				{
					model.schoolid=int.Parse(ds.Tables[0].Rows[0]["schoolid"].ToString());
				}
																																				model.managecity= ds.Tables[0].Rows[0]["managecity"].ToString();
																																model.mprovince= ds.Tables[0].Rows[0]["mprovince"].ToString();
																																model.managearea= ds.Tables[0].Rows[0]["managearea"].ToString();
																																model.schoolname= ds.Tables[0].Rows[0]["schoolname"].ToString();
																																model.notice= ds.Tables[0].Rows[0]["notice"].ToString();
																												if(ds.Tables[0].Rows[0]["man"].ToString()!="")
				{
					model.man=decimal.Parse(ds.Tables[0].Rows[0]["man"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["shippingfee"].ToString()!="")
				{
					model.shippingfee=decimal.Parse(ds.Tables[0].Rows[0]["shippingfee"].ToString());
				}
																																				model.shoptag= ds.Tables[0].Rows[0]["shoptag"].ToString();
																										
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
			strSql.Append(" FROM t_users ");
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
            strSql.Append(" FROM t_users T");
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
			strSql.Append(" FROM t_users ");
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
			strSql.Append(" FROM t_users T");
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
			strSql.Append("select count(1) FROM t_users T");
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
			strSql.Append(")AS Row, T.*  from t_users T ");
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
            strSql.Append(" from t_users T ");
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
            strSql.Append(" from t_users T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

