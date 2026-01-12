/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class detailed_view : GComponent
    {
        public GLoader bg;
        public GTextField Text_Title;
        public GImage n3;
        public GButton btn_close;
        public GList list;
        public const string URL = "ui://97nah3khj68sw4";

        public static detailed_view CreateInstance()
        {
            return (detailed_view)UIPackage.CreateObject("fun_Draw", "detailed_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            Text_Title = (GTextField)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            btn_close = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}