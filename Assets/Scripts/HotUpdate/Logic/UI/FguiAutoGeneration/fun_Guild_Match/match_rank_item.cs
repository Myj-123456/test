/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_rank_item : GComponent
    {
        public Controller status;
        public GImage n16;
        public GImage n20;
        public GImage n21;
        public GImage n22;
        public GImage n8;
        public GImage n11;
        public GImage n12;
        public GImage n13;
        public GImage n9;
        public GImage n10;
        public GLoader3D spine;
        public GLoader3D pro1;
        public GLoader3D spine1;
        public GTextField rankLan;
        public GTextField nameLab;
        public GTextField scoreLab;
        public guild_icon guild_icon;
        public const string URL = "ui://qefze8qir0nz3k";

        public static match_rank_item CreateInstance()
        {
            return (match_rank_item)UIPackage.CreateObject("fun_Guild_Match", "match_rank_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n16 = (GImage)GetChildAt(0);
            n20 = (GImage)GetChildAt(1);
            n21 = (GImage)GetChildAt(2);
            n22 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            n12 = (GImage)GetChildAt(6);
            n13 = (GImage)GetChildAt(7);
            n9 = (GImage)GetChildAt(8);
            n10 = (GImage)GetChildAt(9);
            spine = (GLoader3D)GetChildAt(10);
            pro1 = (GLoader3D)GetChildAt(11);
            spine1 = (GLoader3D)GetChildAt(12);
            rankLan = (GTextField)GetChildAt(13);
            nameLab = (GTextField)GetChildAt(14);
            scoreLab = (GTextField)GetChildAt(15);
            guild_icon = (guild_icon)GetChildAt(16);
        }
    }
}