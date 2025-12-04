/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class like_item : GButton
    {
        public Controller type;
        public Controller select;
        public GImage n1;
        public GLoader pic;
        public GComponent ike;
        public GImage n5;
        public GImage n4;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yz";

        public static like_item CreateInstance()
        {
            return (like_item)UIPackage.CreateObject("fun_MyInfo", "like_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            select = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            ike = (GComponent)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
        }
    }
}