

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
	 	//V_order_details
		public partial class V_order_details
	{
   		     
		private readonly System.DAL.V_order_details dal=new System.DAL.V_order_details();
		public V_order_details()
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
		public bool Exists()
		{
			return dal.Exists();
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(System.Model.V_order_details model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(System.Model.V_order_details model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			
			return dal.Delete();
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public System.Model.V_order_details GetModel()
		{
			
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public System.Model.V_order_details GetModelByCache()
		//{
		//	
		//	string CacheKey = "V_order_detailsModel-" + ;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel();
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (System.Model.V_order_details)objModel;
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
		public List<System.Model.V_order_details> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		
		/// <summary>
        /// 获得数据列表
        /// </summary>
        public List<System.Model.V_order_details> GetModelList(string strWhere, params SqlParameter[] parameters)
        {
            DataSet ds = dal.GetList(strWhere, parameters);
            return DataTableToList(ds.Tables[0]);
        }
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<System.Model.V_order_details> DataTableToList(DataTable dt)
		{
			List<System.Model.V_order_details> modelList = new List<System.Model.V_order_details>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				System.Model.V_order_details model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new System.Model.V_order_details();					
													if(dt.Rows[n]["id"].ToString()!="")
				{
					model.id=int.Parse(dt.Rows[n]["id"].ToString());
				}
																																if(dt.Rows[n]["duration"].ToString()!="")
				{
					model.duration=int.Parse(dt.Rows[n]["duration"].ToString());
				}
																																				model.ftype= dt.Rows[n]["ftype"].ToString();
																																model.portno= dt.Rows[n]["portno"].ToString();
																																model.fno= dt.Rows[n]["fno"].ToString();
																																model.phone= dt.Rows[n]["phone"].ToString();
																																model.sname= dt.Rows[n]["sname"].ToString();
																																model.serialNumber= dt.Rows[n]["serialNumber"].ToString();
																												if(dt.Rows[n]["facility"].ToString()!="")
				{
					model.facility=int.Parse(dt.Rows[n]["facility"].ToString());
				}
																																if(dt.Rows[n]["port"].ToString()!="")
				{
					model.port=int.Parse(dt.Rows[n]["port"].ToString());
				}
																																if(dt.Rows[n]["price"].ToString()!="")
				{
					model.price=decimal.Parse(dt.Rows[n]["price"].ToString());
				}
																																if(dt.Rows[n]["discount"].ToString()!="")
				{
					model.discount=decimal.Parse(dt.Rows[n]["discount"].ToString());
				}
																																				model.customid= dt.Rows[n]["customid"].ToString();
																												if(dt.Rows[n]["pudate"].ToString()!="")
				{
					model.pudate=DateTime.Parse(dt.Rows[n]["pudate"].ToString());
				}
																																				model.paydate= dt.Rows[n]["paydate"].ToString();
																												if(dt.Rows[n]["paystatus"].ToString()!="")
				{
					model.paystatus=int.Parse(dt.Rows[n]["paystatus"].ToString());
				}
																																if(dt.Rows[n]["types"].ToString()!="")
				{
					model.types=int.Parse(dt.Rows[n]["types"].ToString());
				}
																																				model.typename= dt.Rows[n]["typename"].ToString();
																												if(dt.Rows[n]["ctype"].ToString()!="")
				{
					model.ctype=int.Parse(dt.Rows[n]["ctype"].ToString());
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