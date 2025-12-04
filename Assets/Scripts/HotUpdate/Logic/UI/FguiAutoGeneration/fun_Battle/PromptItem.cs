/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class PromptItem : GComponent
    {
        public Controller c1;
        public GImage n1;
        public GTextField txt_name;
        public GImage n4;
        public GImage n3;
        public const string URL = "ui://z1b78orph8da2s";

        public static PromptItem CreateInstance()
        {
            return (PromptItem)UIPackage.CreateObject("fun_Battle", "PromptItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            txt_name = (GTextField)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
        }
    }
}