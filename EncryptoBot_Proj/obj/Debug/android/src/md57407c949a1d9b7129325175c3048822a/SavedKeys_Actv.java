package md57407c949a1d9b7129325175c3048822a;


public class SavedKeys_Actv
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("EncryptoBot_Proj.SavedKeys_Actv, EncryptoBot_Proj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SavedKeys_Actv.class, __md_methods);
	}


	public SavedKeys_Actv () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SavedKeys_Actv.class)
			mono.android.TypeManager.Activate ("EncryptoBot_Proj.SavedKeys_Actv, EncryptoBot_Proj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
