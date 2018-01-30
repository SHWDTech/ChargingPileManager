
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
	 	//t_img
		public class t_img
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
		/// pudate
        /// </summary>		
		private string _pudate;
        public string pudate
        {
            get{ return _pudate; }
            set{ _pudate = value; }
        }        
		/// <summary>
		/// img
        /// </summary>		
		private string _img;
        public string img
        {
            get{ return _img; }
            set{ _img = value; }
        }        
		/// <summary>
		/// tzId
        /// </summary>		
		private string _tzid;
        public string tzId
        {
            get{ return _tzid; }
            set{ _tzid = value; }
        }        
		/// <summary>
		/// lx
        /// </summary>		
		private string _lx;
        public string lx
        {
            get{ return _lx; }
            set{ _lx = value; }
        }        
		/// <summary>
		/// applx
        /// </summary>		
		private int _applx;
        public int applx
        {
            get{ return _applx; }
            set{ _applx = value; }
        }        
		/// <summary>
		/// platformLx
        /// </summary>		
		private int _platformlx;
        public int platformLx
        {
            get{ return _platformlx; }
            set{ _platformlx = value; }
        }        
		   
	}
}