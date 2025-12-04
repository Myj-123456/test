/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Player
{
    public partial class style_item : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n4;
        public GLoader style_img;
        public GRichTextField needLab;
        public const string URL = "ui://0svwl9suefvri";

        public static style_item CreateInstance()
        {
            return (style_item)UIPackage.CreateObject("fun_Player", "style_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            style_img = (GLoader)GetChildAt(2);
            needLab = (GRichTextField)GetChildAt(3);
        }
    }
}