using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EncryptoBot_Proj
{
    class KeyClass
    {
        public int keyId;
        int index = 0;
        public static List<string> keyVal = new List<string>();

        public void SaveKey(string _key)
        {
            index++;
            for (int i = 0; i < keyVal.Count; i++)
            {
                if (keyVal[i] == _key)
                    return;
            }
            keyVal.Add(_key);
            keyId = index;
        }
    }
}