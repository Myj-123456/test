/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class TweenDialogueItem : GComponent
    {
        public Controller c1;
        public GImage n0;
        public GTextField txt_msg1;
        public GGroup textboxItem1;
        public GImage n12;
        public GTextField txt_msg2;
        public GGroup textboxItem2;
        public GLoader n5;
        public GImage n17;
        public GImage n16;
        public GTextField txt_name;
        public GGroup groupIcon;
        public const string URL = "ui://vucpfjl8vvnua";

        public static TweenDialogueItem CreateInstance()
        {
            return (TweenDialogueItem)UIPackage.CreateObject("fun_Plot", "TweenDialogueItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            txt_msg1 = (GTextField)GetChildAt(1);
            textboxItem1 = (GGroup)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            txt_msg2 = (GTextField)GetChildAt(4);
            textboxItem2 = (GGroup)GetChildAt(5);
            n5 = (GLoader)GetChildAt(6);
            n17 = (GImage)GetChildAt(7);
            n16 = (GImage)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
            groupIcon = (GGroup)GetChildAt(10);
        }
    }
}