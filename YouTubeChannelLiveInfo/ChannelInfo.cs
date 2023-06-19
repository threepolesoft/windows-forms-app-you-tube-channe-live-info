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
    public partial class ChannelInfo : Form
    {
        public ChannelInfo()
        {
            InitializeComponent();
        }


        public string key = "AIzaSyAjXYZOBsuouPMZkODYP2U0ORckmNQWdyk";
        public string part = "part=statistics&part=snippet";

        private async void btnGet_Click(object sender, EventArgs e)
        {

            this.txtInfo.Text = string.Empty;

            var cl = new HttpClient();

            string uri = "https://www.googleapis.com/youtube/v3/channels?" + part + "&" + this.cmbFilter.Text + "=" + this.txtIdorUserName.Text + "&key=" + key;


            var data = JObject.Parse(await cl.GetStringAsync(uri));


            try
            {

                var items = JArray.Parse(data["items"].ToString());

                var statistics = JObject.Parse(items[0]["statistics"].ToString());

                var snippet = JObject.Parse(items[0]["snippet"].ToString());



                string title = snippet["title"].ToString();
                string thumbnails = snippet["thumbnails"]["default"]["url"].ToString();


                string logo = JObject.Parse(items[0]["snippet"].ToString())["title"].ToString();

                this.txtInfo.Text += "title : " + title + Environment.NewLine;
                this.txtInfo.Text += "Sub : " + statistics["subscriberCount"].ToString() + Environment.NewLine;

            }
            catch (Exception ex)
            {
                this.txtInfo.Text = string.Empty;

                this.txtInfo.Text = data.ToString();
            }
        }
    }
}
