using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuration = NetSatis.Entities.Migrations.Configuration;
namespace NetSatis.Entities.Tools
{
    public static class ConnectionStringTool
    {
        public static string ConnectionString()
        {

            return File.Exists(Application.StartupPath + "\\NetSatis.conn") ? CyrptoTool.Decrypt(System.IO.File.ReadAllText(Application.StartupPath + "\\NetSatis.conn")) : "";
        }
        public static void ConnectionStringDegistir(string connectionString)
        {

            if (File.Exists(Application.StartupPath + "\\NetSatis.conn"))
            {
              
                System.IO.File.WriteAllText(Application.StartupPath + "\\NetSatis.conn", CyrptoTool.Encrypt(connectionString));
            }
            else
            {
                using (FileStream fs = File.Create(Application.StartupPath + "\\NetSatis.conn"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(CyrptoTool.Encrypt(connectionString));
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            } 


        }
    }
}
