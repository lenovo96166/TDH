var ua = navigator.userAgent;
var ipad = ua.match(/(iPad).*OS\s([\d_]+)/),
isIphone = !ipad && ua.match(/(iPhone\sOS)\s([\d_]+)/),
isAndroid = ua.match(/(Android)\s+([\d.]+)/),
isMobile = isIphone || isAndroid;

function share(path) {
    if (isMobile) {
        
    } else {
        var clipBoardContent = "";
        clipBoardContent += path;
        window.clipboardData.setData("Text", clipBoardContent);
        alert("商品地址已复制！，请粘贴到你的QQ/微信上推荐给好友");
    }
}