
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
	 	//repairs
		public class repairs
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
		/// facility
        /// </summary>		
		private string _facility;
        public string facility
        {
            get{ return _facility; }
            set{ _facility = value; }
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
		/// cause
        /// </summary>		
		private string _cause;
        public string cause
        {
            get{ return _cause; }
            set{ _cause = value; }
        }        
		/// <summary>
		/// pudate
        /// </summary>		
		private DateTime _pudate;
        public DateTime pudate
        {
            get{ return _pudate; }
            set{ _pudate = value; }
        }        
		/// <summary>
		/// toid
        /// </summary>		
		private string _toid;
        public string toid
        {
            get{ return _toid; }
            set{ _toid = value; }
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