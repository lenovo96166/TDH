using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    public List<Model> modelList = new List<Model>();

    //起始页数
    public int pageNum = 1;

    //每屏商品数
    public int pageCount = 50;

    //搜索条件
    public string sc;

    //每屏页数
    public int pageCountOneScream = 20;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(Request["pageNum"]))
        {
            pageNum = int.Parse(Request["pageNum"]);
        }
        string path = Request.ApplicationPath;
        string absolutePaht = Server.MapPath("~/");
        absolutePaht = absolutePaht + "//Data";
        ModelAction modelAction = new ModelAction();

        //总商品数
        int allGoodsCount = modelAction.ExcelCount(absolutePaht);

        if (Request["action"] == "search")
        {
            string condition = Request.Form["searchCondition"];
            sc = condition;
            modelList = modelAction.ReadDataToExcel(absolutePaht, pageNum, "S", condition);
            pageCountOneScream = modelList.Count / 50 > 20 ? 20 : modelList.Count / 50;
            return;
        }

        if (!string.IsNullOrWhiteSpace(Request["sc"]))
        {
            string condition = Request.Form["searchCondition"];
            sc = Request["sc"];
            modelList = modelAction.ReadDataToExcel(absolutePaht, pageNum, "S", Request["sc"]);
            pageCountOneScream = modelList.Count > 20 ? 20 : modelList.Count;
            return;
        }

        if (Request["action"] == "lucky") 
        {
            Random random = new Random();
            pageNum = random.Next(1, allGoodsCount/50);
            modelList = modelAction.ReadDataToExcel(absolutePaht, pageNum, "", "");
            pageCountOneScream = modelList.Count > 20 ? 20 : modelList.Count;
            return;
        }

        modelList = modelAction.ReadDataToExcel(absolutePaht, pageNum, "", "");

        pageCountOneScream = modelList.Count > 20 ? 20 : modelList.Count;
    }
}