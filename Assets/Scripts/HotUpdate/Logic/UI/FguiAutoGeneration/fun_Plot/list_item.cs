/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class list_item : GComponent
    {
        public GImage n1;
        public GTextField titleLab;
        public GButton play_btn;
        public const string URL = "ui://vucpfjl8accs1yjp831";

        public static list_item CreateInstance()
        {
            return (list_item)UIPackage.CreateObject("fun_Plot", "list_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            play_btn = (GButton)GetChildAt(2);
        }
    }
}