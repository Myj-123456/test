/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guide
{
    public partial class GuideShowImage : GComponent
    {
        public GLoader3D loader_spine;
        public GButton btn_next;
        public GLoader loader_title;
        public const string URL = "ui://miytzucx1003pr";

        public static GuideShowImage CreateInstance()
        {
            return (GuideShowImage)UIPackage.CreateObject("fun_Guide", "GuideShowImage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            loader_spine = (GLoader3D)GetChildAt(0);
            btn_next = (GButton)GetChildAt(1);
            loader_title = (GLoader)GetChildAt(2);
        }
    }
}