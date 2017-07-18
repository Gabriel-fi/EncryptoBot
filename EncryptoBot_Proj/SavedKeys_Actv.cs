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
    [Activity(Label = "Saved Keys")]
    public class SavedKeys_Actv : Activity
    {
        private ListView keyList;
        private KeyClass keychain = new KeyClass();
        private Button mDecryptActv;
        private Button mEncryptionActv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Key_Layout);

            keyList = FindViewById<ListView>(Resource.Id.listView);
            mDecryptActv = FindViewById<Button>(Resource.Id.DecryptActv_Btn);
            mEncryptionActv = FindViewById<Button>(Resource.Id.EncryptActv_Btn);

            mDecryptActv.Click += mDecryptActv_Click;
            mEncryptionActv.Click += mEncryptionActv_Click;

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, KeyClass.keyVal);
            keyList.Adapter = adapter;

            keyList.ItemClick += KeyList_Click;
            keyList.ItemLongClick += KeyList_ItemLongClick;
        }

        private void KeyList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            KeyClass.keyVal.RemoveAt(e.Position);
            //((BaseAdapter)keyList.Adapter).NotifyDataSetChanged();
            //keyList.Invalidate();
            Intent i = this.Intent;
            StartActivity(i);
            Toast.MakeText(this, "Deleted", ToastLength.Short).Show();
        }

        private void KeyList_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            ((ClipboardManager)GetSystemService(Context.ClipboardService)).Text = KeyClass.keyVal[e.Position];
            Toast.MakeText(this, "Copied to Clipboard", ToastLength.Short).Show();
        }

        private void mDecryptActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Decrypt_Actv));
        }

        private void mEncryptionActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}