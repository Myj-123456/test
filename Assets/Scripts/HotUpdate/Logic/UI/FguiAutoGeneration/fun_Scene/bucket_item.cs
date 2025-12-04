/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class bucket_item : GComponent
    {
        public Controller status;
        public GImage n4;
        public GImage n2;
        public water_pro1 pro;
        public Transition anim;
        public const string URL = "ui://dpcxz2fikkb12o";

        public static bucket_item CreateInstance()
        {
            return (bucket_item)UIPackage.CreateObject("fun_Scene", "bucket_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            pro = (water_pro1)GetChildAt(2);
            anim = GetTransitionAt(0);
        }
    }
}