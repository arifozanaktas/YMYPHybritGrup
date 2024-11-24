using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using YMYPHibrit3Group.API.Filters;
using YMYPHibrit3Group.API.Model.Repositories;
using YMYPHibrit3Group.API.Model.Services;

namespace YMYPHibrit3Group.API.Extensions
{
    public static class ProgramExt
    {

        public static void AddServiceAndRepositoryAndFilterExt(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<NotFoundProductFilter>();


        }


        public static void AddSwaggerExt(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void AddMvcExt(this IServiceCollection services)
        {
            services.AddMvc(opt =>
            {
                //add global filter
                //opt.Filters.Add<MyResourceFilter>();

                opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });

            services.AddControllers();
        }


        public static void AddValidationExt(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
