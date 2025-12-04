/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_applicant : GComponent
    {
        public GImage n3;
        public GLoader bg;
        public GImage n6;
        public GList list_applicant;
        public GButton close_btn;
        public GButton btn_refuseAll;
        public const string URL = "ui://qz6135j3tewh1yjp7zu";

        public static guild_applicant CreateInstance()
        {
            return (guild_applicant)UIPackage.CreateObject("fun_Guild_New", "guild_applicant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            list_applicant = (GList)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            btn_refuseAll = (GButton)GetChildAt(5);
        }
    }
}