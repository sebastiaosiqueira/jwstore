
using JwStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwStore.Infra.Context.AccountContext.UseCases.Create;
using MediatR;

namespace JwStore.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Create
            builder.Services.AddTransient<IRepository, Repository>();
            builder.Services.AddTransient<IService, Service>();
            #endregion

            #region Authenticate

            builder.Services.AddTransient<
                JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts.IRepository,
                JwStore.Infra.Context.AccountText.UseCases.Authenticate.Repository>();

            #endregion

        }
        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create
            app.MapPost("api/v1/users", async (
                  JwStore.Core.Contexts.AccountContext.UseCases.Create.Request request,
                  IRequestHandler<
                JwStore.Core.Contexts.AccountContext.UseCases.Create.Request,
                JwStore.Core.Contexts.AccountContext.UseCases.Create.Response> handler) =>
                {
                    var result = await handler.Handle(request, new CancellationToken());
                    return result.IsSuccess
                        ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                        : Results.Json(result, statusCode: result.Status);
                });



            #endregion

            #region Authenticate

            app.MapPost("api/v1/authenticate", async (
                JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Request request,
                IRequestHandler<
                    JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Request,
                    JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);
            });

            #endregion

        }
    }
}