using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace zoomeye
{
    public partial class Form1 : Form
    {
        Messagecs mymessage = new Messagecs();
        string zujian = "", zujianming = "", xitong = "", ip = "",
            guojia = "", diqu = "", cidr = "", duankou = "", fuwu = "", zhujiming = "",
            yuming = "", biaoti = "", guanjianzi = "", httptou = "",miaoshu="";
        string jsonstrings = "";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var jObjects = JObject.Parse(jsonstrings);
            string jsonstring = jObjects["matches"][listBox1.SelectedIndex].ToString();
            

            mymessage.update(jsonstring, this.Location.X + this.Width, this.Location.Y);
            //mymessage.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        

        private void textBoxpage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string outputtxt = "";
            update();
            int mypage = 0;
            for (int r = 0; r < Convert.ToInt32(textBox2.Text); r++)
            {
                mypage++;

                string http = "https://api.zoomeye.org/host/search?query=";
                if (zujian != "")
                    http = http + "app:" + zujian;
                if (zujianming != "")
                    http = http + "%20ver:" + zujianming;
                if (duankou != "")
                    http = http + "%20port:" + duankou;
                if (xitong != "")
                    http = http + "%20os:" + xitong;
                if (fuwu != "")
                    http = http + "%20service:" + fuwu;
                if (guojia != "")
                    http = http + "%20country:" + guojia;
                if (diqu != "")
                    http = http + "%20city:" + diqu;
                if (ip != "")
                    http = http + "%20ip:" + ip;
                if (cidr != "")
                    http = http + "%20cidr:" + cidr;
                http = http + "&page=" + mypage.ToString() + "&facet=app,os";
                //MessageBox.Show(http);
                //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "&page=" + page.ToString() + "&facet=app,os";
                //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "%20os:" + xitong + "%20service:" + fuwu + "%20country:" + guojia + "%20city:" + diqu + "%20ip:" + ip + "%20cidr:" + cidr + "&page=" + page.ToString() + "&facet=app,os";
                jsonstrings = eye.Get(http, "Authorization", "JWT " + access_token);
                if(jsonstrings=="")
                {
                    continue;
                }
                var jObjects = JObject.Parse(jsonstrings);

                for (int i = 0; i < SubstringCount(jsonstrings, "geoinfo"); i++)
                {
                    //MessageBox.Show(SubstringCount(jsonstrings, "geoinfo").ToString());
                    string jsonstring = jObjects["matches"][i].ToString();
                    jsonstring = jsonstring.Replace("[", "");
                    jsonstring = jsonstring.Replace("]", "");
                    try
                    {
                        var jObject = JObject.Parse(jsonstring);
                        jsonstring = jObject["ip"].ToString();
                        outputtxt = outputtxt + jsonstring + "\r\n";
                    }
                    catch(Exception e6)
                    {

                    }
                }
            }
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;
            if(path=="")
            {
                return;
            }
            FileStream fs = new FileStream(path , FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(outputtxt);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string outputtxt = "";
            update();
            int mypage = 0;
            for (int r = 0; r < Convert.ToInt32(textBox2.Text); r++)
            {
                mypage++;
                string http = "https://api.zoomeye.org/web/search?query=";
                if (zujian != "")
                    http = http + "app:" + zujian;
                if (zujianming != "")
                    http = http + "%20ver:" + zujianming;
                if (yuming != "")
                    http = http + "%20site:" + yuming;
                if (xitong != "")
                    http = http + "%20os:" + xitong;
                if (biaoti != "")
                    http = http + "%20site:" + biaoti;
                if (miaoshu != "")
                    http = http + "%20desc" + miaoshu;
                if (guanjianzi != "")
                    http = http + "%20headers:" + httptou;
                if (guojia != "")
                    http = http + "%20country:" + guojia;
                if (diqu != "")
                    http = http + "%20city:" + diqu;
                if (ip != "")
                    http = http + "%20ip:" + ip;
                if (cidr != "")
                    http = http + "%20cidr:" + cidr;
                http = http + "&page=" + page.ToString() + "&facet=app,os";
                //MessageBox.Show(http);
                //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "&page=" + page.ToString() + "&facet=app,os";
                //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "%20os:" + xitong + "%20service:" + fuwu + "%20country:" + guojia + "%20city:" + diqu + "%20ip:" + ip + "%20cidr:" + cidr + "&page=" + page.ToString() + "&facet=app,os";
                jsonstrings = eye.Get(http, "Authorization", "JWT " + access_token);
                if (jsonstrings == "")
                {
                    //MessageBox.Show("查询失败");
                    continue;
                }
                var jObjects = JObject.Parse(jsonstrings);

                for (int i = 0; i < SubstringCount(jsonstrings, "geoinfo"); i++)
                {
                    //MessageBox.Show(SubstringCount(jsonstrings, "geoinfo").ToString());
                    string jsonstring = jObjects["matches"][i].ToString();
                    jsonstring = jsonstring.Replace("[", "");
                    jsonstring = jsonstring.Replace("]", "");

                    if (jsonstring.Contains("\"domains\""))
                    {
                        for (int j = 0; j < jsonstring.Length; j++)
                        {
                            if (jsonstring.Substring(j, 9).Equals("\"domains\""))
                            {
                                jsonstring = jsonstring.Substring(0, j - 1) + "}";
                                break;
                            }
                        }
                    }
                    try
                    {
                        var jObject = JObject.Parse(jsonstring);
                        jsonstring = jObject["ip"].ToString();
                        outputtxt = outputtxt + jsonstring + "\r\n";
                    }
                    catch(Exception e7)
                    {

                    }
                }
            }
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;
            if(path=="")
            {
                return;
            }
            
            FileStream fs = new FileStream(path, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(outputtxt);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mymessage.update("", this.Location.X + this.Width, this.Location.Y);
            mymessage.Show();
        }

        int page = 1;



        string access_token = "";
        zoom eye = new zoom();
        public string username = "610726512@qq.com";
        public string password = "asd123456";
        public Form1()
        {
            InitializeComponent();
            
        }

        public bool login()
        {
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);
            writer.WriteStartObject();
            writer.WritePropertyName("username");
            writer.WriteValue(username);
            writer.WritePropertyName("password");
            writer.WriteValue(password);
            writer.WriteEndObject();
            writer.Flush();
            string jsonText = sw.GetStringBuilder().ToString();
            if (!eye.Login(@"https://api.zoomeye.org/user/login", jsonText))
            {
                MessageBox.Show("登录失败");
                return false;
            }
            List<string> users = new List<string>();
            string jsonstring = eye.access_token;
            var jObject = JObject.Parse(jsonstring);
            access_token = jObject["access_token"].ToString();
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(path + "users"))
            {
                StreamReader sr = new StreamReader(path+"users", Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    users.Add(line.ToString());
                }
                sr.Close();
            }
            else
            {
                File.Create(path + "users");

            }
            int i = 0;
            for(i=0;i<users.Count;i++)
            {
                if(username.Equals(users[i]))
                {
                    break;
                }
            }
            if(i==users.Count)
            {
                FileStream fs = new FileStream(path + "users", FileMode.Create);
                string output = username;
                foreach (string str in users)
                {
                    output = output+ "\n"+str;
                }
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(output);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)//主机搜索
        {
            int fail = 0;
            listBox1.Items.Clear();
            update();
            string http = "https://api.zoomeye.org/host/search?query=";
            if (zujian != "")
                http = http + "app:"+ zujian ;
            if(zujianming!="")
                http = http + "%20ver:" + zujianming;
            if (duankou != "")
                http = http + "%20port:" + duankou;
            if (xitong != "")
                http = http + "%20os:" + xitong;
            if (fuwu != "")
                http = http + "%20service:" + fuwu;
            if (guojia != "")
                http = http + "%20country:" + guojia;
            if (diqu != "")
                http = http + "%20city:" + diqu;
            if (ip != "")
                http = http + "%20ip:" + ip;
            if (cidr != "")
                http = http + "%20cidr:" + cidr;
            http = http+"&page=" + page.ToString() + "&facet=app,os";
            //MessageBox.Show(http);
            //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "&page=" + page.ToString() + "&facet=app,os";
            //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "%20os:" + xitong + "%20service:" + fuwu + "%20country:" + guojia + "%20city:" + diqu + "%20ip:" + ip + "%20cidr:" + cidr + "&page=" + page.ToString() + "&facet=app,os";
            jsonstrings = eye.Get(http,"Authorization", "JWT "+access_token);
            if (jsonstrings == "")
            {
                MessageBox.Show("查询失败");
                return;
            }
            var jObjects = JObject.Parse(jsonstrings);
           
            for (int i = 0; i < SubstringCount(jsonstrings, "geoinfo"); i++)
            {
               
                //MessageBox.Show(SubstringCount(jsonstrings, "geoinfo").ToString());
                string jsonstring = jObjects["matches"][i].ToString();
                jsonstring = jsonstring.Replace("[", "");
                jsonstring = jsonstring.Replace("]", "");
                try
                { 
                    var jObject = JObject.Parse(jsonstring);
                    jsonstring = jObject["ip"].ToString();
                    listBox1.Items.Add(jsonstring);
                }
                catch(Exception e2)
                {
                    listBox1.Items.Add("解析失败"+fail++.ToString());
                }
            }
            //mymessage.update(jsonstring, this.Location.X + this.Width, this.Location.Y);
            //mymessage.Show();
        }

        

        private void buttonweb_Click(object sender, EventArgs e)//web搜索
        {
            int fail = 0;
            listBox1.Items.Clear();
            update();
            string http = "https://api.zoomeye.org/web/search?query=";
            if (zujian != "")
                http = http + "app:" + zujian;
            if (zujianming != "")
                http = http + "%20ver:" + zujianming;
            if (yuming != "")
                http = http + "%20site:" + yuming;
            if (xitong != "")
                http = http + "%20os:" + xitong;
            if (biaoti != "")
                http = http + "%20site:" + biaoti;
            if (miaoshu != "")
                http = http + "%20desc" + miaoshu;
            if (guanjianzi != "")
                http = http + "%20headers:" + httptou;
            if (guojia != "")
                http = http + "%20country:" + guojia;
            if (diqu != "")
                http = http + "%20city:" + diqu;
            if (ip != "")
                http = http + "%20ip:" + ip;
            if (cidr != "")
                http = http + "%20cidr:" + cidr;
            http = http + "&page=" + page.ToString() + "&facet=app,os";
            //MessageBox.Show(http);
            //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "&page=" + page.ToString() + "&facet=app,os";
            //string http = "https://api.zoomeye.org/host/search?query=app:" + zujian + "%20ver:" + zujianming + "%20port:" + duankou + "%20os:" + xitong + "%20service:" + fuwu + "%20country:" + guojia + "%20city:" + diqu + "%20ip:" + ip + "%20cidr:" + cidr + "&page=" + page.ToString() + "&facet=app,os";
            jsonstrings = eye.Get(http, "Authorization", "JWT " + access_token);
            if(jsonstrings=="")
            {
                MessageBox.Show("查询失败");
                return;
            }
            var jObjects = JObject.Parse(jsonstrings);

            for (int i = 0; i < SubstringCount(jsonstrings, "geoinfo"); i++)
            {
                //MessageBox.Show(SubstringCount(jsonstrings, "geoinfo").ToString());
                string jsonstring = jObjects["matches"][i].ToString();
                jsonstring = jsonstring.Replace("[", "");
                jsonstring = jsonstring.Replace("]", "");
                
                /*if(jsonstring.Contains("\"domains\""))
                {
                    for(int j=0;j<jsonstring.Length;j++)
                    {
                        if(jsonstring.Substring(j,9).Equals("\"domains\""))
                        {
                            jsonstring = jsonstring.Substring(0,j-1);
                            break;
                        }
                        
                    }
                    while (jsonstring[jsonstring.Length - 1] == ',')
                    {
                        jsonstring = jsonstring.Substring(0, jsonstring.Length - 1);
                    }
                    jsonstring = jsonstring + "}";
                }*/
                try
                {
                    var jObject = JObject.Parse(jsonstring);
                    jsonstring = jObject["ip"].ToString();
                    listBox1.Items.Add(jsonstring);
                }
                catch(Exception e1)
                {
                    try
                    {
                        if (jsonstring.Contains("\"domains\""))
                        {
                            for (int j = 0; j < jsonstring.Length; j++)
                            {
                                if (jsonstring.Substring(j, 9).Equals("\"domains\""))
                                {
                                    jsonstring = jsonstring.Substring(0, j - 1);
                                    break;
                                }

                            }
                            while (jsonstring[jsonstring.Length - 1] == ',')
                            {
                                jsonstring = jsonstring.Substring(0, jsonstring.Length - 1);
                            }
                            jsonstring = jsonstring + "}";
                        }
                        var jObject = JObject.Parse(jsonstring);
                        jsonstring = jObject["ip"].ToString();
                        listBox1.Items.Add(jsonstring);
                    }
                    catch (Exception e5)
                    {
                        listBox1.Items.Add("解析失败" + fail++.ToString());
                    }//mymessage.Show();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("      Low作");
        }

        private void button1_Click_1(object sender, EventArgs e)//用户手册
        {
            string output= @"https://www.zoomeye.org/help/manual"+"\r\n";
            output = output + "主机设备搜索\r\n组件名称\r\napp: 组件名。\r\n ver: 组件版本。\r\nApache httpd, 版本 2.2.16: app: Apache httpd ver: 2.2.16\r\n端口\r\nport:开放端口。\r\nv搜索远程桌面连接：port: 3389\r\n搜索 SSH： port: 22\r\n一些服务器可能监听了非标准的端口。要按照更精确的协议进行检索，请使用service: 过滤\r\n器。\r\n操作系统\r\nos:操作系统。 例子： os: linux\r\n 服务\r\nservice: 结果分析中的“服务名”字段。\r\n公网路由器： service: routersetup\r\n 公网摄像头： service: webcam\r\n  完整的“服务名”列表，请参阅 https://svn.nmap.org/nmap/nmap-services\r\n主机名\r\nhostname:分析结果中的“主机名”字段。 例子： hostname: google.com\r\n2017 / 5 / 14 ZoomEye | 钟馗之眼 - 网络空间搜索引擎\r\nhttps://www.zoomeye.org/help/manual 3/5\r\n            位置\r\n            country:国家或者地区代码。\r\ncity: 城市名称。\r\n搜索美国的 Apache 服务器： app: Apache country:US\r\n搜索英国的 Sendmail 服务器： app: Sendmail country:UK\r\n  完整的国家代码，请参阅: 国家地区代码 - 维基百科\r\nIP 地址\r\nip: 搜索一个指定的 IP 地址\r\n Google 的公共 DNS 服务器：ip: 8.8.8.8\r\nCIDR\r\nIP 的 CIDR 网段。 例子： cidr: 8.8.8.8 / 24\r\nWeb应用搜索\r\n组件名称\r\napp: 组件名。\r\nver: 组件版本。\r\nApache httpd, 版本 2.2.16: app: Apache httpd ver: 2.2.16\r\n操作系统\r\nos:操作系统。 例子： os: linux\r\n 网站\r\nsite: 网站域名。 例子： site: google.com\r\n  标题\r\ntitle: 页面标题，在<title> 例子： title: Nginx\r\n   关键词\r\nkeywords:< metaname = Keywords> 定义的页面关键词。 例子： keywords: Nginx\r\n      描述\r\ndesc:< metaname = description > 定义的页面说明。 例子： desc: Nginx\r\n2017 / 5 / 14 ZoomEye | 钟馗之眼 - 网络空间搜索引擎\r\nhttps://www.zoomeye.org/help/manual 4/5\r\n           HTTP 头\r\nheaders: HTTP 请求中的 Headers。 例子： headers: Server\r\n  位置\r\ncountry: 国家或者地区代码。\r\ncity: 城市名称。\r\n搜索美国的 Apache 服务器： app: Apache country:US\r\n 搜索英国的 Sendmail 服务器： app: Sendmail country:UK\r\n 完整的国家代码，请参阅: 国家地区代码 - 维基百科\r\nIP 地址\r\nip: 搜索一个指定的 IP 地址\r\n CIDR\r\nIP 的 CIDR 网段。 例子： cidr: 8.8.8.8 / 24\r\n";
            mymessage.update(output,this.Location.X+this.Width,this.Location.Y);
            //mymessage.Show();

        }
        private void update()
        {
            zujian = textBoxzujian.Text;
            zujianming = textBoxzujianming.Text;
            xitong = textBoxxitong.Text;
            guojia = textBoxguojia.Text;
            diqu = textBoxdiqu.Text;
            cidr = textBoxCIDR.Text;
            duankou = textBoxduankou.Text;
            fuwu = textBoxfuwu.Text;
            zhujiming = textBoxzhujiming.Text;
            yuming = textBoxyuming.Text;
            httptou = textBoxHttptou.Text;
            page = Convert.ToInt32(textBoxpage.Text);
            miaoshu = textBoxmiaoshu.Text;
            label19.Text = "当前：" + page.ToString();
        }
        int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return 0;
        }
    }
}
