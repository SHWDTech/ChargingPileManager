
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
	 	//verification_code
		public class verification_code
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
		/// verificationMode
        /// </summary>		
		private string _verificationmode;
        public string verificationMode
        {
            get{ return _verificationmode; }
            set{ _verificationmode = value; }
        }        
		/// <summary>
		/// code
        /// </summary>		
		private string _code;
        public string code
        {
            get{ return _code; }
            set{ _code = value; }
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
		/// edate
        /// </summary>		
		private DateTime _edate;
        public DateTime edate
        {
            get{ return _edate; }
            set{ _edate = value; }
        }        
		/// <summary>
		/// type
        /// </summary>		
		private int _type;
        public int type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
		   
	}
}