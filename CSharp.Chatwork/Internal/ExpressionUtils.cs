using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharp.Chatwork.Internal
{
	internal static class ExpressionUtils
	{
		internal static IEnumerable<KeyValuePair<string, object>> ExpressionToDictionary(
			IEnumerable<Expression<Func<string, object>>> expressions)
		{
			return expressions.Select(
				expr =>
				{
					var obj = expr.Body is ConstantExpression constExpr
						? constExpr.Value
						: expr.Compile()("");
					return new KeyValuePair<string, object>(expr.Parameters[0].Name, obj);
				});
		}
	}
}
