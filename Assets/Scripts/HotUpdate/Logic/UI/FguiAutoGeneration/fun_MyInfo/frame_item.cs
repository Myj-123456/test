/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class frame_item : GButton
    {
        public Controller button;
        public Controller unlock;
        public Controller type;
        public GComponent frame;
        public GImage n3;
        public GImage n5;
        public GImage n2;
        public GImage n4;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yw";

        public static frame_item CreateInstance()
        {
            return (frame_item)UIPackage.CreateObject("fun_MyInfo", "frame_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            unlock = GetControllerAt(1);
            type = GetControllerAt(2);
            frame = (GComponent)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
        }
    }
}