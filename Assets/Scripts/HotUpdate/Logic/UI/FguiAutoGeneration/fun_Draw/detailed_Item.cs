/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class detailed_Item : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public GImage n3;
        public const string URL = "ui://97nah3khj68sw7";

        public static detailed_Item CreateInstance()
        {
            return (detailed_Item)UIPackage.CreateObject("fun_Draw", "detailed_Item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
        }
    }
}