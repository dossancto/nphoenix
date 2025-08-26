using PhoenixApi.Modules.Todos.Endpoints;

namespace PhoenixApi.Modules.Todos;

public static class TodosModule
{
    public static IServiceCollection AddTodosModule(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }

    public static void UseTodosModule(this WebApplication app)
    {
        app.MapTodoEndpoints();
    }
}