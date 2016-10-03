using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineLibraryApplication.DbContext;
using OnlineLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineLibraryApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext db = new ApplicationDbContext();
            CreateRole(db);
        }
    private static void CreateRole(ApplicationDbContext db){//AspNetRoles tablosuna roller eklenir
        var roleStore = new RoleStore<IdentityRole>(db);
        var roleManager = new RoleManager<IdentityRole>(roleStore);

        if (!roleManager.RoleExists("User")) {
            IdentityRole userRole = new IdentityRole("User");
            roleManager.Create(userRole);
        }
        if (!roleManager.RoleExists("Admin")) {
            IdentityRole adminRole = new IdentityRole("Admin");
            roleManager.Create(adminRole);
            
        }
   
    }
    
    }
}
