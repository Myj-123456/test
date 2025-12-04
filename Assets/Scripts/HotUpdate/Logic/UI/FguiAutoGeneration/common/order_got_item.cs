/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class order_got_item : GComponent
    {
        public GImage n5;
        public GLoader pic;
        public GTextField txt_num;
        public GTextField txt_name;
        public const string URL = "ui://6bdpq80ku0i31yjp7s3";

        public static order_got_item CreateInstance()
        {
            return (order_got_item)UIPackage.CreateObject("common", "order_got_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            txt_num = (GTextField)GetChildAt(2);
            txt_name = (GTextField)GetChildAt(3);
        }
    }
}