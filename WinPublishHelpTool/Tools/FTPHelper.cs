using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using WinPublishHelpTool.Commons;

namespace WinPublishHelpTool.Tools
{
    public class FTPHelper
    {
        #region 字段
        string ftpURI;
        string ftpUserID;
        //string ftpServerIP;
        string ftpPassword;
      //  string ftpRemotePath;
        #endregion

        /// <summary>  
        /// 连接FTP服务器
        /// </summary>  
        /// <param name="FtpServerIP">FTP连接地址</param>  
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>  
        /// <param name="FtpUserID">用户名</param>  
        /// <param name="FtpPassword">密码</param>  
        public FTPHelper(string ftpServerUri, string FtpUserID, string FtpPassword)
        {
           // ftpRemotePath = FtpRemotePath;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            if (!ftpServerUri.EndsWith("/"))
            {
                ftpURI = ftpServerUri + "/";
            }
            else
            {
                ftpURI = ftpServerUri;
            }
           
        }

        /// <summary>  
        /// 上传  
        /// </summary>   
        public void UploadFile(string filename,string subDir = null)
        {
            FileInfo fileInf = new FileInfo(filename);
            FtpWebRequest reqFTP;
            if (subDir != null)
            {
                if (!subDir.StartsWith("/"))
                {
                    subDir = "/" + subDir;
                }
                if (!subDir.EndsWith("/"))
                {
                    subDir = subDir + "/" ;
                }
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + subDir + fileInf.Name));
            }
            else
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileInf.Name));
            }
            
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.KeepAlive = false;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            using (FileStream fs = fileInf.OpenRead())
            {
                try
                {
                    using (Stream strm = reqFTP.GetRequestStream())
                    {
                        contentLen = fs.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }
                        strm.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
                    
        }

        public void UploadDir(string dirRootPath, string subDir = null)
        {
            if (string.IsNullOrEmpty(subDir))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dirRootPath);
            
                if (!GetFilesDetailList().Contains(directoryInfo.Name))
                {
                    MakeDir(directoryInfo.Name);
                }

                var files = directoryInfo.GetFiles();
                foreach (var fileInfo in files)
                {
                    UploadFile(fileInfo.FullName);
                }

                var dirs = directoryInfo.GetDirectories();
                foreach (var dir in dirs)
                {
                    UploadDir(dirRootPath,dir.FullName.Substring(dirRootPath.Length));
                }
            }
            else
            {
                if (subDir.StartsWith("\\"))
                {
                    subDir = subDir.Remove(0,1);
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(dirRootPath, subDir));
              
                if (!subDir.StartsWith("/"))
                {
                    subDir = "/" + subDir;
                }
                if (!subDir.EndsWith("/"))
                {
                    subDir = subDir + "/";
                }
                if (subDir.Contains("\\"))
                {
                    subDir = subDir.Replace("\\", "/");
                }

                var subFathDir = GetSubFathDir(subDir);

                var ftpUrl = ftpURI + subFathDir;

                if (!GetAllList(ftpUrl).Select(p=> p.Contains(directoryInfo.Name)).Any())
                {
                    MakeDir(subDir);
                }

                var files = directoryInfo.GetFiles();

                foreach (var fileInfo in files)
                {
                    UploadFile(fileInfo.FullName,subDir);
                }
                var dirs = directoryInfo.GetDirectories();
                foreach (var dir in dirs)
                {
                    UploadDir(dirRootPath, dir.FullName.Substring(dirRootPath.Length));
                }

            }

        }

        public static string GetSubFathDir(string subDir)
        {
            var list = subDir.Split('/').ToList();
            list = list.Where(p=>!string.IsNullOrEmpty(p)).ToList();
            
            list.RemoveAt(list.Count -1);
            if (list.Count > 0)
            {
                var str = list.ToSplitString("/");

                return "/" + str + "/";
            }
            return "/";
        }

        /// <summary>  
        /// 下载  
        /// </summary>   
        public void Download(string filePath, string fileName,string ftpPath = null)
        {
            try
            {
                var url = string.Empty;
                if (string.IsNullOrEmpty(ftpPath))
                {
                    url = ftpURI + fileName;
                }
                else
                {
                    url = ftpURI + ftpPath + fileName;
                }
                using (FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create))
                {
                    FtpWebRequest reqFTP;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                    {
                        using (Stream ftpStream = response.GetResponseStream())
                        {
                            long cl = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[bufferSize];
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                            }
                            ftpStream.Close();
                            outputStream.Close();
                            response.Close();
                        }
                    }
                }
       
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>  
        /// 删除文件  
        /// </summary>  
        public void Delete(string fileName)
        {
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.KeepAlive = false;
                string result = String.Empty;


                using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
                {
                    long size = response.ContentLength;
                    using (Stream datastream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(datastream))
                        {
                            result = sr.ReadToEnd();
                            sr.Close();
                            datastream.Close();
                            response.Close();
                        }
                       
                    }
                    
                
                }
                
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>  
        /// 获取当前目录下明细(包含文件和文件夹)  
        /// </summary>  
        public string[] GetFilesDetailList()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                var resultStream = response.GetResponseStream();
                if (resultStream != null)
                {
                    StreamReader reader = new StreamReader(resultStream);
                    while (!reader.EndOfStream)
                    {   
                        string line = reader.ReadLine();
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        result.Remove(result.ToString().LastIndexOf("\n"), 1);
                        reader.Close();
                        response.Close();
                        return result.ToString().Split('\n');
                        
                    }
                 
                }

                return new string[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>  
        /// 获取FTP文件列表(包括文件夹)
        /// </summary>   
        private string[] GetAllList(string url)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                var resultStream = response.GetResponseStream();
                if (resultStream != null)
                {
                    StreamReader reader = new StreamReader(resultStream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        result.Remove(result.ToString().LastIndexOf("\n"), 1);
                        reader.Close();
                        response.Close();
                        return result.ToString().Split('\n');

                    }

                }

                return new string[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public string[] GetDirAllList(string path)
        {
            try
            {
                if (!path.StartsWith("/"))
                {
                    path = "/" + path;
                }
                if (!path.EndsWith("/"))
                {
                    path = path + "/";
                }
                if (path.Contains("\\"))
                {
                    path = path.Replace("\\", "/");
                }
                var url = ftpURI + path;
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                var resultStream = response.GetResponseStream();
                if (resultStream != null)
                {
                    StreamReader reader = new StreamReader(resultStream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        //line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        if (!string.IsNullOrEmpty(result.ToString()))
                        {
                            result.Remove(result.ToString().LastIndexOf("\n"), 1);
                        }                       
                        reader.Close();
                        response.Close();
                        return result.ToString().Split('\n');

                    }

                }

                return new string[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>  
        /// 创建文件夹  
        /// </summary>   
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                if (dirName.StartsWith("\\"))
                {
                    dirName = dirName.Replace("\\", "");
                }
                if (!dirName.StartsWith("/"))
                {
                    dirName = "/" + dirName;
                }
                if (!dirName.EndsWith("/"))
                {
                    dirName = dirName + "/";
                }
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
        }

        /// <summary>  
        /// 获取指定文件大小  
        /// </summary>  
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
            return fileSize;
        }

        /// <summary>  
        /// 更改文件名  
        /// </summary> 
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            { }
        }

        /// <summary>  
        /// 移动文件  
        /// </summary>  
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }


        public string[] GetOnlyFilesList(FileType fileType,string path = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    if (!path.StartsWith("/"))
                    {
                        path = "/" + path;
                    }
                    if (!path.EndsWith("/"))
                    {
                        path = path + "/";
                    }
                    ftpURI = ftpURI + path;
                }
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                var resultStream = response.GetResponseStream();
                if (resultStream != null)
                {
                    StreamReader reader = new StreamReader(resultStream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }
                        result.Remove(result.ToString().LastIndexOf("\n"), 1);
                        reader.Close();
                        response.Close();
                        var readList = result.ToString().Split('\n').Where(p =>
                        {
                            if (fileType == FileType.File)
                            {
                                return !p.Contains("DIR");
                            }
                            return p.Contains("DIR");
                        }).Select(p =>
                        {
                            if (fileType == FileType.File)
                            {
                                var tempLine1 = Regex.Split(p, @"\s{2,}")[2];
                                return Regex.Replace(tempLine1, @"\d", "").TrimStart();
                            }
                            return Regex.Split(p, @"\s{2,}")[3];
                        }).ToArray();

                        return readList;

                    }

                }

                return new string[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void DownloadDir(string localDir,string subPath = null)
        {
            if (subPath == null)
            {
                if (!Directory.Exists(localDir))
                {
                    Directory.CreateDirectory(localDir);
                }

                var files = GetOnlyFilesList(FileType.File);
                foreach (var file in files)
                {
                    try
                    {
                        Download(localDir,file);
                    }
                    catch (Exception e)
                    {
                      
                        throw new Exception(e.Message + "文件名为:" + file);
                    }
                }

                var dirs = GetOnlyFilesList(FileType.Dir);
                foreach (var dir in dirs)
                {
                    DownloadDir(localDir,dir);
                }

            }
            else
            {
                string newPath = Path.Combine(localDir, subPath);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                var files = GetOnlyFilesList(FileType.File,subPath);
                foreach (var file in files)
                {
                    Download(localDir, file);
                }

                var dirs = GetOnlyFilesList(FileType.Dir,subPath);
                foreach (var dir in dirs)
                {
                    var newSubPath = "/" + dir;
                    DownloadDir(localDir, newSubPath);
                }

            }
        }
    }

    public enum FileType
    {
        File,
        Dir
    }
}