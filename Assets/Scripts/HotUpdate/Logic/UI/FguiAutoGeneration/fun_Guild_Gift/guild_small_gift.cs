/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Gift
{
    public partial class guild_small_gift : GComponent
    {
        public GImage n6;
        public GImage n7;
        public GImage n9;
        public GLoader icon;
        public GRichTextField nameLab;
        public GTextField limitLab;
        public GTextField titleLab;
        public GButton getBtn;
        public GTextField timeLab;
        public const string URL = "ui://qca8xihatewh2";

        public static guild_small_gift CreateInstance()
        {
            return (guild_small_gift)UIPackage.CreateObject("fun_Guild_Gift", "guild_small_gift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            n9 = (GImage)GetChildAt(2);
            icon = (GLoader)GetChildAt(3);
            nameLab = (GRichTextField)GetChildAt(4);
            limitLab = (GTextField)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
            getBtn = (GButton)GetChildAt(7);
            timeLab = (GTextField)GetChildAt(8);
        }
    }
}