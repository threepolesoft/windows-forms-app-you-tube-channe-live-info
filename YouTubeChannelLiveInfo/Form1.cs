using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubeChannelLiveInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Timer tm;
        public List<ChannelMeta> cmsn = new List<ChannelMeta>();
        public List<ChannelMeta> cmso = new List<ChannelMeta>();
        private void Form1_Load(object sender, EventArgs e)
        {

            ChannelList cnl = new ChannelList();
            cmso = cnl.cm;

            //foreach (var item in cms)
            //{
            //    item.Sub = new Random().Next(new Random().Next(143111, 333234111), new Random().Next(2222111, 434424985));

            //    item.View = new Random().Next(new Random().Next(111111, 3333111), new Random().Next(2222111, 44343453));
            //}

            //RefreshMonitor(cms);

            IsBusy = true;
            InitLoadChannel();


            tm = new Timer();
            tm.Start();
            tm.Interval = 1000 * 2;
            tm.Tick += tm_Tick;

            //tv1.Value = 10111;
            //tv1.ToValue = 10111;
        }

        public bool IsBusy = false;

        void tm_Tick(object sender, EventArgs e)
        {

            ////tv1.DigitCount = 5;
            //tv1.ToValue = 10111;

            if (!IsBusy)
            {
                IsBusy = true;
                try
                {
                    ReMonitor(cmsn);
                }
                catch (Exception)
                {
                    InitMonitor(cmsn);
                }
                
            }
            
        }


        public string key = "AIzaSyAjXYZOBsuouPMZkODYP2U0ORckmNQWdyk";
        public string part = "statistics";

        public async void InitLoadChannel()
        {

            string error = "";

            for (int i = 0; i < cmso.Count; i++)
            {
                

                try
                {
                    string uri = "https://www.googleapis.com/youtube/v3/channels?part=" + part + "&forUsername=" + cmso[i].UserName.ToString() + "&key=" + key;

                    // await Task.Delay(5000);

                    var data = await getData(uri);

                    var items = JArray.Parse(data["items"].ToString());

                    var statistics = JObject.Parse(items[0]["statistics"].ToString());

                    UpdateChannel(new ChannelMeta
                    {
                        UserName = cmso[i].UserName.ToString(),
                        Sub =  Convert.ToInt64(statistics["subscriberCount"].ToString()),
                        View = Convert.ToInt64(statistics["viewCount"].ToString())
                    }, i);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }

            IsBusy = false;
            InitMonitor(cmsn);
        }

        public async void ReLoadChannel()
        {
            string error = "";

            for (int i = 0; i < cmso.Count; i++)
            {
               
                try
                {
                    string uri = "https://www.googleapis.com/youtube/v3/channels?part=" + part + "&forUsername=" + cmso[i].UserName.ToString() + "&key=" + key;

                    // await Task.Delay(5000);

                    var data = await getData(uri);

                    var items = JArray.Parse(data["items"].ToString());

                    var statistics = JObject.Parse(items[0]["statistics"].ToString());

                    UpdateChannel(new ChannelMeta
                    {
                        UserName = cmso[i].UserName.ToString(),
                        Sub = Convert.ToInt64(statistics["subscriberCount"].ToString())-334,
                        View = Convert.ToInt64(statistics["viewCount"].ToString()) - 456
                    }, i);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            }

            IsBusy = false;

            ReMonitor(cmsn);
        }


        public void UpdateChannel(ChannelMeta cmn, int to)
        {
            ChannelMeta cmsr = new ChannelMeta();

            cmsr = cmsn.SingleOrDefault(m => m.UserName == cmn.UserName);

            if (cmsr!=null)
            {
                int index = cmsn.IndexOf(cmsr);

                cmsn.Remove(cmsr);
                cmsn.Insert(index, cmn);
            }
            else
            {
                cmsn.Add(cmn);
            }


            //InitMonitor(cmsn);
        }


        public void InitMonitor(List<ChannelMeta> cms)
        {


            int s = 0;
            int t = 3;
            cms = cms.OrderByDescending(m => m.Sub).ToList();


            for (int i = 0; i < cms.Count; i++)
            {

                if (i == 0)
                {
                    this.gb1.Text = cms[i].UserName;

                    this.sb1.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb1.Value = cms[i].Sub;
                    this.sb1.ToValue = cms[i].Sub;

                    this.tv1.DigitCount = cms[i].View.ToString().Length;
                    this.tv1.Value = cms[i].View;
                    this.tv1.ToValue = cms[i].View;

                }

                else if (i == 1)
                {
                    this.gb2.Text = cms[i].UserName;

                    this.sb2.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb2.Value = cms[i].Sub;
                    this.sb2.ToValue = cms[i].Sub;

                    this.tv2.DigitCount = cms[i].View.ToString().Length;
                    this.tv2.Value = cms[i].View;
                    this.tv2.ToValue = cms[i].View;
                }

                else if (i == 2)
                {
                    this.gb3.Text = cms[i].UserName;

                    this.sb3.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb3.Value = cms[i].Sub;
                    this.sb3.ToValue = cms[i].Sub;

                    this.tv3.DigitCount = cms[i].View.ToString().Length;
                    this.tv3.Value = cms[i].View;
                    this.tv3.ToValue = cms[i].View;
                }

                else if (i == 3)
                {
                    this.gb4.Text = cms[i].UserName;

                    this.sb4.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb4.Value = cms[i].Sub;
                    this.sb4.ToValue = cms[i].Sub;

                    this.tv4.DigitCount = cms[i].View.ToString().Length;
                    this.tv4.Value = cms[i].View;
                    this.tv4.ToValue = cms[i].View;
                }

                else if (i == 4)
                {
                    this.gb5.Text = cms[i].UserName;

                    this.sb5.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb5.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb5.ToValue = cms[i].Sub;

                    this.tv5.DigitCount = cms[i].View.ToString().Length;
                    this.tv5.Value = cms[i].View - new Random().Next(s, t);
                    this.tv5.ToValue = cms[i].View;
                }

                else if (i == 5)
                {
                    this.gb6.Text = cms[i].UserName;

                    this.sb6.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb6.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb6.ToValue = cms[i].Sub;

                    this.tv6.DigitCount = cms[i].View.ToString().Length;
                    this.tv6.Value = cms[i].View - new Random().Next(s, t);
                    this.tv6.ToValue = cms[i].View;
                }

                if (i == 6)
                {
                    this.gb7.Text = cms[i].UserName;

                    this.sb7.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb7.Value = cms[i].Sub;
                    this.sb7.ToValue = cms[i].Sub;

                    this.tv7.DigitCount = cms[i].View.ToString().Length;
                    this.tv7.Value = cms[i].View - new Random().Next(s, t);
                    this.tv7.ToValue = cms[i].View;
                }

                else if (i == 7)
                {
                    this.gb8.Text = cms[i].UserName;

                    this.sb8.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb8.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb8.ToValue = cms[i].Sub;

                    this.tv8.DigitCount = cms[i].View.ToString().Length;
                    this.tv8.Value = cms[i].View - new Random().Next(s, t);
                    this.tv8.ToValue = cms[i].View;
                }

                else if (i == 8)
                {
                    this.gb9.Text = cms[i].UserName;

                    this.sb9.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb9.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb9.ToValue = cms[i].Sub;

                    this.tv9.DigitCount = cms[i].View.ToString().Length;
                    this.tv9.Value = cms[i].View - new Random().Next(s, t);
                    this.tv9.ToValue = cms[i].View;
                }

                else if (i == 9)
                {
                    this.gb10.Text = cms[i].UserName;

                    this.sb10.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb10.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb10.ToValue = cms[i].Sub;

                    this.tv10.DigitCount = cms[i].View.ToString().Length;
                    this.tv10.Value = cms[i].View - new Random().Next(s, t);
                    this.tv10.ToValue = cms[i].View;
                }

                else if (i == 10)
                {
                    this.gb11.Text = cms[i].UserName;

                    this.sb11.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb11.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb11.ToValue = cms[i].Sub;

                    this.tv11.DigitCount = cms[i].View.ToString().Length;
                    this.tv11.Value = cms[i].View - new Random().Next(s, t);
                    this.tv11.ToValue = cms[i].View;
                }
                else if (i == 11)
                {
                    this.gb12.Text = cms[i].UserName;

                    this.sb12.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb12.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb12.ToValue = cms[i].Sub;

                    this.tv12.DigitCount = cms[i].View.ToString().Length;
                    this.tv12.Value = cms[i].View - new Random().Next(s, t);
                    this.tv12.ToValue = cms[i].View;
                }
                else if (i == 12)
                {
                    this.gb13.Text = cms[i].UserName;

                    this.sb13.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb13.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb13.ToValue = cms[i].Sub;

                    this.tv13.DigitCount = cms[i].View.ToString().Length;
                    this.tv13.Value = cms[i].View - new Random().Next(s, t);
                    this.tv13.ToValue = cms[i].View;
                }
                else if (i == 13)
                {
                    this.gb14.Text = cms[i].UserName;

                    this.sb14.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb14.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb14.ToValue = cms[i].Sub;

                    this.tv14.DigitCount = cms[i].View.ToString().Length;
                    this.tv14.Value = cms[i].View - new Random().Next(s, t);
                    this.tv14.ToValue = cms[i].View;
                }
                else if (i == 14)
                {
                    this.gb15.Text = cms[i].UserName;

                    this.sb15.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb15.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb15.ToValue = cms[i].Sub;

                    this.tv15.DigitCount = cms[i].View.ToString().Length;
                    this.tv15.Value = cms[i].View - new Random().Next(s, t);
                    this.tv15.ToValue = cms[i].View;
                }
                else if (i == 15)
                {
                    this.gb16.Text = cms[i].UserName;

                    this.sb16.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb16.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb16.ToValue = cms[i].Sub;

                    this.tv16.DigitCount = cms[i].View.ToString().Length;
                    this.tv16.Value = cms[i].View - new Random().Next(s, t);
                    this.tv16.ToValue = cms[i].View;
                }
                else if (i == 16)
                {
                    this.gb17.Text = cms[i].UserName;

                    this.sb17.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb17.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb17.ToValue = cms[i].Sub;

                    this.tv17.DigitCount = cms[i].View.ToString().Length;
                    this.tv17.Value = cms[i].View - new Random().Next(s, t);
                    this.tv17.ToValue = cms[i].View;
                }
                else if (i == 17)
                {
                    this.gb18.Text = cms[i].UserName;

                    this.sb18.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb18.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb18.ToValue = cms[i].Sub;

                    this.tv18.DigitCount = cms[i].View.ToString().Length;
                    this.tv18.Value = cms[i].View - new Random().Next(s, t);
                    this.tv18.ToValue = cms[i].View;
                }
                else if (i == 18)
                {
                    this.gb19.Text = cms[i].UserName;

                    this.sb19.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb19.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb19.ToValue = cms[i].Sub;

                    this.tv19.DigitCount = cms[i].View.ToString().Length;
                    this.tv19.Value = cms[i].View - new Random().Next(s, t);
                    this.tv19.ToValue = cms[i].View;
                }
                else if (i == 19)
                {
                    this.gb20.Text = cms[i].UserName;

                    this.sb20.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb20.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb20.ToValue = cms[i].Sub;

                    this.tv20.DigitCount = cms[i].View.ToString().Length;
                    this.tv20.Value = cms[i].View - new Random().Next(s, t);
                    this.tv20.ToValue = cms[i].View;
                }
                else if (i == 20)
                {
                    this.gb21.Text = cms[i].UserName;

                    this.sb21.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb21.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb21.ToValue = cms[i].Sub;

                    this.tv21.DigitCount = cms[i].View.ToString().Length;
                    this.tv21.Value = cms[i].View - new Random().Next(s, t);
                    this.tv21.ToValue = cms[i].View;
                }
                else if (i == 21)
                {
                    this.gb22.Text = cms[i].UserName;

                    this.sb22.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb22.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb22.ToValue = cms[i].Sub;

                    this.tv22.DigitCount = cms[i].View.ToString().Length;
                    this.tv22.Value = cms[i].View - new Random().Next(s, t);
                    this.tv22.ToValue = cms[i].View;
                }
                else if (i == 22)
                {
                    this.gb23.Text = cms[i].UserName;

                    this.sb23.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb23.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb23.ToValue = cms[i].Sub;

                    this.tv23.DigitCount = cms[i].View.ToString().Length;
                    this.tv23.Value = cms[i].View - new Random().Next(s, t);
                    this.tv23.ToValue = cms[i].View;
                }
                else if (i == 23)
                {
                    this.gb24.Text = cms[i].UserName;

                    this.sb24.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb24.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb24.ToValue = cms[i].Sub;

                    this.tv24.DigitCount = cms[i].View.ToString().Length;
                    this.tv24.Value = cms[i].View - new Random().Next(s, t);
                    this.tv24.ToValue = cms[i].View;
                }
                else if (i == 24)
                {
                    this.gb25.Text = cms[i].UserName;

                    this.sb25.DigitCount = cms[i].Sub.ToString().Length;
                    this.sb25.Value = cms[i].Sub - new Random().Next(s, t);
                    this.sb25.ToValue = cms[i].Sub;

                    this.tv25.DigitCount = cms[i].View.ToString().Length;
                    this.tv25.Value = cms[i].View - new Random().Next(s, t);
                    this.tv25.ToValue = cms[i].View;
                }
                else if (i == 25)
                {
                    this.groupBox1.Text = cms[i].UserName;

                    this.counter1.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter1.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter1.ToValue = cms[i].Sub;

                    this.counter2.DigitCount = cms[i].View.ToString().Length;
                    this.counter2.Value = cms[i].View - new Random().Next(s, t);
                    this.counter2.ToValue = cms[i].View;
                }
                else if (i == 26)
                {
                    this.groupBox2.Text = cms[i].UserName;

                    this.counter3.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter3.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter3.ToValue = cms[i].Sub;

                    this.counter4.DigitCount = cms[i].View.ToString().Length;
                    this.counter4.Value = cms[i].View - new Random().Next(s, t);
                    this.counter4.ToValue = cms[i].View;
                }
                else if (i == 27)
                {
                    this.groupBox3.Text = cms[i].UserName;

                    this.counter5.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter5.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter5.ToValue = cms[i].Sub;

                    this.counter6.DigitCount = cms[i].View.ToString().Length;
                    this.counter6.Value = cms[i].View - new Random().Next(s, t);
                    this.counter6.ToValue = cms[i].View;
                }
                else if (i == 28)
                {
                    this.groupBox4.Text = cms[i].UserName;

                    this.counter7.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter7.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter7.ToValue = cms[i].Sub;

                    this.counter8.DigitCount = cms[i].View.ToString().Length;
                    this.counter8.Value = cms[i].View - new Random().Next(s, t);
                    this.counter8.ToValue = cms[i].View;
                }
                else if (i == 29)
                {
                    this.groupBox5.Text = cms[i].UserName;

                    this.counter9.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter9.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter9.ToValue = cms[i].Sub;

                    this.counter10.DigitCount = cms[i].View.ToString().Length;
                    this.counter10.Value = cms[i].View - new Random().Next(s, t);
                    this.counter10.ToValue = cms[i].View;
                }
                else if (i == 30)
                {
                    this.groupBox6.Text = cms[i].UserName;

                    this.counter11.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter11.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter11.ToValue = cms[i].Sub;

                    this.counter12.DigitCount = cms[i].View.ToString().Length;
                    this.counter12.Value = cms[i].View - new Random().Next(s, t);
                    this.counter12.ToValue = cms[i].View;
                }
                else if (i == 31)
                {
                    this.groupBox7.Text = cms[i].UserName;

                    this.counter13.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter13.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter13.ToValue = cms[i].Sub;

                    this.counter14.DigitCount = cms[i].View.ToString().Length;
                    this.counter14.Value = cms[i].View - new Random().Next(s, t);
                    this.counter14.ToValue = cms[i].View;
                }
                else if (i == 32)
                {
                    this.groupBox8.Text = cms[i].UserName;

                    this.counter15.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter15.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter15.ToValue = cms[i].Sub;

                    this.counter16.DigitCount = cms[i].View.ToString().Length;
                    this.counter16.Value = cms[i].View - new Random().Next(s, t);
                    this.counter16.ToValue = cms[i].View;
                }
                else if (i == 33)
                {
                    this.groupBox9.Text = cms[i].UserName;

                    this.counter17.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter17.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter17.ToValue = cms[i].Sub;

                    this.counter18.DigitCount = cms[i].View.ToString().Length;
                    this.counter18.Value = cms[i].View - new Random().Next(s, t);
                    this.counter18.ToValue = cms[i].View;
                }
                else if (i == 34)
                {
                    this.groupBox10.Text = cms[i].UserName;

                    this.counter19.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter19.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter19.ToValue = cms[i].Sub;

                    this.counter20.DigitCount = cms[i].View.ToString().Length;
                    this.counter20.Value = cms[i].View - new Random().Next(s, t);
                    this.counter20.ToValue = cms[i].View;
                }
                else if (i == 35)
                {
                    this.groupBox11.Text = cms[i].UserName;

                    this.counter21.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter21.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter21.ToValue = cms[i].Sub;

                    this.counter22.DigitCount = cms[i].View.ToString().Length;
                    this.counter22.Value = cms[i].View - new Random().Next(s, t);
                    this.counter22.ToValue = cms[i].View;
                }
                else if (i == 36)
                {
                    this.groupBox12.Text = cms[i].UserName;

                    this.counter23.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter23.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter23.ToValue = cms[i].Sub;

                    this.counter24.DigitCount = cms[i].View.ToString().Length;
                    this.counter24.Value = cms[i].View - new Random().Next(s, t);
                    this.counter24.ToValue = cms[i].View;
                }
                else if (i == 37)
                {
                    this.groupBox13.Text = cms[i].UserName;

                    this.counter25.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter25.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter24.ToValue = cms[i].Sub;

                    this.counter26.DigitCount = cms[i].View.ToString().Length;
                    this.counter26.Value = cms[i].View - new Random().Next(s, t);
                    this.counter26.ToValue = cms[i].View;
                }
                else if (i == 38)
                {
                    this.groupBox14.Text = cms[i].UserName;

                    this.counter27.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter27.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter27.ToValue = cms[i].Sub;

                    this.counter28.DigitCount = cms[i].View.ToString().Length;
                    this.counter28.Value = cms[i].View - new Random().Next(s, t);
                    this.counter28.ToValue = cms[i].View;
                }
                else if (i == 39)
                {
                    this.groupBox15.Text = cms[i].UserName;

                    this.counter29.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter29.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter29.ToValue = cms[i].Sub;

                    this.counter30.DigitCount = cms[i].View.ToString().Length;
                    this.counter30.Value = cms[i].View - new Random().Next(s, t);
                    this.counter30.ToValue = cms[i].View;
                }
                else if (i == 40)
                {
                    this.groupBox16.Text = cms[i].UserName;

                    this.counter31.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter31.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter31.ToValue = cms[i].Sub;

                    this.counter32.DigitCount = cms[i].View.ToString().Length;
                    this.counter32.Value = cms[i].View - new Random().Next(s, t);
                    this.counter32.ToValue = cms[i].View;
                }
                else if (i == 41)
                {
                    this.groupBox17.Text = cms[i].UserName;

                    this.counter33.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter33.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter33.ToValue = cms[i].Sub;

                    this.counter34.DigitCount = cms[i].View.ToString().Length;
                    this.counter34.Value = cms[i].View - new Random().Next(s, t);
                    this.counter34.ToValue = cms[i].View;
                }
                else if (i == 42)
                {
                    this.groupBox18.Text = cms[i].UserName;

                    this.counter35.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter35.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter35.ToValue = cms[i].Sub;

                    this.counter36.DigitCount = cms[i].View.ToString().Length;
                    this.counter36.Value = cms[i].View - new Random().Next(s, t);
                    this.counter36.ToValue = cms[i].View;
                }
                else if (i == 43)
                {
                    this.groupBox19.Text = cms[i].UserName;

                    this.counter37.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter37.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter37.ToValue = cms[i].Sub;

                    this.counter38.DigitCount = cms[i].View.ToString().Length;
                    this.counter38.Value = cms[i].View - new Random().Next(s, t);
                    this.counter38.ToValue = cms[i].View;
                }
                else if (i == 44)
                {
                    this.groupBox20.Text = cms[i].UserName;

                    this.counter39.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter39.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter39.ToValue = cms[i].Sub;

                    this.counter40.DigitCount = cms[i].View.ToString().Length;
                    this.counter40.Value = cms[i].View - new Random().Next(s, t);
                    this.counter40.ToValue = cms[i].View;
                }
                else if (i == 45)
                {
                    this.groupBox21.Text = cms[i].UserName;

                    this.counter41.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter41.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter41.ToValue = cms[i].Sub;

                    this.counter42.DigitCount = cms[i].View.ToString().Length;
                    this.counter42.Value = cms[i].View - new Random().Next(s, t);
                    this.counter42.ToValue = cms[i].View;
                }
                else if (i == 46)
                {
                    this.groupBox22.Text = cms[i].UserName;

                    this.counter43.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter43.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter44.ToValue = cms[i].Sub;

                    this.counter44.DigitCount = cms[i].View.ToString().Length;
                    this.counter44.Value = cms[i].View - new Random().Next(s, t);
                    this.counter44.ToValue = cms[i].View;
                }
                else if (i == 47)
                {
                    this.groupBox23.Text = cms[i].UserName;

                    this.counter45.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter45.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter45.ToValue = cms[i].Sub;

                    this.counter46.DigitCount = cms[i].View.ToString().Length;
                    this.counter46.Value = cms[i].View - new Random().Next(s, t);
                    this.counter46.ToValue = cms[i].View;
                }
                else if (i == 48)
                {
                    this.groupBox24.Text = cms[i].UserName;

                    this.counter47.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter47.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter47.ToValue = cms[i].Sub;

                    this.counter48.DigitCount = cms[i].View.ToString().Length;
                    this.counter48.Value = cms[i].View - new Random().Next(s, t);
                    this.counter48.ToValue = cms[i].View;
                }
                else if (i == 49)
                {
                    this.groupBox25.Text = cms[i].UserName;

                    this.counter49.DigitCount = cms[i].Sub.ToString().Length;
                    this.counter49.Value = cms[i].Sub - new Random().Next(s, t);
                    this.counter49.ToValue = cms[i].Sub;

                    this.counter50.DigitCount = cms[i].View.ToString().Length;
                    this.counter50.Value = cms[i].View - new Random().Next(s, t);
                    this.counter50.ToValue = cms[i].View;
                }
            }
        }

        public void ReMonitor(List<ChannelMeta> cms)
        {

            cms = cms.OrderByDescending(m => m.Sub).ToList();

            int lv1 = new Random().Next(0, 49);
            int lv2 = new Random().Next(0, 49);

            bool dd = true;


            for (int i = 0; i < cms.Count; i++)
            {
                if (dd)
                {
                    if (lv1 == i)
                    {
                        cms[i].Sub++;
                        dd = false;
                    }
                }
                else
                {
                    if (lv2 == i)
                    {
                        cms[i].View++;
                        dd = true;
                    }
                }

               
                if (i == 0)
                {
                    this.gb1.Text = cms[i].UserName;

                    this.sb1.ToValue = cms[i].Sub;

                    this.tv1.ToValue = cms[i].View;

                }

                else if (i == 1)
                {
                    this.gb2.Text = cms[i].UserName;

                    this.sb2.ToValue = cms[i].Sub;

                    this.tv2.ToValue = cms[i].View;
                }

                else if (i == 2)
                {
                    this.gb3.Text = cms[i].UserName;

                    this.sb3.ToValue = cms[i].Sub;

                    this.tv3.ToValue = cms[i].View;
                }

                else if (i == 3)
                {
                    this.gb4.Text = cms[i].UserName;

                    this.sb4.ToValue = cms[i].Sub;

                    this.tv4.ToValue = cms[i].View;
                }

                else if (i == 4)
                {
                    this.gb5.Text = cms[i].UserName;

                    this.sb5.ToValue = cms[i].Sub;

                    this.tv5.ToValue = cms[i].View;
                }

                else if (i == 5)
                {
                    this.gb6.Text = cms[i].UserName;

                    this.sb6.ToValue = cms[i].Sub;

                    this.tv6.ToValue = cms[i].View;
                }

                if (i == 6)
                {
                    this.gb7.Text = cms[i].UserName;

                    this.sb7.ToValue = cms[i].Sub;

                    this.tv7.ToValue = cms[i].View;
                }

                else if (i == 7)
                {
                    this.gb8.Text = cms[i].UserName;

                    this.sb8.ToValue = cms[i].Sub;

                    this.tv8.ToValue = cms[i].View;
                }

                else if (i == 8)
                {
                    this.gb9.Text = cms[i].UserName;

                    this.sb9.ToValue = cms[i].Sub;

                    this.tv9.ToValue = cms[i].View;
                }

                else if (i == 9)
                {
                    this.gb10.Text = cms[i].UserName;

                    this.sb10.ToValue = cms[i].Sub;

                    this.tv10.ToValue = cms[i].View;
                }

                else if (i == 10)
                {
                    this.gb11.Text = cms[i].UserName;

                    this.sb11.ToValue = cms[i].Sub;

                    this.tv11.ToValue = cms[i].View;
                }
                else if (i == 11)
                {
                    this.gb12.Text = cms[i].UserName;

                    this.sb12.ToValue = cms[i].Sub;

                    this.tv12.ToValue = cms[i].View;
                }
                else if (i == 12)
                {
                    this.gb13.Text = cms[i].UserName;

                    this.sb13.ToValue = cms[i].Sub;

                    this.tv13.ToValue = cms[i].View;
                }
                else if (i == 13)
                {
                    this.gb14.Text = cms[i].UserName;

                    this.sb14.ToValue = cms[i].Sub;

                    this.tv14.ToValue = cms[i].View;
                }
                else if (i == 14)
                {
                    this.gb15.Text = cms[i].UserName;

                    this.sb15.ToValue = cms[i].Sub;

                    this.tv15.ToValue = cms[i].View;
                }
                else if (i == 15)
                {
                    this.gb16.Text = cms[i].UserName;

                    this.sb16.ToValue = cms[i].Sub;

                    this.tv16.ToValue = cms[i].View;
                }
                else if (i == 16)
                {
                    this.gb17.Text = cms[i].UserName;

                    this.sb17.ToValue = cms[i].Sub;

                    this.tv17.ToValue = cms[i].View;
                }
                else if (i == 17)
                {
                    this.gb18.Text = cms[i].UserName;

                    this.sb18.ToValue = cms[i].Sub;

                    this.tv18.ToValue = cms[i].View;
                }
                else if (i == 18)
                {
                    this.gb19.Text = cms[i].UserName;

                    this.sb19.ToValue = cms[i].Sub;

                    this.tv19.ToValue = cms[i].View;
                }
                else if (i == 19)
                {
                    this.gb20.Text = cms[i].UserName;

                    this.sb20.ToValue = cms[i].Sub;

                    this.tv20.ToValue = cms[i].View;
                }
                else if (i == 20)
                {
                    this.gb21.Text = cms[i].UserName;

                    this.sb21.ToValue = cms[i].Sub;

                    this.tv21.ToValue = cms[i].View;
                }
                else if (i == 21)
                {
                    this.gb22.Text = cms[i].UserName;

                    this.sb22.ToValue = cms[i].Sub;

                    this.tv22.ToValue = cms[i].View;
                }
                else if (i == 22)
                {
                    this.gb23.Text = cms[i].UserName;

                    this.sb23.ToValue = cms[i].Sub;

                    this.tv23.ToValue = cms[i].View;
                }
                else if (i == 23)
                {
                    this.gb24.Text = cms[i].UserName;

                    this.sb24.ToValue = cms[i].Sub;

                    this.tv24.ToValue = cms[i].View;
                }
                else if (i == 24)
                {
                    this.gb25.Text = cms[i].UserName;

                    this.sb25.ToValue = cms[i].Sub;

                    this.tv25.ToValue = cms[i].View;
                }
                else if (i == 25)
                {
                    this.groupBox1.Text = cms[i].UserName;

                    this.counter1.ToValue = cms[i].Sub;

                    this.counter2.ToValue = cms[i].View;
                }
                else if (i == 26)
                {
                    this.groupBox2.Text = cms[i].UserName;

                    this.counter3.ToValue = cms[i].Sub;

                    this.counter4.ToValue = cms[i].View;
                }
                else if (i == 27)
                {
                    this.groupBox3.Text = cms[i].UserName;

                    this.counter5.ToValue = cms[i].Sub;

                    this.counter6.ToValue = cms[i].View;
                }
                else if (i == 28)
                {
                    this.groupBox4.Text = cms[i].UserName;

                    this.counter7.ToValue = cms[i].Sub;

                    this.counter8.ToValue = cms[i].View;
                }
                else if (i == 29)
                {
                    this.groupBox5.Text = cms[i].UserName;

                    this.counter9.ToValue = cms[i].Sub;

                    this.counter10.ToValue = cms[i].View;
                }
                else if (i == 30)
                {
                    this.groupBox6.Text = cms[i].UserName;

                    this.counter11.ToValue = cms[i].Sub;

                    this.counter12.ToValue = cms[i].View;
                }
                else if (i == 31)
                {
                    this.groupBox7.Text = cms[i].UserName;

                    this.counter13.ToValue = cms[i].Sub;

                    this.counter14.ToValue = cms[i].View;
                }
                else if (i == 32)
                {
                    this.groupBox8.Text = cms[i].UserName;

                    this.counter15.ToValue = cms[i].Sub;

                    this.counter16.ToValue = cms[i].View;
                }
                else if (i == 33)
                {
                    this.groupBox9.Text = cms[i].UserName;

                    this.counter17.ToValue = cms[i].Sub;

                    this.counter18.ToValue = cms[i].View;
                }
                else if (i == 34)
                {
                    this.groupBox10.Text = cms[i].UserName;

                    this.counter19.ToValue = cms[i].Sub;

                    this.counter20.ToValue = cms[i].View;
                }
                else if (i == 35)
                {
                    this.groupBox11.Text = cms[i].UserName;

                    this.counter21.ToValue = cms[i].Sub;

                    this.counter22.ToValue = cms[i].View;
                }
                else if (i == 36)
                {
                    this.groupBox12.Text = cms[i].UserName;

                    this.counter23.ToValue = cms[i].Sub;

                    this.counter24.ToValue = cms[i].View;
                }
                else if (i == 37)
                {
                    this.groupBox13.Text = cms[i].UserName;

                    this.counter25.ToValue = cms[i].Sub;

                    this.counter26.ToValue = cms[i].View;
                }
                else if (i == 38)
                {
                    this.groupBox14.Text = cms[i].UserName;

                    this.counter27.ToValue = cms[i].Sub;

                    this.counter28.ToValue = cms[i].View;
                }
                else if (i == 39)
                {
                    this.groupBox15.Text = cms[i].UserName;

                    this.counter29.ToValue = cms[i].Sub;

                    this.counter30.ToValue = cms[i].View;
                }
                else if (i == 40)
                {
                    this.groupBox16.Text = cms[i].UserName;

                    this.counter31.ToValue = cms[i].Sub;

                    this.counter32.ToValue = cms[i].View;
                }
                else if (i == 41)
                {
                    this.groupBox17.Text = cms[i].UserName;

                    this.counter33.ToValue = cms[i].Sub;

                    this.counter34.ToValue = cms[i].View;
                }
                else if (i == 42)
                {
                    this.groupBox18.Text = cms[i].UserName;

                    this.counter35.ToValue = cms[i].Sub;

                    this.counter36.ToValue = cms[i].View;
                }
                else if (i == 43)
                {
                    this.groupBox19.Text = cms[i].UserName;

                    this.counter37.ToValue = cms[i].Sub;

                    this.counter38.ToValue = cms[i].View;
                }
                else if (i == 44)
                {
                    this.groupBox20.Text = cms[i].UserName;

                    this.counter39.ToValue = cms[i].Sub;

                    this.counter40.ToValue = cms[i].View;
                }
                else if (i == 45)
                {
                    this.groupBox21.Text = cms[i].UserName;

                    this.counter41.ToValue = cms[i].Sub;

                    this.counter42.ToValue = cms[i].View;
                }
                else if (i == 46)
                {
                    this.groupBox22.Text = cms[i].UserName;

                    this.counter44.ToValue = cms[i].Sub;

                    this.counter44.ToValue = cms[i].View;
                }
                else if (i == 47)
                {
                    this.groupBox23.Text = cms[i].UserName;

                    this.counter45.ToValue = cms[i].Sub;

                    this.counter46.ToValue = cms[i].View;
                }
                else if (i == 48)
                {
                    this.groupBox24.Text = cms[i].UserName;

                    this.counter47.ToValue = cms[i].Sub;

                    this.counter48.ToValue = cms[i].View;
                }
                else if (i == 49)
                {
                    this.groupBox25.Text = cms[i].UserName;

                    this.counter49.ToValue = cms[i].Sub;

                    this.counter50.ToValue = cms[i].View;
                }

            }

            IsBusy = false;
        }

        public async Task<JObject> getData(string uri)
        {
            var cl = new HttpClient();

            var data = await cl.GetStringAsync(uri);

            return JObject.Parse(data);
        }

        private void counter3_CounterFinish(object sender, EventArgs e)
        {

        }

        private void counter2_CounterFinish(object sender, EventArgs e)
        {

        }

        private void counter1_CounterFinish(object sender, EventArgs e)
        {

        }

        private void tv6_CounterFinish(object sender, EventArgs e)
        {

        }

        private void gb14_Enter(object sender, EventArgs e)
        {

        }
    }
}
