namespace Artity.Web.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public static class ControllerExtensions
    {
        private const string Area = "area";

        public static IActionResult RedirectTo<TController>(
            this Controller controller,
            Expression<Action<TController>> redirectExpression)
        {
            if (redirectExpression.Body.NodeType != ExpressionType.Call)
            {
                throw new InvalidOperationException("The provided expression is not a valid expression.");
            }

            var methodCallExpression = (MethodCallExpression)redirectExpression.Body;
            var controllerType = typeof(TController);
            var methodName = GetActionName(methodCallExpression);
            var areaName = GetAreaName(controllerType);
            var controllerName = controllerType.Name.Replace("Controller", string.Empty);

            var routeValues = ExtractRouteValues(methodCallExpression);

            routeValues.Add(Area, areaName);

            return controller.RedirectToAction(methodName, controllerName, routeValues);
        }

        private static string GetAreaName(Type controllerType)
        {
            var area = controllerType
                       .GetCustomAttributes()
                       .OfType<AreaAttribute>()
                       .FirstOrDefault()
                       ?.RouteValue;

            return area;
        }

        private static RouteValueDictionary ExtractRouteValues(MethodCallExpression expression)
        {
            var names = expression.Method
                                  .GetParameters()
                                  .Select(x => x.Name)
                                  .ToArray();

            var values = expression.Arguments.Select(x =>
            {
                if (x.NodeType == ExpressionType.Constant)
                {
                    var constantExpression = (ConstantExpression)x;
                    return constantExpression.Value;
                }

                if (x.NodeType == ExpressionType.MemberAccess
                    && ((MemberExpression)x).Member is FieldInfo)
                {
                    // Expression of type c => c.Action(id)
                    // Value can be extracted without compiling.
                    var memberAccessExpr = (MemberExpression)x;
                    var constantExpression = (ConstantExpression)memberAccessExpr.Expression;
                    if (constantExpression != null)
                    {
                        var innerMemberName = memberAccessExpr.Member.Name;
                        var compiledLambdaScopeField = constantExpression.Value.GetType().GetField(innerMemberName);
                        return compiledLambdaScopeField.GetValue(constantExpression.Value);
                    }
                }

                var convertExpression = Expression.Convert(expression, typeof(object));
                return Expression.Lambda<Func<object>>(convertExpression).Compile().Invoke();
            }).ToArray();

            var dict = new RouteValueDictionary();

            for (int i = 0; i < names.Length; i++)
            {
                dict.Add(names[i], values[i]);
            }

            return dict;
        }

        private static string GetActionName(MethodCallExpression expression)
        {
            var methodName = expression.Method.Name;

            var actionName = expression
                             .Method
                             .GetCustomAttributes(true)
                             .OfType<ActionNameAttribute>()
                             .FirstOrDefault()
                             ?.Name;

            return actionName ?? methodName;
        }
    }
}