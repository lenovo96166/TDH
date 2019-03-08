<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>淘得好首页</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery.js"></script>
    <script type="text/javascript" src="JS/Main.js"></script>
    <script type="text/javascript" src="https://cdn.bootcss.com/bootstrap/2.3.2/js/bootstrap.min.js"></script>
    <link href="https://cdn.bootcss.com/bootstrap/2.3.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.bootcss.com/bootstrap/2.3.2/css/bootstrap-responsive.min.css"
        rel="stylesheet" />
    <link href="CSS/main.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="navbar navbar-fixed-top" style="margin-left: 50px; margin-top: 2%;">
            <form id="form1" runat="server" action="Index.aspx?action=search" method="post">
            <div class="control-group">
                <label class="control-label" for="inputIcon">
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-search"></i></span>
                        <input class="span5" name="searchCondition" type="text" value="<%=sc %>" />
                        <button class="btn btn-primary" type="submit">
                            搜 索</button>
                        <a href="Index.aspx?action=lucky" class="btn btn-primary" style="margin-left: 10px;">
                            换一波</a>
                    </div>
                </div>
            </div>
            </form>
        </div>
        <div class="row">
            <ul class="thumbnails" style="margin: 0px auto; margin-top: 7%;">
                <% foreach (var model in modelList)
                   { %>
                <li class="span3">
                    <div class="thumbnail">
                        <a href="<%= model.TaobaoLink%>" class="thumbnail">
                            <img id="pic" alt="<%= model.GoodsName%>" src="<%= model.GoodsMainPhoto%>"  />
                        </a>
                        <div>
                            <a href="<%= model.TaobaoLink%>">
                                <h6>
                                    <%= model.GoodsName%>
                                </h6>
                            </a>
                        </div>
                        <div>
                            <strong class="text-success"><strike class="text-error">原价:
                                <%= model.OriginalPrice%>；</strike>现价:
                                <%= model.Price%>；</strong>
                        </div>
                        <div>
                            <strong class="text-warning">月销量：
                                <%= model.MonthlySales%>件</strong>
                        </div>
                        <div>
                            <a href="<%= model.TaobaoLink%>" class="btn btn-primary btn-small">购买</a> <a href="<%= model.DiscountCouponLink%>"
                                class="btn btn-warning btn-small">领劵</a> <a href="javascript:void(0);" onclick="share('<%=model.TaobaoLink%>');"
                                    class="btn btn-danger btn-small">分享</a>
                        </div>
                    </div>
                </li>
                <%}%>
            </ul>
        </div>
        <div class="pagination">
            <ul>
                <li><a href="Index.aspx?pageNum=<%=pageNum-1 %>&sc=<%=sc %>">上一页</a> </li>
                <% for (int i = 1; i <= pageCountOneScream; i++)
                   { %>
                <li><a href="Index.aspx?pageNum=<%=i %>&sc=<%=sc %>">
                    <%=i %>
                </a></li>
                <%}%>
                <li><a href="Index.aspx?pageNum=<%=pageNum+1 %>&sc=<%=sc %>">下一页</a> </li>
            </ul>
        </div>
    </div>
</body>
</html>
