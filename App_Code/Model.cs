using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Model 的摘要说明
/// </summary>
public class Model
{
    //
    //TODO: 商品信息实体类
    //
    public string GoodsID { set; get; } //商品id
    public string GoodsName { set; get; }//商品名称
    public string GoodsMainPhoto { set; get; }//商品主图
    public string GoodsDetailsPagelinkAddress { set; get; }//商品详情页链接地址
    public string PrimaryCategories { set; get; }//商品一级类目
    public string TaobaoLink { set; get; }//淘宝客链接
    public string Price { set; get; }//商品价格(单位：元)
    public string OriginalPrice { set; get; }//商品原来价格(单位：元)
    public string MonthlySales { set; get; }//商品月销量
    public string IncomeRatio { set; get; }//收入比率(%)
    public string Brokerage { set; get; }//佣金
    public string SellersWWID { set; get; }//卖家旺旺
    public string SellersID { set; get; }//卖家id
    public string ShopName { set; get; }//店铺名称
    public string PlatformType { set; get; }//平台类型
    public string DiscountCouponID { set; get; }//优惠券id
    public string DiscountCouponTotal { set; get; }//优惠券总量
    public string DiscountCouponSurplus { set; get; }//优惠券剩余量
    public string DiscountCouponDenomination { set; get; }//优惠券面额
    public string DiscountCouponStartTime { set; get; }//优惠券开始时间
    public string DiscountCouponEndTime { set; get; }//优惠券结束时间
    public string DiscountCouponLink { set; get; }//优惠券链接
    public string DiscountCouponPromoteLinks { set; get; }//商品优惠券推广链接
}