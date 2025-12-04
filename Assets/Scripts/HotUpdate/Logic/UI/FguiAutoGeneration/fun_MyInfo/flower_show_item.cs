/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class flower_show_item : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n3;
        public GImage n4;
        public GComponent ike;
        public GLoader3D spine;
        public const string URL = "ui://ehkqmfbpj9p61yjp7xo";

        public static flower_show_item CreateInstance()
        {
            return (flower_show_item)UIPackage.CreateObject("fun_MyInfo", "flower_show_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            ike = (GComponent)GetChildAt(3);
            spine = (GLoader3D)GetChildAt(4);
        }
    }
}