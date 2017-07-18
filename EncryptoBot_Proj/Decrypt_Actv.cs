using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views.InputMethods;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EncryptoBot_Proj
{
    [Activity(Label = "Decryption")]
    public class Decrypt_Actv : Activity
    {
        private EditText mEncryptedTxt;
        private EditText mKey;
        private TextView mDecryptedTxt;
        private ImageButton mDecryptBtn;
        private Button mCopyBtn;
        private Button mEncryptActv;
        private Button mKeyActv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            mEncryptedTxt = FindViewById<EditText>(Resource.Id.originalText);
            mKey = FindViewById<EditText>(Resource.Id.keyEdit);
            mDecryptedTxt = FindViewById<TextView>(Resource.Id.encryptedText);
            mDecryptBtn = FindViewById<ImageButton>(Resource.Id.cyptButton);
            mCopyBtn = FindViewById<Button>(Resource.Id.copyButton);
            mEncryptActv = FindViewById<Button>(Resource.Id.EncryptActv_Btn);
            mKeyActv = FindViewById<Button>(Resource.Id.KeyActv_Btn);

            mDecryptBtn.SetImageResource(Resource.Drawable.Unlock);
            mEncryptedTxt.Hint = "Type/Paste encrypted text to decrypt";
            mDecryptedTxt.Hint = "Decrypted text here";

            mDecryptBtn.Click += mDecryptBtn_Click;
            mCopyBtn.Click += mCopyBtn_Click;
            mEncryptActv.Click += mEncryptActv_Click;
            mKeyActv.Click += mKeyActv_Click;
        }

        private void mDecryptBtn_Click(object sender, EventArgs e)
        {
            string decryptedText = SymmetricCrypt.Decrypt(mEncryptedTxt.Text, mKey.Text, this);
            mDecryptedTxt.Text = decryptedText;

            mKey.ClearFocus();
            mEncryptedTxt.ClearFocus();
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(mKey.WindowToken, 0);
        }

        private void mCopyBtn_Click(object sender, EventArgs e)
        {
            ((ClipboardManager)GetSystemService(Context.ClipboardService)).Text = mEncryptedTxt.Text;
            Toast.MakeText(this, "Copied", ToastLength.Short).Show();
        }

        private void mEncryptActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void mKeyActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SavedKeys_Actv));
        }

    }
}