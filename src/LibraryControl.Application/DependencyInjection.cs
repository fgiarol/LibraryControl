using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryControl.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)  =>
            services.AddMediatR(typeof(DependencyInjection).Assembly)
                .AddAutoMapper(typeof(DependencyInjection).Assembly);
    }
}