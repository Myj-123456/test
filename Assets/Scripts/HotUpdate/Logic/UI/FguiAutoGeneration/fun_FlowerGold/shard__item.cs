/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class shard__item : GComponent
    {
        public GImage n1;
        public GLoader shard_img;
        public GTextField shardNum;
        public const string URL = "ui://44kfvb3rm3gh4z";

        public static shard__item CreateInstance()
        {
            return (shard__item)UIPackage.CreateObject("fun_FlowerGold", "shard _item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            shard_img = (GLoader)GetChildAt(1);
            shardNum = (GTextField)GetChildAt(2);
        }
    }
}