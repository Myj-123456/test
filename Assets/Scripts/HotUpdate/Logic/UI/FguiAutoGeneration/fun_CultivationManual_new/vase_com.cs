/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class vase_com : GComponent
    {
        public GImage n1;
        public change_btn leftBtn;
        public change_btn rightBtn;
        public GList list;
        public const string URL = "ui://ekoic0wrjfk51yjp7xz";

        public static vase_com CreateInstance()
        {
            return (vase_com)UIPackage.CreateObject("fun_CultivationManual_new", "vase_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            leftBtn = (change_btn)GetChildAt(1);
            rightBtn = (change_btn)GetChildAt(2);
            list = (GList)GetChildAt(3);
        }
    }
}