/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class flower_ike_vase : GComponent
    {
        public GImage n1;
        public GLoader bg;
        public GImage n4;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://ekoic0wrq47x1yjp7wt";

        public static flower_ike_vase CreateInstance()
        {
            return (flower_ike_vase)UIPackage.CreateObject("fun_CultivationManual_new", "flower_ike_vase");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
        }
    }
}