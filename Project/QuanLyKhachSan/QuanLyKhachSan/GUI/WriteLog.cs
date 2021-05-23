using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class WriteLog
    {
        public void FormWrite(string content)
        {
            using (StreamWriter sw = File.AppendText("Form.log"))
            {
                sw.WriteLine($"{content} {DateTime.Now}");
            }
            
        }
        public void ButtonWrite(string content)
        {
            using (StreamWriter sw = File.AppendText("Button.log"))
            {
                sw.WriteLine($"{content} {DateTime.Now}");
            }
           
        }
    }
}
