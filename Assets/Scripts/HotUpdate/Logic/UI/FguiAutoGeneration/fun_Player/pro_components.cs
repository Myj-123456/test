/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Player
{
    public partial class pro_components : GComponent
    {
        public GImage n7;
        public GImage n2;
        public GImage n1;
        public GTextField inkLab;
        public GTextField inkNum;
        public const string URL = "ui://0svwl9sux92ms";

        public static pro_components CreateInstance()
        {
            return (pro_components)UIPackage.CreateObject("fun_Player", "pro_components");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n7 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
            inkLab = (GTextField)GetChildAt(3);
            inkNum = (GTextField)GetChildAt(4);
        }
    }
}