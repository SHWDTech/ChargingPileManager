
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
	 	//facility
		public class facility
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
		/// fid
        /// </summary>		
		private int _fid;
        public int fid
        {
            get{ return _fid; }
            set{ _fid = value; }
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
		/// <summary>
		/// no
        /// </summary>		
		private string _no;
        public string no
        {
            get{ return _no; }
            set{ _no = value; }
        }        
		/// <summary>
		/// statuses
        /// </summary>		
		private int _statuses;
        public int statuses
        {
            get{ return _statuses; }
            set{ _statuses = value; }
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
		/// isdel
        /// </summary>		
		private int _isdel;
        public int isdel
        {
            get{ return _isdel; }
            set{ _isdel = value; }
        }        
		/// <summary>
		/// identitycode
        /// </summary>		
		private string _identitycode;
        public string identitycode
        {
            get{ return _identitycode; }
            set{ _identitycode = value; }
        }        
		   
	}
}