using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AugularJsFrameworkDemo.Helpers
{
    public static class TwitterBootstrapHelper
    {
        public static bool IsValidFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            var formContextForClientValidation = !htmlHelper.ViewContext.ClientValidationEnabled
                                                     ? null
                                                     : htmlHelper.ViewContext.FormContext;

            if (!htmlHelper.ViewData.ModelState.ContainsKey(fullHtmlFieldName) && formContextForClientValidation == null)
            {
                return true;
            }

            var modelState = htmlHelper.ViewData.ModelState[fullHtmlFieldName];

            return modelState.Errors.Any() == false;
        }
    }
}
