using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using Elsa.Expressions.Contracts;
using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Features.Abstractions;
using Elsa.Features.Services;
using Elsa.Secrets.Contracts;
using Elsa.Secrets.Expressions;
using Elsa.Secrets.Providers;
using Microsoft.Extensions.DependencyInjection;
using Expression = Elsa.Expressions.Models.Expression;

namespace Elsa.Secrets.Features;

public class SecretsFeature(IModule module) : FeatureBase(module)
{
    private Func<IServiceProvider, ISecretProvider> _secretProviderFactory = _ => new NullSecretProvider();

    public SecretsFeature UseSecretsProvider(Func<IServiceProvider, ISecretProvider> secretProviderFactory)
    {
        _secretProviderFactory = secretProviderFactory;
        return this;
    }

    public override void Apply()
    {
        Services.AddScoped(_secretProviderFactory);

        Services.AddExpressionDescriptorProvider<SecretExpressionDescriptorProvider>();
    }
}