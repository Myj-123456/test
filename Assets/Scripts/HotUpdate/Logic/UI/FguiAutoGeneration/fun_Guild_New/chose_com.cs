/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class chose_com : GComponent
    {
        public Controller chose;
        public GImage n2;
        public GList list;
        public const string URL = "ui://qz6135j3m3gh1yjp80z";

        public static chose_com CreateInstance()
        {
            return (chose_com)UIPackage.CreateObject("fun_Guild_New", "chose_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            chose = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
        }
    }
}