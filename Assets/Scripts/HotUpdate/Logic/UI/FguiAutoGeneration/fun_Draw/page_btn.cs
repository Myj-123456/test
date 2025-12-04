/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller type;
        public GLoader flower;
        public GImage n3;
        public GLoader dress;
        public GTextField titleLab;
        public const string URL = "ui://97nah3kh11rnul";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_Draw", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            flower = (GLoader)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            dress = (GLoader)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}