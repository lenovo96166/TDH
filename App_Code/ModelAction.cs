﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.IO;

using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
///ModelAction 的摘要说明
/// </summary>
public class ModelAction
{
    //读取数据

    public List<Model> ReadDataToExcel(string path, int pageNum ,string Type,string condition) 
    {
        List<Model> list = new List<Model>();
        GoodsFile goodsFile = new GoodsFile();
        List<FileInformation> filesList = goodsFile.GetAllFiles(new DirectoryInfo(path));

        //int count = ExcelCount(filesList);
        
        foreach(FileInformation fileInormation in filesList)
        {
            list = getGoodsInfoList(fileInormation);
        }

        if (Type.Equals("S"))
        {
            List<Model> searchList = new List<Model>();
            searchList = list.FindAll(o => o.GoodsName.Contains(condition));
            return GoodsPageing(searchList, pageNum);
        }
        List<Model> resList = GoodsPageing(list,pageNum);
        return resList;
    }

    private List<Model> getGoodsInfoList(FileInformation fileInformation)
    {
        List<Model> list = new List<Model>();
        DataSet dataSet = ExcelToDS(fileInformation.FilePath);
        System.Data.DataTable dt = dataSet.Tables[0];
        foreach (DataRow dr in dt.Rows) //遍历所有的行
        {
            Model model = new Model();
            model.GoodsID = dr[0].ToString();
            model.GoodsName = dr[1].ToString();
            if (System.Text.Encoding.Default.GetBytes(model.GoodsName).Length >= 60)
            {
                model.GoodsName = model.GoodsName.Substring(0, model.GoodsName.Length - 1);
            }
            model.GoodsMainPhoto = dr[2].ToString();
            model.GoodsDetailsPagelinkAddress = dr[3].ToString();
            model.PrimaryCategories = dr[4].ToString();
            model.TaobaoLink = dr[5].ToString();
            model.Price = dr[6].ToString();
            model.OriginalPrice = (Convert.ToSingle(dr[6].ToString()) + Convert.ToSingle(dr[6].ToString()) * 0.6).ToString("#0.00");
            model.MonthlySales = dr[7].ToString();
            model.IncomeRatio = dr[8].ToString();
            model.Brokerage = dr[9].ToString();
            model.SellersWWID = dr[10].ToString();
            model.SellersID = dr[11].ToString();
            model.ShopName = dr[12].ToString();
            model.PlatformType = dr[13].ToString();
            model.DiscountCouponID = dr[14].ToString();
            model.DiscountCouponTotal = dr[15].ToString();
            model.DiscountCouponSurplus = dr[16].ToString();
            model.DiscountCouponDenomination = dr[17].ToString();
            model.DiscountCouponStartTime = dr[18].ToString();
            model.DiscountCouponEndTime = dr[19].ToString();
            model.DiscountCouponLink = dr[20].ToString();
            model.DiscountCouponPromoteLinks = dr[21].ToString();
            list.Add(model);
        }   
        return list;
    }

    private List<Model> GoodsPageing(List<Model> list, int pageNum) 
    {
        List<Model> resList = new List<Model>();
        int count = list.Count > pageNum * 50 ? pageNum * 50 : list.Count;
        for (int i = (pageNum - 1) * 50; i < count; i++)
        {
            resList.Add(list[i]);
        }
        return resList;
    }

    //获取一个文档的所有商品，转DataSet
    private DataSet ExcelToDS(string Path)
    {
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        string strExcel = "";
        OleDbDataAdapter myCommand = null;
        DataSet ds = null;
        strExcel = "select * from [Page1$]";
        myCommand = new OleDbDataAdapter(strExcel, strConn);
        ds = new DataSet();
        myCommand.Fill(ds, "table1");
        return ds;
    }

    //根据sql获取商品
    private DataSet ExcelToDS(string Path , string sql)
    {
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        string strExcel = "";
        OleDbDataAdapter myCommand = null;
        DataSet ds = null;
        strExcel = "select * from [Page1$]";
        myCommand = new OleDbDataAdapter(strExcel, strConn);
        ds = new DataSet();
        myCommand.Fill(ds, "table1");
        return ds;
    }

    //根据SQL获取商品信息 . 测试后此方法低效,弃用！
    [Obsolete]
    public int ExcelCount(List<FileInformation> filesList)
    {
        int count = 0;
        foreach (FileInformation fileInormation in filesList)
        {
            count = count + ExcelToDS(fileInormation.FilePath).Tables[0].Rows.Count;
        }
        return count;
    }


}