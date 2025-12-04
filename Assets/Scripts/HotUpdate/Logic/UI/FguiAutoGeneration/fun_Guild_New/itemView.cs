/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class itemView : GComponent
    {
        public GLoader img_loader;
        public GTextField txt_num;
        public const string URL = "ui://qz6135j3r9vt1ayr89h";

        public static itemView CreateInstance()
        {
            return (itemView)UIPackage.CreateObject("fun_Guild_New", "itemView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_loader = (GLoader)GetChildAt(0);
            txt_num = (GTextField)GetChildAt(1);
        }
    }
}