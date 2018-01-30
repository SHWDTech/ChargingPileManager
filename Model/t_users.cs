
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
	 	//t_users
		public class t_users
	{
   		     
      	/// <summary>
		/// usersId
        /// </summary>		
		private string _usersid;
        public string usersId
        {
            get{ return _usersid; }
            set{ _usersid = value; }
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
		/// phone
        /// </summary>		
		private string _phone;
        public string phone
        {
            get{ return _phone; }
            set{ _phone = value; }
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
		/// pwd
        /// </summary>		
		private string _pwd;
        public string pwd
        {
            get{ return _pwd; }
            set{ _pwd = value; }
        }        
		/// <summary>
		/// roleId
        /// </summary>		
		private string _roleid;
        public string roleId
        {
            get{ return _roleid; }
            set{ _roleid = value; }
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
		/// imgUrl
        /// </summary>		
		private string _imgurl;
        public string imgUrl
        {
            get{ return _imgurl; }
            set{ _imgurl = value; }
        }        
		/// <summary>
		/// adress
        /// </summary>		
		private string _adress;
        public string adress
        {
            get{ return _adress; }
            set{ _adress = value; }
        }        
		/// <summary>
		/// jingdu
        /// </summary>		
		private string _jingdu;
        public string jingdu
        {
            get{ return _jingdu; }
            set{ _jingdu = value; }
        }        
		/// <summary>
		/// weidu
        /// </summary>		
		private string _weidu;
        public string weidu
        {
            get{ return _weidu; }
            set{ _weidu = value; }
        }        
		/// <summary>
		/// jieshao
        /// </summary>		
		private string _jieshao;
        public string jieshao
        {
            get{ return _jieshao; }
            set{ _jieshao = value; }
        }        
		/// <summary>
		/// hbImg
        /// </summary>		
		private string _hbimg;
        public string hbImg
        {
            get{ return _hbimg; }
            set{ _hbimg = value; }
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
		/// xj
        /// </summary>		
		private int _xj;
        public int xj
        {
            get{ return _xj; }
            set{ _xj = value; }
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
		/// yyDate1
        /// </summary>		
		private string _yydate1;
        public string yyDate1
        {
            get{ return _yydate1; }
            set{ _yydate1 = value; }
        }        
		/// <summary>
		/// yyDate2
        /// </summary>		
		private string _yydate2;
        public string yyDate2
        {
            get{ return _yydate2; }
            set{ _yydate2 = value; }
        }        
		/// <summary>
		/// xxDate1
        /// </summary>		
		private string _xxdate1;
        public string xxDate1
        {
            get{ return _xxdate1; }
            set{ _xxdate1 = value; }
        }        
		/// <summary>
		/// xxDate2
        /// </summary>		
		private string _xxdate2;
        public string xxDate2
        {
            get{ return _xxdate2; }
            set{ _xxdate2 = value; }
        }        
		/// <summary>
		/// money
        /// </summary>		
		private decimal _money;
        public decimal money
        {
            get{ return _money; }
            set{ _money = value; }
        }        
		/// <summary>
		/// yyZt
        /// </summary>		
		private string _yyzt;
        public string yyZt
        {
            get{ return _yyzt; }
            set{ _yyzt = value; }
        }        
		/// <summary>
		/// schoolid
        /// </summary>		
		private int _schoolid;
        public int schoolid
        {
            get{ return _schoolid; }
            set{ _schoolid = value; }
        }        
		/// <summary>
		/// managecity
        /// </summary>		
		private string _managecity;
        public string managecity
        {
            get{ return _managecity; }
            set{ _managecity = value; }
        }        
		/// <summary>
		/// mprovince
        /// </summary>		
		private string _mprovince;
        public string mprovince
        {
            get{ return _mprovince; }
            set{ _mprovince = value; }
        }        
		/// <summary>
		/// managearea
        /// </summary>		
		private string _managearea;
        public string managearea
        {
            get{ return _managearea; }
            set{ _managearea = value; }
        }        
		/// <summary>
		/// schoolname
        /// </summary>		
		private string _schoolname;
        public string schoolname
        {
            get{ return _schoolname; }
            set{ _schoolname = value; }
        }        
		/// <summary>
		/// notice
        /// </summary>		
		private string _notice;
        public string notice
        {
            get{ return _notice; }
            set{ _notice = value; }
        }        
		/// <summary>
		/// man
        /// </summary>		
		private decimal _man;
        public decimal man
        {
            get{ return _man; }
            set{ _man = value; }
        }        
		/// <summary>
		/// shippingfee
        /// </summary>		
		private decimal _shippingfee;
        public decimal shippingfee
        {
            get{ return _shippingfee; }
            set{ _shippingfee = value; }
        }        
		/// <summary>
		/// shoptag
        /// </summary>		
		private string _shoptag;
        public string shoptag
        {
            get{ return _shoptag; }
            set{ _shoptag = value; }
        }        
		   
	}
}