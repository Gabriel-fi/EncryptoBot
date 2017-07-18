using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views.InputMethods;


using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
//using Microsoft.Win32;

namespace EncryptoBot_Proj
{
    [Activity(Label = "Encryption")]
    public class MainActivity : Activity
    {
        private EditText mOriginalTxt;
        private EditText mKey;
        private TextView mEncryptedTxt;
        private ImageButton mEncryptBtn;
        private Button mCopyBtn;
        private Button mDecryptActv;
        private Button mKeyActv;
        static KeyClass keychain = new KeyClass();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mOriginalTxt = FindViewById<EditText>(Resource.Id.originalText);
            mKey = FindViewById<EditText>(Resource.Id.keyEdit);
            mEncryptedTxt = FindViewById<TextView>(Resource.Id.encryptedText);
            mEncryptBtn = FindViewById<ImageButton>(Resource.Id.cyptButton);
            mCopyBtn = FindViewById<Button>(Resource.Id.copyButton);
            mDecryptActv = FindViewById<Button>(Resource.Id.DecryptActv_Btn);
            mKeyActv = FindViewById<Button>(Resource.Id.KeyActv_Btn);

            mEncryptBtn.SetImageResource(Resource.Drawable.lock_key);

            //string pass = "";
            //Microsoft.Win32.RegistryKey rKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Encryptor");
            //rKey.SetValue("Password", pass);

            mEncryptBtn.Click += mEncryptBtn_Click;
            mCopyBtn.Click += mCopyBtn_Click;
            mDecryptActv.Click += mDecryptActv_Click;
            mKeyActv.Click += mKeyActv_Click;
        }

        private void mCopyBtn_Click(object sender, EventArgs e)
        {
            ((ClipboardManager)GetSystemService(Context.ClipboardService)).Text = mEncryptedTxt.Text;
            Toast.MakeText(this, "Copied", ToastLength.Short).Show();
        }

        private void mEncryptBtn_Click(object sender, EventArgs e)
        {
            #region FirstEncryption
            /*
            SymmetricAlgorithm control;

            control = new AesManaged();

            control.Key = UTF8Encoding.UTF8.GetBytes(mKey.Text);
            control.Padding = PaddingMode.PKCS7;
            control.Mode = CipherMode.ECB;

            ICryptoTransform transform = null;

            byte[] resultArray;

            //if(Crypt.ENCRYPT)
            transform = control.CreateEncryptor();

            //Else Decryptor
            //control.createDecryptor();

            if(mOriginalTxt.Text is string)
            {
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(mOriginalTxt.Text);
                resultArray = transform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                control.Clear();
                String str = UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
                mEncryptedTxt.Text = str;
            }
            */
            #endregion

            string encryptedTxt = SymmetricCrypt.Encrypt(mOriginalTxt.Text, mKey.Text);
            mEncryptedTxt.Text = encryptedTxt;
            keychain.SaveKey(mKey.Text);

            mKey.ClearFocus();
            mOriginalTxt.ClearFocus();
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(mKey.WindowToken, 0);

            //RegistryKey rKey = Registry.CurrentUser.OpenSubKey("Encryptor");

            //string Getpass = Convert.ToString(rKey.GetValue("Password"));

        }

        private void mDecryptActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Decrypt_Actv));
        }

        private void mKeyActv_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SavedKeys_Actv));
        }


    }
}

