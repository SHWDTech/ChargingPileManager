

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
	 	//facility_port
		public partial class facility_port
	{
   		     
		private readonly System.DAL.facility_port dal=new System.DAL.facility_port();
		public facility_port()
		{}
		
		
		/// <summary>
        /// 获取最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(System.Model.facility_port model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.facility_port model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public System.Model.facility_port GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public System.Model.facility_port GetModelByCache(int id)
		//{
		//	
		//	string CacheKey = "facility_portModel-" + id;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(id);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (System.Model.facility_port)objModel;
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
		public List<System.Model.facility_port> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		
		/// <summary>
        /// 获得数据列表
        /// </summary>
        public List<System.Model.facility_port> GetModelList(string strWhere, params SqlParameter[] parameters)
        {
            DataSet ds = dal.GetList(strWhere, parameters);
            return DataTableToList(ds.Tables[0]);
        }
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<System.Model.facility_port> DataTableToList(DataTable dt)
		{
			List<System.Model.facility_port> modelList = new List<System.Model.facility_port>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				System.Model.facility_port model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new System.Model.facility_port();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["fid"].ToString()!="")
				{
					model.fid=int.Parse(dt.Rows[n]["fid"].ToString());
				}
																																				model.no= dt.Rows[n]["no"].ToString();
																																model.qrimg= dt.Rows[n]["qrimg"].ToString();
																												if(dt.Rows[n]["statuses"].ToString()!="")
				{
					model.statuses=int.Parse(dt.Rows[n]["statuses"].ToString());
				}
																																if(dt.Rows[n]["pudate"].ToString()!="")
				{
					model.pudate=DateTime.Parse(dt.Rows[n]["pudate"].ToString());
				}
																																if(dt.Rows[n]["isdel"].ToString()!="")
				{
					model.isdel=int.Parse(dt.Rows[n]["isdel"].ToString());
				}
																																				model.toid= dt.Rows[n]["toid"].ToString();
																												if(dt.Rows[n]["sid"].ToString()!="")
				{
					model.sid=int.Parse(dt.Rows[n]["sid"].ToString());
				}
																																				model.identitycode= dt.Rows[n]["identitycode"].ToString();
																												if(dt.Rows[n]["isEmploy"].ToString()!="")
				{
					model.isEmploy=int.Parse(dt.Rows[n]["isEmploy"].ToString());
				}
																										
				
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