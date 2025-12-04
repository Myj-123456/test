using System.Collections.Generic;
using FairyGUI.Utils;
using UnityEngine;
#if WEIXINMINIGAME
using WeChatWASM;
#endif

namespace FairyGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class GTextInput : GTextField
    {
        /// <summary>
        /// 
        /// </summary>
        public InputTextField inputTextField { get; private set; }

        EventListener _onChanged;
        EventListener _onSubmit;

        private bool _isShowKeyboard = false;

        public GTextInput()
        {
            _textField.autoSize = AutoSizeType.None;
            _textField.wordWrap = false;
            BindWXInputFieldAdapter();
        }

        /// <summary>
        /// 绑定wx输入文本适配器
        /// </summary>
        /// <param name="inputField"></param>
        private void BindWXInputFieldAdapter()
        {

#if !UNITY_EDITOR && WEIXINMINIGAME
            Debug.Log("BindWXInputFieldAdapter");
            editable = false;
            onClick.Add(ShowKeyboard);
            onFocusIn.Add(ShowKeyboard);
            onFocusOut.Add(HideKeyboard);
#endif
        }

#if WEIXINMINIGAME
        private void OnInput(OnKeyboardInputListenerResult v)
        {
            Debug.Log("onInput");
            Debug.Log(v.value);

            if (focused)
            {
                text = v.value;
            }
        }

        private void OnConfirm(OnKeyboardInputListenerResult v)
        {
            // 输入法confirm回调
            Debug.Log("onConfirm");
            Debug.Log(v.value);
            text = v.value;
            HideKeyboard();
        }

        private void OnComplete(OnKeyboardInputListenerResult v)
        {
            // 输入法complete回调
            Debug.Log("OnComplete");
            Debug.Log(v.value);
            text = v.value;
            HideKeyboard();
        }

        private void ShowKeyboard()
        {
            if (_isShowKeyboard) return;

            WX.ShowKeyboard(new ShowKeyboardOption()
            {
                defaultValue = text,
                maxLength = 20,
                confirmType = "go"
            });

            //绑定回调
            WX.OnKeyboardConfirm(OnConfirm);
            WX.OnKeyboardComplete(OnComplete);
            WX.OnKeyboardInput(OnInput);
            _isShowKeyboard = true;
            Debug.Log("ShowKeyboard");
        }

        private void HideKeyboard()
        {
            if (!_isShowKeyboard) return;

            WX.HideKeyboard(new HideKeyboardOption());
            //删除掉相关事件监听
            WX.OffKeyboardInput(OnInput);
            WX.OffKeyboardConfirm(OnConfirm);
            WX.OffKeyboardComplete(OnComplete);
            _isShowKeyboard = false;
            Debug.Log("HideKeyboard");
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        public EventListener onChanged
        {
            get { return _onChanged ?? (_onChanged = new EventListener(this, "onChanged")); }
        }

        /// <summary>
        /// 
        /// </summary>
        public EventListener onSubmit
        {
            get { return _onSubmit ?? (_onSubmit = new EventListener(this, "onSubmit")); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool editable
        {
            get { return inputTextField.editable; }
            set { inputTextField.editable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool hideInput
        {
            get { return inputTextField.hideInput; }
            set { inputTextField.hideInput = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int maxLength
        {
            get { return inputTextField.maxLength; }
            set { inputTextField.maxLength = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string restrict
        {
            get { return inputTextField.restrict; }
            set { inputTextField.restrict = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool displayAsPassword
        {
            get { return inputTextField.displayAsPassword; }
            set { inputTextField.displayAsPassword = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int caretPosition
        {
            get { return inputTextField.caretPosition; }
            set { inputTextField.caretPosition = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string promptText
        {
            get { return inputTextField.promptText; }
            set { inputTextField.promptText = value; }
        }

        /// <summary>
        /// 在移动设备上是否使用键盘输入。如果false，则文本在获得焦点后不会弹出键盘。
        /// </summary>
        public bool keyboardInput
        {
            get { return inputTextField.keyboardInput; }
            set { inputTextField.keyboardInput = value; }
        }

        /// <summary>
        /// <see cref="UnityEngine.TouchScreenKeyboardType"/>
        /// </summary>
        public int keyboardType
        {
            get { return inputTextField.keyboardType; }
            set { inputTextField.keyboardType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool disableIME
        {
            get { return inputTextField.disableIME; }
            set { inputTextField.disableIME = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<uint, Emoji> emojies
        {
            get { return inputTextField.emojies; }
            set { inputTextField.emojies = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int border
        {
            get { return inputTextField.border; }
            set { inputTextField.border = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int corner
        {
            get { return inputTextField.corner; }
            set { inputTextField.corner = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color borderColor
        {
            get { return inputTextField.borderColor; }
            set { inputTextField.borderColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color backgroundColor
        {
            get { return inputTextField.backgroundColor; }
            set { inputTextField.backgroundColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool mouseWheelEnabled
        {
            get { return inputTextField.mouseWheelEnabled; }
            set { inputTextField.mouseWheelEnabled = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        public void SetSelection(int start, int length)
        {
            inputTextField.SetSelection(start, length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void ReplaceSelection(string value)
        {
            inputTextField.ReplaceSelection(value);
        }

        override protected void SetTextFieldText()
        {
            inputTextField.text = _text;
        }

        override protected void CreateDisplayObject()
        {
            inputTextField = new InputTextField();
            inputTextField.gOwner = this;
            displayObject = inputTextField;

            _textField = inputTextField.textField;
        }

        public override void Setup_BeforeAdd(ByteBuffer buffer, int beginPos)
        {
            base.Setup_BeforeAdd(buffer, beginPos);

            buffer.Seek(beginPos, 4);

            string str = buffer.ReadS();
            if (str != null)
                inputTextField.promptText = str;

            str = buffer.ReadS();
            if (str != null)
                inputTextField.restrict = str;

            int iv = buffer.ReadInt();
            if (iv != 0)
                inputTextField.maxLength = iv;
            iv = buffer.ReadInt();
            if (iv != 0)
                inputTextField.keyboardType = iv;
            if (buffer.ReadBool())
                inputTextField.displayAsPassword = true;
        }
    }
}