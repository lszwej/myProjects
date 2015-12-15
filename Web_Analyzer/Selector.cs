using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Łukasz_Szwej_Projekt
{
    class Selector
    {
        private readonly string[] patterns = 
        {@"doctype;<!DOCTYPE\s+(?<doctype>.+?)\s*>",
        @"language;<html.+?lang=[""|''](?<language>.+?)[''|""].*?>",
        @"charset;<meta.+?charset=[""|'']?(?<charset>.*?)[""|''].*?>",
        @"keyword;<meta.+?name=[''|""]keywords[''|""].+?content=[''|""](?<keyword>.+?)[''|""].*?>",
        @"title;<title.*?>(?<title>.+?)<\/title>",
        @"script;<script.+?(type=[''|""](text\/javascript)[''|""])?.*?>",
        @"css;<link.+?type=[''|""].*?(text\/css)[''|""].*?>",
        @"css-inline;<[a-z0-9]+.+?style=[''|""](.+?)[''|""].*?>",
        @"image;<img.+?src=[''|""](.+?)[''|""].*?>",
        @"header;<h[1-6].*>(.+)?<\/h[1-6]>",
        @"form;<form.*?>",
        @"input;<input.+?type=[''|""](.*?)[''|""].*?>",
        @"link;<a.+?href=[''|""](?<link>.+?)[''|""].*?>",};

        public string choose_pattern(string elem)
        {
            foreach (string temp in patterns)
            {
                string[] temp_pat = temp.Split(';');
                if (elem.Equals(temp_pat[0]))
                    return temp_pat[1];
            }

            return "";
        }
    }
}
