/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class flowerList : GComponent
    {
        public GImage n2;
        public GList list;
        public GGraph n3;
        public Transition open;
        public Transition close;
        public const string URL = "ui://6kofjj39gzzis8";

        public static flowerList CreateInstance()
        {
            return (flowerList)UIPackage.CreateObject("fun_FlowerArrangement", "flowerList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
            n3 = (GGraph)GetChildAt(2);
            open = GetTransitionAt(0);
            close = GetTransitionAt(1);
        }
    }
}