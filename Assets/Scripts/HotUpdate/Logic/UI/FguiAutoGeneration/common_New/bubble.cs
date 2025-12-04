/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class bubble : GComponent
    {
        public GImage n4;
        public GLoader img_loaderOld;
        public GTextField num;
        public const string URL = "ui://mjiw43v9kyj01yjp7tk";

        public static bubble CreateInstance()
        {
            return (bubble)UIPackage.CreateObject("common_New", "bubble");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            img_loaderOld = (GLoader)GetChildAt(1);
            num = (GTextField)GetChildAt(2);
        }
    }
}