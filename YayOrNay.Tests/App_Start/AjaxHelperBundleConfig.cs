using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(YayOrNay.Tests.App_Start.AjaxHelperBundleConfig), "RegisterBundles")]

namespace YayOrNay.Tests.App_Start
{
	public class AjaxHelperBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/ajaxhelper").Include("~/Scripts/jquery.ajaxhelper.js"));
		}
	}
}