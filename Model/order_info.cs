
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
	 	//order_info
		public class order_info
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
		/// serialNumber
        /// </summary>		
		private string _serialnumber;
        public string serialNumber
        {
            get{ return _serialnumber; }
            set{ _serialnumber = value; }
        }        
		/// <summary>
		/// facility
        /// </summary>		
		private int _facility;
        public int facility
        {
            get{ return _facility; }
            set{ _facility = value; }
        }        
		/// <summary>
		/// port
        /// </summary>		
		private int _port;
        public int port
        {
            get{ return _port; }
            set{ _port = value; }
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
		/// discount
        /// </summary>		
		private decimal _discount;
        public decimal discount
        {
            get{ return _discount; }
            set{ _discount = value; }
        }        
		/// <summary>
		/// customid
        /// </summary>		
		private string _customid;
        public string customid
        {
            get{ return _customid; }
            set{ _customid = value; }
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
		/// statuses
        /// </summary>		
		private int _statuses;
        public int statuses
        {
            get{ return _statuses; }
            set{ _statuses = value; }
        }        
		/// <summary>
		/// duration
        /// </summary>		
		private int _duration;
        public int duration
        {
            get{ return _duration; }
            set{ _duration = value; }
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
		/// stippleid
        /// </summary>		
		private int _stippleid;
        public int stippleid
        {
            get{ return _stippleid; }
            set{ _stippleid = value; }
        }        
		   
	}
}