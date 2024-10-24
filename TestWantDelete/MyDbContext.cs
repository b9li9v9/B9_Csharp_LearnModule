using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLearnEFCoreMigration
{
    internal class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /// Add-Migration NAME 
            /// Update-Database
            /// Drop-Database   删除数据库
            /// Remove-Migration 删除Migration文件
            /// MultipleActiveResultSets->连接字符串配置选项
            base.OnConfiguring(optionsBuilder);
            string connStr = "server=DESKTOP-AQHQ8UT\\SQLEXPRESS;uid=zhangsan;pwd=123456;database=CLEMDB;Encrypt=False;"; 
            optionsBuilder.UseSqlServer(connStr);
            //optionsBuilder.LogTo(msg => { if (!msg.Contains("CommandExecuting")) return;Debug.WriteLine(msg); });
        }
    }
}
