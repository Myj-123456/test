/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcOrder
{
    public partial class NpcOderPopUp : GComponent
    {
        public GImage n0;
        public GImage n1;
        public GRichTextField txt_popMsg;
        public const string URL = "ui://asaicjgycdio10";

        public static NpcOderPopUp CreateInstance()
        {
            return (NpcOderPopUp)UIPackage.CreateObject("fun_NpcOrder", "NpcOderPopUp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            txt_popMsg = (GRichTextField)GetChildAt(2);
        }
    }
}