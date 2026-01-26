using Elsa.Expressions.Contracts;
using Elsa.Expressions.Models;
using Elsa.Secrets.Expressions;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Secrets.Providers;

internal class SecretExpressionDescriptorProvider : IExpressionDescriptorProvider
{
    private const string TypeName = "Secret";

    public IEnumerable<ExpressionDescriptor> GetDescriptors()
    {
        yield return new()
        {
            Type = TypeName,
            DisplayName = "Secret",
            HandlerFactory = ActivatorUtilities.GetServiceOrCreateInstance<SecretExpressionHandler>,
            IsBrowsable = true
        };
    }
}