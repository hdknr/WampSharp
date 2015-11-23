using System;

using UIKit;

using Newtonsoft.Json.Linq;

namespace CrossChat.iOS
{
	public partial class ViewController : UIViewController
	{
		Topic _topic =null;
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			_topic = new Topic (OnMessage);

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
		public void OnMessage(JObject message){
			Console.WriteLine("@  Nick {0} : {1}", message["nick"], message["message"]);
		}

	}
}

