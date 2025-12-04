/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class DialogueItem : GComponent
    {
        public TweenDialogueItem item;
        public const string URL = "ui://vucpfjl8rqny0";

        public static DialogueItem CreateInstance()
        {
            return (DialogueItem)UIPackage.CreateObject("fun_Plot", "DialogueItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            item = (TweenDialogueItem)GetChildAt(0);
        }
    }
}