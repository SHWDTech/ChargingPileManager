
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
	 	//System_FAQ
		public class System_FAQ
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
		/// issue
        /// </summary>		
		private string _issue;
        public string issue
        {
            get{ return _issue; }
            set{ _issue = value; }
        }        
		/// <summary>
		/// answer
        /// </summary>		
		private string _answer;
        public string answer
        {
            get{ return _answer; }
            set{ _answer = value; }
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
		   
	}
}