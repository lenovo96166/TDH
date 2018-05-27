using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
///File 的摘要说明
/// </summary>
public class GoodsFile
{
    public List<FileInformation> GetAllFiles(DirectoryInfo dir)
    {
        List<FileInformation> FileList = new List<FileInformation>();  
        FileInfo[] allFile = dir.GetFiles();
        foreach (FileInfo fi in allFile)
        {
            FileList.Add(new FileInformation { FileName = fi.Name, FilePath = fi.FullName });
        }
        DirectoryInfo[] allDir = dir.GetDirectories();
        foreach (DirectoryInfo d in allDir)
        {
            GetAllFiles(d);
        }
        //反转排序，最新的商品在最前面
        FileList.Reverse();
        return FileList;
    }  
}

public class FileInformation
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}