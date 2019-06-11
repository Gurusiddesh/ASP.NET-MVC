using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BundlingAndMinification.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script")
                .Include("~/scripts/jquery-3.3.1.js")
                .Include("~/scripts/bootstrap.js")
                .Include("~/scripts/modernizr-2.8.3.js")
                .Include("~/scripts/demo1.js")
                .Include("~/scripts/demo2.js"));

            bundles.Add(new StyleBundle("~/style")
                .Include("~/content/bootstrap.css")
                .Include("~/content/Site.css")
                .Include("~/content/Demo1.css")
                .Include("~/content/Demo2.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}