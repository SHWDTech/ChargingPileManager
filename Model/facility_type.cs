
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
	 	//facility_type
		public class facility_type
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
		/// tyoe
        /// </summary>		
		private string _tyoe;
        public string tyoe
        {
            get{ return _tyoe; }
            set{ _tyoe = value; }
        }        
		/// <summary>
		/// time
        /// </summary>		
		private int _time;
        public int time
        {
            get{ return _time; }
            set{ _time = value; }
        }        
		/// <summary>
		/// price
        /// </summary>		
		private decimal _price;
        public decimal price
        {
            get{ return _price; }
            set{ _price = value; }
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
		/// discount
        /// </summary>		
		private decimal _discount;
        public decimal discount
        {
            get{ return _discount; }
            set{ _discount = value; }
        }        
		   
	}
}