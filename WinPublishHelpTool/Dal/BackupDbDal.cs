using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WinPublishHelpTool.Commons;
using WinPublishHelpTool.Models;
using WinPublishHelpTool.Tools;

namespace WinPublishHelpTool.Dal
{
    public class BackupDbDal
    {
        public BackupDbDal()
        {

        }


        public IList<DbInfo> GetAllDbName()
        {
            var dbList = new List<DbInfo>();
            string sql = "SELECT * FROM sys.sysdatabases WHERE name NOT IN('master','tempdb','model','msdb')";
            using (var reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var dbInfo = new DbInfo();
                    dbInfo.Name = reader["name"].ToString();
                    dbInfo.Id = Convert.ToInt32(reader["dbid"]);
                    dbList.Add(dbInfo);
                }
            }
            return dbList;
        }

        public bool BackupDbInfo(string path, string backupDb)
        {
            var backDbName = Path.GetFileName(path);
            var sql = string.Format(@"backup database {0} to disk='z:\{1}'", backupDb, backDbName);
            return SqlHelper.ExecteNonQuery(CommandType.Text, sql) > 0;
        }

        public bool LinkDbService(string dbSourceAddress, string dbSourceServiceName, string dbSourceServicePwd, out string linkErrMsg)
        {
            try
            {
                var sql = @"exec master..xp_cmdshell 'net use z: \\" + dbSourceAddress + "\\c$ " + "\"" + dbSourceServicePwd + "\"" + string.Format("/user:{0}\\{1}'", dbSourceAddress, dbSourceServiceName);

                var outputList = new List<string>();
                using (var reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql))
                {
                    while (reader.Read())
                    {
                        outputList.Add(reader[0].ToString());
                    }
                }
                if (outputList.Count > 0)
                {
                    if (outputList[0].Trim() == "命令成功完成。")
                    {
                        linkErrMsg = outputList[0];
                        return true;
                    }
                    linkErrMsg = outputList.ToSplitString(",");
                    return false;
                }
                linkErrMsg = "链接数据库服务器失败";
                return false;
            }
            catch (Exception e)
            {
                linkErrMsg = e.Message;
                return false;
            }
        }

        public void RomoveLink()
        {
            var sql = "exec master..xp_cmdshell 'net use z: /delete' ";
            SqlHelper.ExecteNonQuery(CommandType.Text, sql);
        }

        public void RestoreDb(string dbName, string path)
        {
            string sql = string.Format("ALTER DATABASE {0} SET OFFLINE WITH ROLLBACK IMMEDIATE; " +
                                       "RESTORE DATABASE {0} FROM   disk='{1}' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10" +
                                       "ALTER  database  {0}  set   online ", dbName, path);


            SqlHelper.ExecteNonQuery(CommandType.Text, sql);
        }
    }
}