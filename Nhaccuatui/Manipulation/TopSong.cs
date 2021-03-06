﻿using Nhaccuatui.Structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nhaccuatui.Manipulation
{
    namespace Charts
    {
        public class TopSong
        {
            private static string topVN = "http://www.nhaccuatui.com/bai-hat/top-20.nhac-viet.html";
            private static string topUS = "http://www.nhaccuatui.com/bai-hat/top-20.au-my.html";
            private static string topKR = "http://www.nhaccuatui.com/bai-hat/top-20.nhac-han.html";

            private List<NCTObject> vPop;
            private List<NCTObject> kPop;
            private List<NCTObject> uSUK;

            public List<NCTObject> VPop { get => vPop; set => vPop = value; }
            public List<NCTObject> KPop { get => kPop; set => kPop = value; }
            public List<NCTObject> USUK { get => uSUK; set => uSUK = value; }

            public TopSong()
            {
                VPop = new List<NCTObject>();
                KPop = new List<NCTObject>();
                USUK = new List<NCTObject>();

                GetTop.Get(topVN, VPop);
                GetTop.Get(topUS, USUK);
                GetTop.Get(topKR, KPop);
            }


            /// <summary>
            /// Get 20 most popular VPop song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllVPopSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (NCTObject song in VPop)
                {
                    list.Add(new Song(song.Path));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular USUK song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllUSUKSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (NCTObject song in USUK)
                {
                    list.Add(new Song(song.Path));
                }

                return list;
            }

            /// <summary>
            /// Get 20 most popular KPop song for 24 hours
            /// </summary>
            /// <returns>ObservableCollection<Song></returns>
            public ObservableCollection<Song> AllKPopSong()
            {
                ObservableCollection<Song> list = new ObservableCollection<Song>();

                foreach (NCTObject song in KPop)
                {
                    list.Add(new Song(song.Path));
                }

                return list;
            }

        }

    }
}
