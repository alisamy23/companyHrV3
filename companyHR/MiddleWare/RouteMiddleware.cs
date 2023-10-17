using company.BL.Interface;
using company.BL.Repository;
using company.DAL.Extend;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Identity;
using RepositoryUsingEFinMVC.GenericRepository;
using System.Data;
using System.Security.Claims;

namespace companyHR.MiddleWare
{
    public class RouteMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMenuRep menuRep;

        //private readonly IMenuRep menu;

        public RouteMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
   
            this.httpContextAccessor = httpContextAccessor;
            //this.menu = menu;
        }
        public async Task InvokeAsync(HttpContext context, IMenuRep menuRep)
        {
            string path = context.Request.Path.Value;
            string? userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var rolesId = httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Role).Select(o => o.Value);
             if(path == "/" ||(path== "/Home/index" && httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) ||path== "/Error/AccessDenied")
            {
                await _next(context);
            }

            else
            {
                var menuData = (menuRep.GetMenuWithoueHeder(userName, rolesId.ToList()));
                var route = menuData.FirstOrDefault(o => o.Path == path);
                if (route == null)
                {

                    context.Response.Redirect("/Error/AccessDenied");

                    //ExceptionHandlingPath = "/Home/Error";
                    //var controllerType = Type.GetType(route.PageControl);
                    //var controller = Activator.CreateInstance(controllerType);
                    //var action = controllerType.GetMethod(route.PageAction);
                    //await (Task)action.Invoke(controller, null);
                }
                else
                {
                    await _next(context);
                }
            }
           

            
            //var route = await dbContext.Routes.FirstOrDefaultAsync(r => r.Path == path);

            //if (route != null)
            //{
            //    var controllerType = Type.GetType(route.Controller);
            //    var controller = Activator.CreateInstance(controllerType);
            //    var action = controllerType.GetMethod(route.Action);
            //    await (Task)action.Invoke(controller, null);
            //}
            //else
            //{
            //    await _next(context);
            //}
        }

    }
}
