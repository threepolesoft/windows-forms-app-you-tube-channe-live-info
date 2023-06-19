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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Timer tm;

        public List<ChannelMeta> cnl = new List<ChannelMeta>();

        private void Form2_Load(object sender, EventArgs e)
        {

            IsBusy = true;

            ChannelList cn = new ChannelList();
            cnl = cn.cm;


            sX = (panel1.Width / 5) - 2;


            mY = panel2.Height - 5;

            Init();

            LoadData();

            tm = new Timer();
            tm.Interval = 300;
            tm.Start();
            tm.Tick += tm_Tick;
        }

        void tm_Tick(object sender, EventArgs e)
        {

            if (!IsBusy)
            {
                IsBusy = true;
                try
                {
                    reInit(cnl);
                }
                catch (Exception)
                {
                    LoadData();
                }

            }
        }


        public bool IsBusy = false;

        public int mX = 0;
        public int mY = 85;

        public int sX = 240;
        public int sY = 62;

        public void Init()
        {

            int lbSlX = 12;
            int lbSlY = 20 + mY;

            int pbX = 40;
            int pBY = 10 + mY;

            int lbTlX = 90;
            int lbTlY = 15 + mY;

            int cnSbX = 90;
            int cnSbY = 30 + mY;

            int lbId = 0;
            int pbId = 0;
            int tlId = 0;
            int cnId = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {

                    lbId++;
                    pbId++;
                    tlId++;
                    cnId++;


                    Label lsSl = new Label();
                    PictureBox pbLogo = new PictureBox();
                    Label lbTl = new Label();
                    CounterLib.Counter cnSb = new CounterLib.Counter();

                    panel1.Controls.Add(lsSl);
                    panel1.Controls.Add(pbLogo);
                    panel1.Controls.Add(lbTl);
                    panel1.Controls.Add(cnSb);

                    lsSl.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    lsSl.AutoSize = true;
                    lsSl.Location = new System.Drawing.Point(lbSlX, lbSlY);
                    lsSl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    lsSl.Name = "lbId" + lbId.ToString();
                    lsSl.Size = new System.Drawing.Size(25, 19);
                    lsSl.Text = lbId.ToString();

                    pbLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    pbLogo.Location = new System.Drawing.Point(pbX, pBY);
                    pbLogo.Name = "pbId" + pbId.ToString();
                    pbLogo.Size = new System.Drawing.Size(45, 45);
                    pbLogo.ImageLocation = "https://yt3.ggpht.com/ytc/AMLnZu8QjzoEfxMcwiyCFLmXNIWP5WEBXHWSHfWivzC6=s176-c-k-c0x00ffffff-no-rj-mo";
                    pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                    lbTl.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    lbTl.AutoSize = true;
                    lbTl.Location = new System.Drawing.Point(lbTlX, lbTlY);
                    lbTl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    lbTl.Name = "tlId" + tlId.ToString();
                    lbTl.Size = new System.Drawing.Size(40, 19);
                    lbTl.Text = "Title";
                    lbTl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    cnSb.Anchor = System.Windows.Forms.AnchorStyles.Top;
                    cnSb.Location = new System.Drawing.Point(cnSbX, cnSbY);
                    cnSb.Name = "cnId" + cnId.ToString();
                    cnSb.NumbersTheme = CounterLib.CounterNumbersTheme.n01;
                    cnSb.Size = new System.Drawing.Size(75, 27);
                    cnSb.TimerInterval = 200;

                    lbSlX += sX;
                    pbX += sX;
                    lbTlX += sX;
                    cnSbX += sX;
                }

                lbSlX = 12;
                pbX = 40;
                lbTlX = 90;
                cnSbX = 90;

                lbSlY += sY;
                pBY += sY;
                lbTlY += sY;
                cnSbY += sY;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;

            Pen p = new Pen(Color.Black, 2);

            int xs = 5;
            int xe = sX * 5;

            int ys = 5;
            int ye = 5;

            g.DrawLine(p, new Point(xs, ys + mY), new Point(xe, ye + mY));

            for (int i = 0; i < 10; i++)
            {
                ys = ye += sY;

                g.DrawLine(p, new Point(xs, ys + mY), new Point(xe, ye + mY));
            }



            xs = 5;

            ys = xe = 4;

            ye = sY * 10 + 6;

            g.DrawLine(p, new Point(xs, ys + mY), new Point(xe, ye + mY));

            for (int i = 0; i < 10; i++)
            {
                xs = xe += sX - 1;

                g.DrawLine(p, new Point(xs, ys + mY), new Point(xe, ye + mY));
            }

        }


        public string key = "AIzaSyAjXYZOBsuouPMZkODYP2U0ORckmNQWdyk";
        public string part = "part=statistics&part=snippet";
        public async void LoadData()
        {
            string error = "";

            for (int i = 0; i < cnl.Count; i++)
            {

                try
                {
                    string uri = "";

                    if (cnl[i].UserName.ToString().Contains("Name-"))
                    {
                        uri="https://www.googleapis.com/youtube/v3/channels?" + part + "&forUsername=" + cnl[i].UserName.ToString().Replace("Name-", "") + "&key=" + key;
                    }
                    else
                    {
                        uri = "https://www.googleapis.com/youtube/v3/channels?" + part + "&id=" + cnl[i].UserName.ToString().Replace("Id-", "") + "&key=" + key;
                    }

                    // await Task.Delay(5000);

                    var data = await getData(uri);

                    var items = JArray.Parse(data["items"].ToString());

                    var statistics = JObject.Parse(items[0]["statistics"].ToString());

                    var snippet = JObject.Parse(items[0]["snippet"].ToString());




                    string title = snippet["title"].ToString();
                    string thumbnails = snippet["thumbnails"]["default"]["url"].ToString();


                    string logo = JObject.Parse(items[0]["snippet"].ToString())["title"].ToString();


                    cnl[i].Title = title;
                    cnl[i].Logo = thumbnails;
                    cnl[i].Sub = Convert.ToInt64(statistics["subscriberCount"].ToString()) - 3456;
                    cnl[i].View = Convert.ToInt64(statistics["viewCount"].ToString()) - 7544;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            }

            setInit(cnl);
        }

        public void setInit(List<ChannelMeta> cnl)
        {

            int id = 0;

            cnl = cnl.OrderByDescending(m => m.Sub).ToList();

            for (int i = 0; i < cnl.Count; i++)
            {
                id++;

                try
                {
                    Label lbSl = panel1.Controls.Find("lbId" + id.ToString(), false).First() as Label;
                    if (lbSl != null)
                    {
                        lbSl.Text = id.ToString();
                    }

                    PictureBox pb = panel1.Controls.Find("pbId" + id.ToString(), false).First() as PictureBox;
                    if (pb != null)
                    {
                        pb.ImageLocation = cnl[i].Logo;
                    }

                    Label lbTl = panel1.Controls.Find("tlId" + id.ToString(), false).First() as Label;

                    if (lbTl != null)
                    {
                        if (cnl[i].Title.Length > 15)
                        {
                            lbTl.Text = cnl[i].Title.Substring(0, 14);
                        }
                        else
                        {
                            lbTl.Text = cnl[i].Title;
                        }

                    }

                    CounterLib.Counter cnSb = panel1.Controls.Find("cnId" + id.ToString(), false).First() as CounterLib.Counter;

                    if (cnSb != null)
                    {
                        cnSb.DigitCount = cnl[i].Sub.ToString().Length;
                        cnSb.Value = cnl[i].Sub;
                        cnSb.ToValue = cnl[i].Sub;
                    }

                }
                catch (Exception)
                {

                }

                if (i == 49)
                {
                    break;
                }
            }

            IsBusy = false;
        }

        public void reInit(List<ChannelMeta> cnl)
        {
            int id = 0;

            cnl = cnl.OrderByDescending(m => m.Sub).ToList();

            int lv = new Random().Next(0, 49);

            for (int i = 0; i < cnl.Count; i++)
            {
                id++;

                CounterLib.Counter cnSb = panel1.Controls.Find("cnId" + id.ToString(), false).First() as CounterLib.Counter;

                try
                {

                    if (cnSb != null)
                    {

                        if (lv == i)
                        {
                            cnl[i].Sub++;
                            cnSb.ToValue = cnl[i].Sub;
                            cnSb.NumbersTheme = CounterLib.CounterNumbersTheme.n02;
                            cnSb.CounterFinish+=cnSb_CounterFinish;
                        }

                    }

                }
                catch (Exception)
                {

                }

                if (i == 49)
                {
                    break;
                }
            }

            IsBusy = false;
        }

        void cnSb_CounterFinish(object sender, EventArgs e)
        {
            CounterLib.Counter cn = (CounterLib.Counter)sender;
            cn.NumbersTheme = CounterLib.CounterNumbersTheme.n03;
        }

        public async Task<JObject> getData(string uri)
        {
            var cl = new HttpClient();

           

            var data = await cl.GetStringAsync(uri);

            return JObject.Parse(data);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
        }

    }

}
