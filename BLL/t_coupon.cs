﻿

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
	 	//t_coupon
		public partial class t_coupon
	{
   		     
		private readonly System.DAL.t_coupon dal=new System.DAL.t_coupon();
		public t_coupon()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string yhjId)
		{
			return dal.Exists(yhjId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(System.Model.t_coupon model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.t_coupon model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string yhjId)
		{
			
			return dal.Delete(yhjId);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public System.Model.t_coupon GetModel(string yhjId)
		{
			
			return dal.GetModel(yhjId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public System.Model.t_coupon GetModelByCache(string yhjId)
		//{
		//	
		//	string CacheKey = "t_couponModel-" + yhjId;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(yhjId);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (System.Model.t_coupon)objModel;
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
		public List<System.Model.t_coupon> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		
		/// <summary>
        /// 获得数据列表
        /// </summary>
        public List<System.Model.t_coupon> GetModelList(string strWhere, params SqlParameter[] parameters)
        {
            DataSet ds = dal.GetList(strWhere, parameters);
            return DataTableToList(ds.Tables[0]);
        }
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<System.Model.t_coupon> DataTableToList(DataTable dt)
		{
			List<System.Model.t_coupon> modelList = new List<System.Model.t_coupon>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				System.Model.t_coupon model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new System.Model.t_coupon();					
																	model.yhjId= dt.Rows[n]["yhjId"].ToString();
																												if(dt.Rows[n]["money"].ToString()!="")
				{
					model.money=int.Parse(dt.Rows[n]["money"].ToString());
				}
																																if(dt.Rows[n]["man"].ToString()!="")
				{
					model.man=int.Parse(dt.Rows[n]["man"].ToString());
				}
																																				model.usersId= dt.Rows[n]["usersId"].ToString();
																																model.date1= dt.Rows[n]["date1"].ToString();
																																model.date2= dt.Rows[n]["date2"].ToString();
																												if(dt.Rows[n]["num"].ToString()!="")
				{
					model.num=int.Parse(dt.Rows[n]["num"].ToString());
				}
																																				model.pudate= dt.Rows[n]["pudate"].ToString();
																																model.title= dt.Rows[n]["title"].ToString();
																						
				
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