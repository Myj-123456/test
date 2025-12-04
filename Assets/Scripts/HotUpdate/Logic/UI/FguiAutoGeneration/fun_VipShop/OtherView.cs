/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class OtherView : GComponent
    {
        public GLoader bg;
        public GList list;
        public const string URL = "ui://wm7arakybwswl";

        public static OtherView CreateInstance()
        {
            return (OtherView)UIPackage.CreateObject("fun_VipShop", "OtherView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            list = (GList)GetChildAt(1);
        }
    }
}