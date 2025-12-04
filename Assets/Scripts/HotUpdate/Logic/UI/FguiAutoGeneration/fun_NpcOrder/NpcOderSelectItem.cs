/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcOrder
{
    public partial class NpcOderSelectItem : GComponent
    {
        public GLoader loader_icon;
        public GImage txt_select;
        public GTextField img_select;
        public const string URL = "ui://asaicjgyacmax";

        public static NpcOderSelectItem CreateInstance()
        {
            return (NpcOderSelectItem)UIPackage.CreateObject("fun_NpcOrder", "NpcOderSelectItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            loader_icon = (GLoader)GetChildAt(0);
            txt_select = (GImage)GetChildAt(1);
            img_select = (GTextField)GetChildAt(2);
        }
    }
}