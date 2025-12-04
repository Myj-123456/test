/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class picBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://44kfvb3rm3gh1yjp7wa";

        public static picBtn CreateInstance()
        {
            return (picBtn)UIPackage.CreateObject("fun_FlowerGold", "picBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}