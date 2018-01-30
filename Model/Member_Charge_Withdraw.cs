
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
	 	//Member_Charge_Withdraw
		public class Member_Charge_Withdraw
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
		/// memberid
        /// </summary>		
		private string _memberid;
        public string memberid
        {
            get{ return _memberid; }
            set{ _memberid = value; }
        }        
		/// <summary>
		/// paytype
        /// </summary>		
		private int _paytype;
        public int paytype
        {
            get{ return _paytype; }
            set{ _paytype = value; }
        }        
		/// <summary>
		/// paystatus
        /// </summary>		
		private int _paystatus;
        public int paystatus
        {
            get{ return _paystatus; }
            set{ _paystatus = value; }
        }        
		/// <summary>
		/// typename
        /// </summary>		
		private string _typename;
        public string typename
        {
            get{ return _typename; }
            set{ _typename = value; }
        }        
		/// <summary>
		/// statusname
        /// </summary>		
		private string _statusname;
        public string statusname
        {
            get{ return _statusname; }
            set{ _statusname = value; }
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
		/// tpSerialNumber
        /// </summary>		
		private string _tpserialnumber;
        public string tpSerialNumber
        {
            get{ return _tpserialnumber; }
            set{ _tpserialnumber = value; }
        }        
		/// <summary>
		/// moneyes
        /// </summary>		
		private decimal _moneyes;
        public decimal moneyes
        {
            get{ return _moneyes; }
            set{ _moneyes = value; }
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
		/// paydate
        /// </summary>		
		private string _paydate;
        public string paydate
        {
            get{ return _paydate; }
            set{ _paydate = value; }
        }        
		/// <summary>
		/// remarks
        /// </summary>		
		private string _remarks;
        public string remarks
        {
            get{ return _remarks; }
            set{ _remarks = value; }
        }        
		   
	}
}