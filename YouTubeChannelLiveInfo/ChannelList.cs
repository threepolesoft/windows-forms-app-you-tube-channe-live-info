using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeChannelLiveInfo
{
    public class ChannelList
    {
        // inlude channel user name because this "You Data api v3" get channel information by Channel user name ,,,,,
        //public string[] ChannelUserName = { 
        //                                      "MrBeast6000", "jaazmultimediafilm", "zeemusiccompany", "badabunOficial", "Pewdiepie",
        //                                      "dhruvrathee", "tseries", "YouTubeHelp", "BANGTANTV", "Movieclips", 
        //                                      "YRF", "whinderssonnunes", "JuegaGerman", "eaglemusicbdofficial", "bangtantv",
        //                                      "WWE", "EminemMusic", "HolaSoyGerman", "ColorsTV", "onemeeeliondollars",
        //                                      "thewhistle", "pledis17", "TylerWardMusic", "LAHWF", "corycotton",
        //                                      "Noisey", "sonymusicindiaSME", "Nirvana", "YouTube", "tipsmusic",
        //                                      "Lush", "KickThePJ", "cdchoicelabel", "NickNimmin", "EdSheeran",
        //                                      "THiNKmediaTV", "videoinfluencers", "pledisartist", "movieclipsTRAILERS", "pledisnuest",
        //                                      "vcsabiavideos", "MOVIECLIPS", "KatyPerryVEVO", "Fernanfloo", "petermckinnon24",
        //                                      "creatoracademy", "ArianaGrandeVevo", "EditMyClips0", "infobellshindirhymes", "goldmineshindi"
        //                                  };

        public string[] ChannelUserName = { 
                                              "Name-tseries", "Id-UCOmHUn--16B90oW2L6FRR3A", "Name-SmartBooksMedia", "Name-tseriesbhakti", "Name-JuegaGerman", 
                                              "Name-checkgate", "Id-UCXFeIOYbhWHrXCIqerycvNQ",  "Id-UCmo9ZEJ3ipgaZdkiRRYtLAg", "Name-sonymusicindiaSME", "Name-infobellshindirhymes",
                                              "Name-setindia", "Name-GoldminesTelefilms", "Name-TheChuChuTV", "Name-EdSheeran", "Name-badabunOficial",
                                              "Name-Pewdiepie", "Name-sabtv", "Name-Movieclips", "Name-ReinoMariaElenaWalsh", "Name-fernanfloo",
                                              "Name-MrBeast6000", "Name-BANGTANTV", "Id-UCEdvpU2pFRCVqU6yIPyTpMQ", "Id-UC9CoOnJkIBMdeijd9qYoT_g", "Name-FelipeNeto",
                                              "Id-UCk8GzjMOrta8yxDcKfylJYw", "Id-UCIwFjwMjI0y7PDBVEO9-bkQ", "Name-ColorsTV", "Name-LooLooKids", "Name-whinderssonnunes",
                                              "Id-UCJplp5SjeGSdVdwsfb9Q7lQ", "Name-KickThePJ", "Name-DigitalShockwave", "Name-YRF", "Name-thewhistle",
                                              "Name-WWE", "Name-CanalKondZilla", "Name-eminemmusic", "Id-UCqECaJ8Gagnn7YCbPEzWH6g", "Name-HolaSoyGerman",
                                              "Name-zeemusiccompany", "Name-zeetv", "Name-aajtaktv", "Name-corycotton", "Name-vcsabiavideos",
                                              "Id-UCvlE5gTbOvjiolFlEm-c_Ow", "Name-filmigaane", "Name-tipsmusic",  "Id-UCiGm_E4ZwYSHV3bcW1pnSeQ",  "Name-KatyPerryvevo", 
                                          };

        public List<ChannelMeta> cm = new List<ChannelMeta>();

        public ChannelList()
        {
            for (int i = 0; i < ChannelUserName.Length; i++)
            {

                int s = new Random().Next(143111, 3323111);
                int t = new Random().Next(2222111, 4424985);

                cm.Add(new ChannelMeta
                {
                    UserName = ChannelUserName[i].ToString(),
                    Title = "",
                    Logo = "",
                    Sub = new Random().Next(s, t),
                    View = new Random().Next(new Random().Next(111111, 3333111), new Random().Next(2222111, 44343453)),
                });

                s = t = 0;
            }
        }
    }
}
