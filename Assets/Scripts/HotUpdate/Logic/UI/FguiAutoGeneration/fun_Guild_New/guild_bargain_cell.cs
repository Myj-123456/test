/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_bargain_cell : GComponent
    {
        public Controller status;
        public GImage n14;
        public GImage n1;
        public GTextField num;
        public GTextField nameLab;
        public GTextField txt_id;
        public GTextField txt_lab;
        public GLoader pic;
        public const string URL = "ui://qz6135j3s62s1yjp7yw";

        public static guild_bargain_cell CreateInstance()
        {
            return (guild_bargain_cell)UIPackage.CreateObject("fun_Guild_New", "guild_bargain_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            num = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            txt_id = (GTextField)GetChildAt(4);
            txt_lab = (GTextField)GetChildAt(5);
            pic = (GLoader)GetChildAt(6);
        }
    }
}