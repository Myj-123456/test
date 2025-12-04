/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_shop_cell : GComponent
    {
        public Controller limit;
        public Controller unlock;
        public GImage n9;
        public GLoader pic;
        public GLoader costImg;
        public GTextField limitLab;
        public GTextField lockLab;
        public GTextField nameLab;
        public GTextField numLab;
        public GTextField costLab;
        public const string URL = "ui://qz6135j3m3gh1yjp80r";

        public static guild_shop_cell CreateInstance()
        {
            return (guild_shop_cell)UIPackage.CreateObject("fun_Guild_New", "guild_shop_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            limit = GetControllerAt(0);
            unlock = GetControllerAt(1);
            n9 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            costImg = (GLoader)GetChildAt(2);
            limitLab = (GTextField)GetChildAt(3);
            lockLab = (GTextField)GetChildAt(4);
            nameLab = (GTextField)GetChildAt(5);
            numLab = (GTextField)GetChildAt(6);
            costLab = (GTextField)GetChildAt(7);
        }
    }
}