/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class getReward_item : GComponent
    {
        public GImage n6;
        public GLoader pic;
        public GTextField txt_name;
        public GTextField txt_num;
        public const string URL = "ui://6bdpq80ku0i31yjp7s6";

        public static getReward_item CreateInstance()
        {
            return (getReward_item)UIPackage.CreateObject("common", "getReward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            txt_name = (GTextField)GetChildAt(2);
            txt_num = (GTextField)GetChildAt(3);
        }
    }
}