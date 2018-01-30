
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
	 	//t_message
		public class t_message
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
		/// title
        /// </summary>		
		private string _title;
        public string title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
		/// <summary>
		/// memo
        /// </summary>		
		private string _memo;
        public string memo
        {
            get{ return _memo; }
            set{ _memo = value; }
        }        
		/// <summary>
		/// pudate
        /// </summary>		
		private string _pudate;
        public string pudate
        {
            get{ return _pudate; }
            set{ _pudate = value; }
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
		/// <summary>
		/// types
        /// </summary>		
		private int _types;
        public int types
        {
            get{ return _types; }
            set{ _types = value; }
        }        
		   
	}
}