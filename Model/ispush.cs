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
namespace System.Model{
	 	//ispush
		public class ispush
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// ispushvalue
        /// </summary>		
		private int _ispushvalue;
        public int ispushvalue
        {
            get{ return _ispushvalue; }
            set{ _ispushvalue = value; }
        }        
		/// <summary>
		/// device
        /// </summary>		
		private string _device;
        public string device
        {
            get{ return _device; }
            set{ _device = value; }
        }        
		/// <summary>
		/// clientType
        /// </summary>		
		private int _clienttype;
        public int clientType
        {
            get{ return _clienttype; }
            set{ _clienttype = value; }
        }        
		/// <summary>
		/// customId
        /// </summary>		
		private string _customid;
        public string customId
        {
            get{ return _customid; }
            set{ _customid = value; }
        }        
		   
	}
}