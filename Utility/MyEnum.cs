using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class MyEnum
    {
        #region 性别枚举
/// <summary>
/// 性别枚举
/// </summary>
public enum GenderEnum
{
    保密 = 0,
    男 = 1,
    女 = 2
}
        #endregion

        #region 省市区类型枚举
        /// <summary>
        /// 省市区类型枚举
        /// </summary>
        public enum PlaceEnum
        {
            省 = 1,
            市 = 2,
            区 = 3
        }
        #endregion

        #region 操作结果枚举
        /// <summary>
        /// 操作结果枚举
        /// </summary>
        public enum ResultEnum
        {
            成功 = 1, 失败 = 0, 系统错误 = 2
        }
        #endregion


        #region 验证码验证方式
        /// <summary>
        /// 验证方式
        /// </summary>
        public enum verificationTypeEnum {
            手机号验证 = 1, 邮箱验证 = 2 
        }
        #endregion


        #region 轮播图类型
        /// <summary>
        /// 轮播图类型(跳转类型)
        /// </summary> 
        public enum SlideshowType
        {
            商品 = 1,
            商家 = 2,
            链接 = 3
        }
        #endregion

        #region 财务变动方向枚举
        /// <summary>
        /// 财务变动方向枚举
        /// </summary>
        public enum FinanceDirectionEnum
        {
            收入 = 1,
            支出 = 2
        }
        #endregion

        #region 账号状态枚举
        /// <summary>
        /// 账号状态枚举
        /// </summary>
        public enum AccountStatusEnum
        {
            正常 = 1,
            禁用 = 2
        }
        #endregion

        #region 财务来源枚举
        /// <summary>
        /// 财务来源枚举
        /// </summary>
        public enum FinanceSourceTypeEnum
        {
            充值 = 1,
            提成 = 2,
            购物 = 3,
            推广 = 4,
            兑换 = 5,
            退还 = 6,
            提现 = 7,
            服务费 = 8,
            注册 = 9,
            评价 = 10,
            用户好评 = 11
        }
        #endregion

        #region 财务类型枚举
        /// <summary>
        /// 财务类型枚举
        /// </summary>
        public enum FinanceTypeEnum
        {
            积分 = 1,
            现金 = 2,
            经验 = 3
        }
        #endregion

        #region 属性填充方式枚举
        /// <summary>
        /// 属性填充方式枚举
        /// </summary>
        public enum AttrTypeEnum
        {
            文本 = 1,
            单选 = 2,
            多选 = 3
        }
        #endregion

        #region 审核状态枚举
        /// <summary>
        /// 审核状态枚举
        /// </summary>
        public enum AuditStatusEnum
        {
            审核中 = 1,
            审核通过 = 2,
            审核不通过 = 3
        }
        #endregion

        #region 特殊角色枚举
        /// <summary>
        /// 特殊角色枚举
        /// </summary>
        public enum RoleEnum
        {
            系统管理员 = 1,
            商家 = 2
        }
        #endregion

        #region 缩略图尺寸比例枚举
        /// <summary>
        /// 缩略图尺寸比例枚举
        /// </summary>
        public enum ImageSizeEnum
        {
            身份证扫描件宽 = 500,
            身份证扫描件高 = 300,
            //商城
            广告图宽 = 900,
            广告图高 = 416,
            优惠券宽 = 320,
            优惠券高 = 120,
            积分商品宽 = 300,
            积分商品高 = 300,
            商品宽 = 750,
            商品高 = 580,
            分类图标宽 = 240,
            分类图标高 = 200,
            新闻图宽 = 750,
            新闻图高 = 600,
            头像宽 = 200,
            头像高 = 200,
            //发现
            动态宽 = 300,
            动态高 = 300,
            //服务
            服务宽 = 300,
            服务高 = 300
        }
        #endregion

        #region 商品状态枚举
        /// <summary>
        /// 商品状态枚举
        /// </summary>
        public enum ProductStatusEnum
        {
            上架 = 1,
            下架 = 2
        }
        #endregion

        #region 商品审核状态
        /// <summary>
        /// 商品审核状态
        /// </summary>
        public enum ProductAuditStatusEnum
        {
            待审核 = 0,
            通过审核 = 1,
            不通过审核 = 2
        }
        #endregion


        #region 优惠券类型枚举
        /// <summary>
        /// 优惠券类型枚举
        /// </summary>
        public enum CouponTypeEnum
        {
            通用优惠券 = 1,//满额减免
            代金券 = 2//抵扣金额
        }
        #endregion

        #region 收藏类型枚举
        /// <summary>
        /// 收藏类型枚举
        /// </summary>
        public enum CollectTypeEnum
        {
            商品 = 1,
            工程 = 2,
            店铺 = 3
        }
        #endregion

        #region 排序方式枚举
        /// <summary>
        /// 排序方式枚举
        /// </summary>
        public enum SortEnum
        {
            销量 = 1,
            价格从高到低 = 2,
            价格从低到高 = 3,
            租赁 = 4,
            时间 = 5,
            区域 = 6,
            折扣从低到高 = 7,
            最新 = 8,
            类别 = 9,
            综合排序 = 10,
            服务次数 = 11,
            评价满意度 = 12,
            距离远到近 = 13,
            距离近到远 = 14
        }
        #endregion

        #region 支付方式枚举
        /// <summary>
        /// 支付方式枚举
        /// </summary>
        public enum PayWayEnum
        {
            支付宝 = 1,
            微信 = 2,
            余额 = 3
        }
        #endregion

        #region 支付项枚举
        /// <summary>
        /// 支付项枚举
        /// </summary>
        public enum PayTargetEnum
        {
            订单 = 1,
            充值 = 2,
            提现 = 3,
            服务费 = 4,
            加价 = 5,
            保证金 = 6
        }
        #endregion

        #region 提现/兑换/支付等状态枚举
        /// <summary>
        /// 提现/兑换/支付等状态枚举
        /// </summary>
        public enum PayStatusEnum
        {
            未完成 = 1,
            已完成 = 2,
            已取消 = 3
        }
        #endregion

        #region 订单状态枚举
        /// <summary>
        /// 订单状态枚举
        /// </summary>
        public enum OrderStatusEnum
        {
            交易关闭 = 10,
            待付款 = 1,
            待发货 = 2,
            待收货 = 3,
            待评价 = 4,
            已评价 = 5
        }
        #endregion

        #region 订单处理行为枚举
        /// <summary>
        /// 订单处理行为枚举
        /// </summary>
        public enum OrderHandleStatusEnum
        {
            关闭交易 = 10,
            付款 = 2,
            发货 = 3,
            确认收货 = 4,
            评价 = 5
        }
        #endregion

        #region 广告位枚举
        /// <summary>
        /// 广告位枚举
        /// </summary>
        public enum AdPositionEnum
        {
            首页 = 1,//app
            PC首页 = 2,//pc首页
        }
        #endregion

        #region 广告类型枚举
        /// <summary>
        /// 广告类型枚举
        /// </summary>
        public enum AdTypeEnum
        {
            商品详情 = 1,
            品牌商品 = 2,
            跳转链接 = 3,
            场馆详情 = 4,
            品牌列表 = 5
        }
        #endregion

        #region 消息类型枚举
        /// <summary>
        /// 消息类型枚举
        /// </summary>
        public enum MessageTypeEnum
        {
            平台消息 = 1,
            订单消息 = 2,
            服务消息 = 3,
            帖子消息 = 4
        }
        #endregion

        #region 第三方登录枚举
        /// <summary>
        /// 第三方登录枚举
        /// </summary>
        public enum ThirdPartyEnum
        {
            qq = 1,
            wechat = 2,
            sinablog = 3
        }
        #endregion

        #region 二手商品类型枚举
        /// <summary>
        /// 二手商品类型枚举
        /// </summary>
        public enum SecondHandTypeEnum
        {
            设备租赁 = 1,
            二手买卖 = 2
        }
        #endregion

        //----------------------------------------------------发现-----------------------------------------------
        #region 点赞对象枚举
        /// <summary>
        /// 点赞对象枚举
        /// </summary>
        public enum ZanTargetEnum
        {
            动态 = 3
        }
        #endregion

        //----------------------------------------------------服务-----------------------------------------------
        #region 服务状态枚举
        /// <summary>
        /// 服务状态枚举
        /// </summary>
        public enum ServiceStatusEnum
        {
            已取消 = 10,
            竞标中 = 1,
            待确认 = 2,
            待付款 = 3,
            待完成 = 4,
            待评价 = 5,
            已评价 = 6,
            已退款 = 7,
        }
        #endregion



        //----------------------------------------------------退款-----------------------------------------------
        #region 退款状态枚举
        /// <summary>
        /// 退款状态枚举
        /// </summary>
        public enum ReimburseEnum
        {
            已取消 = 10,
            待退款 = 1,
            //待审核 = 1,
            //已审核 = 2,
            //待退货 = 4,
            //已退货 = 5, 
            已退款 = 6,

        }
        #endregion


        #region 处理服务行为枚举
        /// <summary>
        /// 处理服务行为枚举
        /// </summary>
        public enum ServiceHandleStatusEnum
        {
            取消 = 10,
            确认支付 = 4,
            //完成 = 4
        }
        #endregion

        #region 发票状态枚举
        /// <summary>
        /// 发票状态枚举
        /// </summary>
        public enum ReceiptStatusEnum
        {
            未开票 = 1,
            申请中 = 2,
            已开票 = 3
        }
        #endregion

        #region 认证类型枚举
        /// <summary>
        /// 认证类型枚举
        /// </summary>
        public enum AuthenTypeEnum
        {
            个人 = 1,
            企业 = 2
        }
        #endregion

        #region 保证金类型枚举
        /// <summary>
        /// 保证金类型枚举
        /// </summary>
        public enum DepositTypeEnum
        {
            临时 = 1,
            永久 = 2
        }
        #endregion

        #region 工程师状态枚举
        /// <summary>
        /// 工程师状态枚举
        /// </summary>
        public enum EngineerStatusEnum
        {
            未交保证金 = 1,
            已交保证金 = 2
        }
        #endregion

        #region 竞标状态枚举
        /// <summary>
        /// 竞标状态枚举
        /// </summary>
        public enum CompetitionStatusEnum
        {
            已取消 = 10,
            竞标中 = 1,
            被选中 = 2,
            被拒绝 = 3,
            待完成 = 4,
            用户确认完成 = 5,
            工程师确认完成 = 6,
            已完成 = 7,
            已评价 = 8
        }
        #endregion

        #region 竞标处理行为枚举
        /// <summary>
        /// 竞标处理行为枚举
        /// </summary>
        public enum CompetitionHandleStatusEnum
        {
            取消 = 10,
            选中 = 2,
            拒绝 = 3,
            确认订单 = 4,
            用户确认完成 = 5,
            工程师确认完成 = 6
        }
        #endregion

        #region 发票类型枚举
        /// <summary>
        /// 发票类型枚举
        /// </summary>
        public enum ReceiptTypeEnum
        {
            普通发票 = 1,
            增值税发票 = 2
        }
        #endregion

        #region 开票方式枚举
        /// <summary>
        /// 开票方式枚举
        /// </summary>
        public enum ReceiptMethodEnum
        {
            纸质发票 = 1,
            电子发票 = 2
        }
        #endregion

        #region 发票抬头枚举
        /// <summary>
        /// 发票抬头枚举
        /// </summary>
        public enum ReceiptTargetEnum
        {
            个人 = 1,
            公司 = 2
        }
        #endregion

        #region 时间筛选枚举
        /// <summary>
        /// 时间筛选枚举
        /// </summary>
        public enum DateChooseEnum
        {
            一周内 = 1,
            两周内 = 2,
            一个月内 = 3,
            一天内 = 4,
            三天内 = 5,
            五天内 = 6,
            七天内 = 7
        }
        #endregion

        #region 行为对象枚举
        /// <summary>
        /// 行为对象枚举
        /// </summary>
        public enum ActionTargetEnum
        {
            用户 = 1,
            工程师 = 2
        }
        #endregion

        #region 服务申诉类型枚举
        /// <summary>
        /// 服务申诉类型枚举
        /// </summary>
        public enum PetitionTypeEnum
        {
            工程师服务态度 = 1,
            工程师技术能力 = 2,
            准时到达率 = 3,
            订单未搞定 = 4
        }
        #endregion


        #region 申诉状态枚举
        /// <summary>
        /// 申诉状态枚举
        /// </summary>
        public enum PetitionStatusEnum
        {
            申诉中 = 1,
            已申诉 = 2,
            被拒绝 = 3
        }
        #endregion
        //----------------------------------------------------工程-----------------------------------------------
        #region 工程状态枚举
        /// <summary>
        /// 工程状态枚举
        /// </summary>
        public enum ProjectStatusEnum
        {
            未托管 = 1,
            已托管 = 2
        }
        #endregion


        //----------------------------------------------------聊天-----------------------------------------------

        #region 用户聊天状态枚举
        /// <summary>
        /// 用户聊天状态枚举
        /// </summary>
        public enum ChatStatusEnum
        {
            在线 = 0,
            离线 = 1,
            下线 = 2
        }
        #endregion


        //----------------------------------------------------店铺-----------------------------------------------
        #region 店铺认证状态

        /// <summary>
        /// 店铺认证状态
        /// </summary>
        public enum ShopStatus
        {
            未认证 = 0,
            已认证 = 1
        }
        #endregion


        #region 转换方法

        /// <summary>
        /// 获取枚举名
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns>枚举值</returns>
        private static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// 返回枚举名
        /// </summary>
        /// <param name="T">枚举类型</param>
        /// <param name="code">枚举值</param>
        /// <returns></returns>
        public static string enumname(Type T, int code)
        {
            string name2 = "";
            if (code != null && code != 0)
            {
                name2 = Enum.Parse(T, code.ToString()).ToString();
            }
            return name2;
        }
        #endregion
    }
}
