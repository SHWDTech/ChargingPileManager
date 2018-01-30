

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
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;

namespace System.BLL {
	 	//t_users
		public partial class t_users
	{
   		     
		private readonly System.DAL.t_users dal=new System.DAL.t_users();
		public t_users()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string usersId)
		{
			return dal.Exists(usersId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(System.Model.t_users model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.t_users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string usersId)
		{
			
			return dal.Delete(usersId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public System.Model.t_users GetModel(string usersId)
		{
			
			return dal.GetModel(usersId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public System.Model.t_users GetModelByCache(string usersId)
		//{
		//	
		//	string CacheKey = "t_usersModel-" + usersId;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(usersId);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (System.Model.t_users)objModel;
		//}




		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<System.Model.t_users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		
		/// <summary>
        /// 获得数据列表
        /// </summary>
        public List<System.Model.t_users> GetModelList(string strWhere, params SqlParameter[] parameters)
        {
            DataSet ds = dal.GetList(strWhere, parameters);
            return DataTableToList(ds.Tables[0]);
        }
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<System.Model.t_users> DataTableToList(DataTable dt)
		{
			List<System.Model.t_users> modelList = new List<System.Model.t_users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				System.Model.t_users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new System.Model.t_users();					
																	model.usersId= dt.Rows[n]["usersId"].ToString();
																																model.name= dt.Rows[n]["name"].ToString();
																																model.phone= dt.Rows[n]["phone"].ToString();
																																model.code= dt.Rows[n]["code"].ToString();
																																model.pwd= dt.Rows[n]["pwd"].ToString();
																																model.roleId= dt.Rows[n]["roleId"].ToString();
																																model.pudate= dt.Rows[n]["pudate"].ToString();
																																model.imgUrl= dt.Rows[n]["imgUrl"].ToString();
																																model.adress= dt.Rows[n]["adress"].ToString();
																																model.jingdu= dt.Rows[n]["jingdu"].ToString();
																																model.weidu= dt.Rows[n]["weidu"].ToString();
																																model.jieshao= dt.Rows[n]["jieshao"].ToString();
																																model.hbImg= dt.Rows[n]["hbImg"].ToString();
																																model.lx= dt.Rows[n]["lx"].ToString();
																												if(dt.Rows[n]["xj"].ToString()!="")
				{
					model.xj=int.Parse(dt.Rows[n]["xj"].ToString());
				}
																																				model.customId= dt.Rows[n]["customId"].ToString();
																																model.yyDate1= dt.Rows[n]["yyDate1"].ToString();
																																model.yyDate2= dt.Rows[n]["yyDate2"].ToString();
																																model.xxDate1= dt.Rows[n]["xxDate1"].ToString();
																																model.xxDate2= dt.Rows[n]["xxDate2"].ToString();
																												if(dt.Rows[n]["money"].ToString()!="")
				{
					model.money=decimal.Parse(dt.Rows[n]["money"].ToString());
				}
																																				model.yyZt= dt.Rows[n]["yyZt"].ToString();
																												if(dt.Rows[n]["schoolid"].ToString()!="")
				{
					model.schoolid=int.Parse(dt.Rows[n]["schoolid"].ToString());
				}
																																				model.managecity= dt.Rows[n]["managecity"].ToString();
																																model.mprovince= dt.Rows[n]["mprovince"].ToString();
																																model.managearea= dt.Rows[n]["managearea"].ToString();
																																model.schoolname= dt.Rows[n]["schoolname"].ToString();
																																model.notice= dt.Rows[n]["notice"].ToString();
																												if(dt.Rows[n]["man"].ToString()!="")
				{
					model.man=decimal.Parse(dt.Rows[n]["man"].ToString());
				}
																																if(dt.Rows[n]["shippingfee"].ToString()!="")
				{
					model.shippingfee=decimal.Parse(dt.Rows[n]["shippingfee"].ToString());
				}
																																				model.shoptag= dt.Rows[n]["shoptag"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		
		
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere, params SqlParameter[] parameters)
		{
			return dal.GetRecordCount(strWhere, parameters);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params SqlParameter[] parameters)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex, parameters);
		}

        /// <summary>
        /// 分页获取数据列表,联表查询
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string unionTable, string unionColumns, params SqlParameter[] parameters)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, unionTable, unionColumns, parameters);
        }

        /// <summary>
        /// 不分页获取数据列表,联表查询
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, string unionTable, string unionColumns, params SqlParameter[] parameters)
        {
            return dal.GetListByPage(strWhere, orderby, unionTable, unionColumns, parameters);
        }
		
		
		
		
#endregion
   
	}
}