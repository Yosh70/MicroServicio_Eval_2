namespace WebAPITienda.Filters;

public static class ValidationExtensions
{
    public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder routeHandlerBuilder)
    {
        return routeHandlerBuilder.AddEndpointFilter<ValidationFilter<TRequest>>()
                                  .ProducesValidationProblem();

    }
}
