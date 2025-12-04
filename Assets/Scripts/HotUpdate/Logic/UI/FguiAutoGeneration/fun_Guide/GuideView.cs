/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guide
{
    public partial class GuideView : GComponent
    {
        public GGraph bg;
        public GuideNpcDialogue npcDialogue;
        public GuideNpcDialogue2 npcDialogue2;
        public GGraph mask;
        public GuideShowImage showImage;
        public const string URL = "ui://miytzucx1003pl";

        public static GuideView CreateInstance()
        {
            return (GuideView)UIPackage.CreateObject("fun_Guide", "GuideView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GGraph)GetChildAt(0);
            npcDialogue = (GuideNpcDialogue)GetChildAt(1);
            npcDialogue2 = (GuideNpcDialogue2)GetChildAt(2);
            mask = (GGraph)GetChildAt(3);
            showImage = (GuideShowImage)GetChildAt(4);
        }
    }
}