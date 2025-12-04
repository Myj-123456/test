/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class limit_com : GComponent
    {
        public Controller status;
        public limit_item item1;
        public limit_item item2;
        public limit_item item3;
        public limit_item item4;
        public limit_item item5;
        public const string URL = "ui://nj16dzxym3gh18";

        public static limit_com CreateInstance()
        {
            return (limit_com)UIPackage.CreateObject("fun_Florist", "limit_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            item1 = (limit_item)GetChildAt(0);
            item2 = (limit_item)GetChildAt(1);
            item3 = (limit_item)GetChildAt(2);
            item4 = (limit_item)GetChildAt(3);
            item5 = (limit_item)GetChildAt(4);
        }
    }
}