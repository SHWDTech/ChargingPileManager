
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
	 	//v_hd_goods
		public partial class v_hd_goods
	{
   		     
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_hd_goods");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(System.Model.v_hd_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_hd_goods(");			
            strSql.Append("id,hdId,goodsId,usesrId,flId,title,xjMoney,yjMoney,kcNum,memo,pudate,delZt,sjZt,img,hdMoney,ggName");
			strSql.Append(") values (");
            strSql.Append("@id,@hdId,@goodsId,@usesrId,@flId,@title,@xjMoney,@yjMoney,@kcNum,@memo,@pudate,@delZt,@sjZt,@img,@hdMoney,@ggName");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@hdId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@goodsId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@usesrId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@flId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@xjMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@yjMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@kcNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@memo", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@delZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sjZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@img", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@hdMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@ggName", SqlDbType.NVarChar,100)             
              
            };
			            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.hdId;                        
            parameters[2].Value = model.goodsId;                        
            parameters[3].Value = model.usesrId;                        
            parameters[4].Value = model.flId;                        
            parameters[5].Value = model.title;                        
            parameters[6].Value = model.xjMoney;                        
            parameters[7].Value = model.yjMoney;                        
            parameters[8].Value = model.kcNum;                        
            parameters[9].Value = model.memo;                        
            parameters[10].Value = model.pudate;                        
            parameters[11].Value = model.delZt;                        
            parameters[12].Value = model.sjZt;                        
            parameters[13].Value = model.img;                        
            parameters[14].Value = model.hdMoney;                        
            parameters[15].Value = model.ggName;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.v_hd_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_hd_goods set ");
			                        
            strSql.Append(" id = @id , ");                                    
            strSql.Append(" hdId = @hdId , ");                                    
            strSql.Append(" goodsId = @goodsId , ");                                    
            strSql.Append(" usesrId = @usesrId , ");                                    
            strSql.Append(" flId = @flId , ");                                    
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" xjMoney = @xjMoney , ");                                    
            strSql.Append(" yjMoney = @yjMoney , ");                                    
            strSql.Append(" kcNum = @kcNum , ");                                    
            strSql.Append(" memo = @memo , ");                                    
            strSql.Append(" pudate = @pudate , ");                                    
            strSql.Append(" delZt = @delZt , ");                                    
            strSql.Append(" sjZt = @sjZt , ");                                    
            strSql.Append(" img = @img , ");                                    
            strSql.Append(" hdMoney = @hdMoney , ");                                    
            strSql.Append(" ggName = @ggName  ");            			
			strSql.Append(" where  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@hdId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@goodsId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@usesrId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@flId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@xjMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@yjMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@kcNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@memo", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@pudate", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@delZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sjZt", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@img", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@hdMoney", SqlDbType.Money,8) ,            
                        new SqlParameter("@ggName", SqlDbType.NVarChar,100)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.hdId;                        
            parameters[2].Value = model.goodsId;                        
            parameters[3].Value = model.usesrId;                        
            parameters[4].Value = model.flId;                        
            parameters[5].Value = model.title;                        
            parameters[6].Value = model.xjMoney;                        
            parameters[7].Value = model.yjMoney;                        
            parameters[8].Value = model.kcNum;                        
            parameters[9].Value = model.memo;                        
            parameters[10].Value = model.pudate;                        
            parameters[11].Value = model.delZt;                        
            parameters[12].Value = model.sjZt;                        
            parameters[13].Value = model.img;                        
            parameters[14].Value = model.hdMoney;                        
            parameters[15].Value = model.ggName;                        
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
			strSql.Append("delete from v_hd_goods ");
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
		public System.Model.v_hd_goods GetModel()
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, hdId, goodsId, usesrId, flId, title, xjMoney, yjMoney, kcNum, memo, pudate, delZt, sjZt, img, hdMoney, ggName  ");			
			strSql.Append("  from v_hd_goods ");
			strSql.Append(" where ");
						SqlParameter[] parameters = {
			};

			
			System.Model.v_hd_goods model=new System.Model.v_hd_goods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.hdId= ds.Tables[0].Rows[0]["hdId"].ToString();
																																model.goodsId= ds.Tables[0].Rows[0]["goodsId"].ToString();
																																model.usesrId= ds.Tables[0].Rows[0]["usesrId"].ToString();
																																model.flId= ds.Tables[0].Rows[0]["flId"].ToString();
																																model.title= ds.Tables[0].Rows[0]["title"].ToString();
																												if(ds.Tables[0].Rows[0]["xjMoney"].ToString()!="")
				{
					model.xjMoney=decimal.Parse(ds.Tables[0].Rows[0]["xjMoney"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["yjMoney"].ToString()!="")
				{
					model.yjMoney=decimal.Parse(ds.Tables[0].Rows[0]["yjMoney"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["kcNum"].ToString()!="")
				{
					model.kcNum=int.Parse(ds.Tables[0].Rows[0]["kcNum"].ToString());
				}
																																				model.memo= ds.Tables[0].Rows[0]["memo"].ToString();
																																model.pudate= ds.Tables[0].Rows[0]["pudate"].ToString();
																																model.delZt= ds.Tables[0].Rows[0]["delZt"].ToString();
																																model.sjZt= ds.Tables[0].Rows[0]["sjZt"].ToString();
																																model.img= ds.Tables[0].Rows[0]["img"].ToString();
																												if(ds.Tables[0].Rows[0]["hdMoney"].ToString()!="")
				{
					model.hdMoney=decimal.Parse(ds.Tables[0].Rows[0]["hdMoney"].ToString());
				}
																																				model.ggName= ds.Tables[0].Rows[0]["ggName"].ToString();
																										
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
			strSql.Append(" FROM v_hd_goods ");
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
            strSql.Append(" FROM v_hd_goods T");
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
			strSql.Append(" FROM v_hd_goods ");
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
			strSql.Append(" FROM v_hd_goods T");
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
			strSql.Append("select count(1) FROM v_hd_goods T");
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
			strSql.Append(")AS Row, T.*  from v_hd_goods T ");
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
            strSql.Append(" from v_hd_goods T ");
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
            strSql.Append(" from v_hd_goods T ");
            strSql.Append(unionTables);
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
      
        
	}
}

