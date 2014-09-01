using System.Collections;

public class TrackedBundleVersion
{
	public static readonly string bundleIdentifier = "com.Company.ProductName";

	public static readonly TrackedBundleVersionInfo Version_1_0 =  new TrackedBundleVersionInfo ("1.0", 0);
	
	public ArrayList history = new ArrayList ();

	public TrackedBundleVersionInfo current = new TrackedBundleVersionInfo ("1.0", 0);

	public  TrackedBundleVersion() {
		history.Add (current);
	}

}
