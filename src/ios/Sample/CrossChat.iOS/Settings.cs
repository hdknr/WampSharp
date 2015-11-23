using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;

namespace CrossChat.iOS
{
	public class Settings
	{
		
		protected NSDictionary _res = null;

		public Settings(string path="Settings.bundle/Root.plist")
		{
			_res = new NSDictionary (
				NSBundle.MainBundle.PathForResource (path, null)
			);
		}

		protected Dictionary<string, string> _default_preference = null;

		public Dictionary<string, string> DefaultPreference
		{
			get{
				if (_default_preference == null) {
					var prefs = _res ["PreferenceSpecifiers"] as NSArray;

					_default_preference =  NSArray.FromArray<NSDictionary> (prefs)
						.Where (i => i ["DefaultValue"] != null)
						.ToDictionary (
							k => k ["Key"].ToString (), v => v ["DefaultValue"].ToString ());
				}
				return _default_preference;
			}
		}

		public string GetPreference(string key){
			var ret = NSUserDefaults.StandardUserDefaults.StringForKey (key);
			return ret ?? DefaultPreference [key];
		}
	}
}

