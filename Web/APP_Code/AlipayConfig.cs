using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    public class Config
    {
        #region 字段
        private static string partner = "";
        private static string key = "";
        private static string private_key = "";
        private static string public_key = "";
        private static string input_charset = "";
        private static string sign_type = "";
        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "2088721840849014";
            //交易安全检验码，由数字和字母组成的32位字符串
            //如果签名方式设置为“MD5”时，请设置该参数
            key = "ruktcr40er8286ifw7imj8rmzgu1s24h";
            //商户的私钥
            //如果签名方式设置为“0001”时，请设置该参数
            private_key = @"";

            //支付宝的公钥
            //如果签名方式设置为“0001”时，请设置该参数
            public_key = @"";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑




            //如果签名方式设置为“0001”时，请设置该参数
            private_key = @"MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDARwT5/blJDLwj
USMKBWtMLTFGJxMwGXlaizgxuWQNaiTDRnrwAM8suQ4v9Y9p7tr02BF04w6YG4sM
Opov4pJnUAvD6sYDQb3ZMPnpBgjgkiENpStKEP9XiQQVtwf8y7CzzCXDRGRrsDJm
J5rhXrpNTMbRsOdRlO0wklOmld9L+qkTgqDQzEVv7CEELDKJwxWzIcDZmYGs88DM
ROJ3WI3ogt22QqCz3tTcLsbPa4H1flQFKE0bmAjIRXS2Vv4L0n7crW/sIPY/JuzY
kbv6iURcigd8ee2irxLRbqFXEaywtHV4N3S1/OJuIwfoXr1N07TIQd4rliR2xofk
LMISoxCJAgMBAAECggEAFahqQRZ5Rmcu0fOTtM9DdMMqZ7KDEMntx2sjG0a8pF4u
YeiQdHRC4dC+blyEmPQUqbuky7u/qxZ/JRN8xqQIxaZYjOrm/vrqvYosvDi3y0Pq
gTT3mVIs0NlYInIJbkorTzVRk5sijJa+No+DfJtE9OwPAROiGqhhxzTUQ1FiY5ZY
DmGY7lkMO7LNOQPz2Ibj7Coe8sP+mpZRMXs/yxed4/AP+rU5RfQ2QYXMDt3sWcWi
vaaW8b2w+i4KshdAAEvTzplNwvKuyhbINtVAzG/Q/vt5u0dBzJPkPmwgXwFmpDkn
To80KqvgbCAEd5rmaAdLYkPSzCUc9ARFxgT+xP0zWQKBgQD773w2xmL7wggdmttP
iKU4htNwqZTdFYRy82PjaeC7pO54ZE1kGhz/hRcvUKLWfo74Gikm4BWsbmSjQN6G
YSaj6RlTGe1FITFqNnyiwFqozVVNqNTalEqkdq0/bvebkADkQzdKaxS5g6Lj1vr/
EWLU8vOVe2Pu5QyQSRs20CT40wKBgQDDYSQxTsyE0M+o1hkGFTR1hArKFof1lNYr
Yh9xjPfkLHwxWCiP7Y8x33KsWVTMxFbA/0W8LDp7JoScdv+SzSXr7ewLwBWHwMHC
P2eT7qFGozvqEt1sz6JW1M/9TGa4OVSh7qduaAki4b8HKKV+dsgCHH6W7NFqukIf
wPsLbwV3swKBgQD2bEY8MYpKJHzZsEnJnqe1BbO1ZDo2kcBuy4CtxTdLc0TKP5mv
SxeIGz8VSbMtSLdBGB2eZ9rrQUNwp5fBKy+nbe4Waaq6ToBOGqOIcct7hvRkNLqW
Xiwwd+B3xmutHoqwuspPITQxTP+8CeCSMwhPsJ/vW7Tgy+uhCdDzqV4wfwKBgHEZ
4MuyY+5Wun9wQNgmmlGU+HH4DQh6+mfuy2j+Q9oQbmxaLlDzIjuqsEVZCR/oYJgk
rge6SrhTmdzBfj1LCLLE7in3Lf+B9CgwcBNQxoePovVjqk58++rsEuL8wVHPzlBX
SRE+pFtO9zh7rSHCPRIL0LQpryjrXa/oFOuPf0jFAoGBAIuMzDi7WOiZOxz6mqmJ
55rLhoa8uVNGg6mwAowj5gGfXTvYqNI9jWY+GoxrnRB+yBC2T1/+ccMXTchTs8hP
Jjsr/eBTHc1KQ3Pvz0mOu3tNL7HEEe4EzcJpGotpxT7CN2J5HKWTLuXCRXCDSZOh
RAWXGCYkAJ2JvPVlLSyNr0i9";

            //支付宝的公钥
            //如果签名方式设置为“0001”时，请设置该参数
            //public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnUQvP/sDsFuWEi5fUCHnBzqCN3HrMaRN8oEuUAn96wbX95CLimUHBHbiWkUzPGMSxpNL2b/HcpOx1YpNPoLwb+/3HEzkW89fqWtytFEggaZ9Bcxt82jb6FAIz70ftfTo3HTxjaYq38vW4erGFMjTyMu9+ZHG6nBztxO7ipm8fIZe2z9+A110hlf2o8ykzzoHqRVjZdf90A4otzluNKG6fCJ6veFGoJDYaVNfObGFPGkPNx6VdBj0Xjo6NRqFmHmdrc1Zrdql+/64XK/LGs2ckUAfrJ3/YUPgzylUeIP9lvuMxTPDI4zX8Pz+DwUcv7+FIN7ooO0YfZxIhbppJ0/0GwIDAQAB";//rsa2
            public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnMZa3HbYp3iK1GNdO4wgWLnpo3FOJYim8QrzhTatE6al7+Gz5WuaUpJEIV4CcFd9lW1n0XuUUIKDznXp4SaX0Yz/J9pA5WQ0Qoq3OwcwmyYGm58VTuF2Kqnu4AnD27z4CsrArvyp760ijgRPEU1CUQLXEvRLV4tvBCukZ3Sx3hRuJvRF3prc7m+GtehkstZUc38os9DqNJE2yBPj6Ae1mXE+Se26vdmQfykyXeQjFpZ4cdELsJAvoHp1HzSQ8l+zCCcndTI/RCOtSensb2wMXSQ1zhSmYjEXtEpPpTZcO5Js9nvjr0/i9hp6Eao0P5ppMtjO2TX3uvFPb5SRVBUACwIDAQAB";
            //public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwEcE+f25SQy8I1EjCgVrTC0xRicTMBl5Wos4MblkDWokw0Z68ADPLLkOL/WPae7a9NgRdOMOmBuLDDqaL+KSZ1ALw+rGA0G92TD56QYI4JIhDaUrShD/V4kEFbcH/Muws8wlw0Rka7AyZiea4V66TUzG0bDnUZTtMJJTppXfS/qpE4Kg0MxFb+whBCwyicMVsyHA2ZmBrPPAzETid1iN6ILdtkKgs97U3C7Gz2uB9X5UBShNG5gIyEV0tlb+C9J+3K1v7CD2Pybs2JG7+olEXIoHfHntoq8S0W6hVxGssLR1eDd0tfzibiMH6F69TdO0yEHeK5YkdsaH5CzCEqMQiQIDAQAB";
            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：0001(RSA)、MD5
            sign_type = "RSA2";
            //无线的产品中，签名方式为rsa时，sign_type需赋值为0001而不是RSA



        }

        #region 属性
        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设交易安全校验码
        /// </summary>
        public static string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 获取或设置商户的私钥
        /// </summary>
        public static string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        /// <summary>
        /// 获取或设置支付宝的公钥
        /// </summary>
        public static string Public_key
        {
            get { return public_key; }
            set { public_key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }
        #endregion
    }
}