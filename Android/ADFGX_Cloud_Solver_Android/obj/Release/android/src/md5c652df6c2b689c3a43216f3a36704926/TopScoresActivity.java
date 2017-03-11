package md5c652df6c2b689c3a43216f3a36704926;


public class TopScoresActivity
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ADFGX_Cloud_Solver_Android.TopScoresActivity, ADFGX_Cloud_Solver_Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TopScoresActivity.class, __md_methods);
	}


	public TopScoresActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TopScoresActivity.class)
			mono.android.TypeManager.Activate ("ADFGX_Cloud_Solver_Android.TopScoresActivity, ADFGX_Cloud_Solver_Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
