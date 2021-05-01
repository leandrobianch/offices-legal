using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using OfficesLegal.Api.Models;
using OfficesLegal.Common;
using System.Linq;

namespace OfficesLegal.Api.Filters
{
    public class NotificationsValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var notificationValidation = context.HttpContext.RequestServices.GetService<INotificationValidation>();
            if (notificationValidation.HasNotifications())
            {
                var resultErrorViewModelOutput = new ValidationViewModelOutput(notificationValidation.GetMessages().Select(s => s.Message).ToList());
                context.Result = new BadRequestObjectResult(resultErrorViewModelOutput);
            }
        }
    }
}
