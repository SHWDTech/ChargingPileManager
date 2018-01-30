
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
	 	//t_role
		public class t_role
	{
   		     
      	/// <summary>
		/// roleId
        /// </summary>		
		private int _roleid;
        public int roleId
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		/// <summary>
		/// name
        /// </summary>		
		private string _name;
        public string name
        {
            get{ return _name; }
            set{ _name = value; }
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
		/// ishide
        /// </summary>		
		private int _ishide;
        public int ishide
        {
            get{ return _ishide; }
            set{ _ishide = value; }
        }        
		   
	}
}