/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class head_item : GButton
    {
        public Controller unlock;
        public Controller type;
        public Controller button;
        public GLoader pic;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yr";

        public static head_item CreateInstance()
        {
            return (head_item)UIPackage.CreateObject("fun_MyInfo", "head_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlock = GetControllerAt(0);
            type = GetControllerAt(1);
            button = GetControllerAt(2);
            pic = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
        }
    }
}