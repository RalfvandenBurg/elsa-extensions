using Elsa.Expressions.Contracts;
using Elsa.Expressions.Helpers;
using Elsa.Expressions.Models;
using Elsa.Secrets.Contracts;

namespace Elsa.Secrets.Expressions;

public class SecretExpressionHandler : IExpressionHandler
{
    public async ValueTask<object?> EvaluateAsync(Expression expression, Type returnType, ExpressionExecutionContext context, ExpressionEvaluatorOptions options)
    {
        var secretName = expression.Value.ConvertTo<string>() ?? "";
        if ( string.IsNullOrWhiteSpace(secretName))
            return null;

        var secretProvider = context.GetRequiredService<ISecretProvider>();
        return await secretProvider.GetSecretAsync(secretName, context.CancellationToken);
    }
}
