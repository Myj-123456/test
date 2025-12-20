/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robbedList : GComponent
    {
        public GImage n3;
        public robbedCell2 cage_0;
        public robbedCell2 cage_1;
        public robbedCell2 cage_2;
        public robbedCell2 cage_3;
        public const string URL = "ui://z1on8kwdiy851ayr8mm";

        public static robbedList CreateInstance()
        {
            return (robbedList)UIPackage.CreateObject("fun_Rob", "robbedList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            cage_0 = (robbedCell2)GetChildAt(1);
            cage_1 = (robbedCell2)GetChildAt(2);
            cage_2 = (robbedCell2)GetChildAt(3);
            cage_3 = (robbedCell2)GetChildAt(4);
        }
    }
}