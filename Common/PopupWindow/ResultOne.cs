using System;

namespace Silt.Base.Common.PopupWindow
{
    public delegate void TextChangedHandler2(string str1, string str2);
    /// <summary>
    /// ���������ַ�ֵ
    /// </summary>
    public class ResultTwo
    {
        public event TextChangedHandler2 TextChanged;
        public void ChangeText(string str1, string str2)
        {
            if (TextChanged != null)
                TextChanged(str1, str2);
        }
    }
}
