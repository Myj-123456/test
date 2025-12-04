/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class order_got : GComponent
    {
        public GImage n19;
        public GTextField title;
        public GList list;
        public GGroup pos;
        public const string URL = "ui://6bdpq80ku0i31yjp7s2";

        public static order_got CreateInstance()
        {
            return (order_got)UIPackage.CreateObject("common", "order_got");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n19 = (GImage)GetChildAt(0);
            title = (GTextField)GetChildAt(1);
            list = (GList)GetChildAt(2);
            pos = (GGroup)GetChildAt(3);
        }
    }
}