using AutoMapper;
using Domain.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StoreApi.Models;
using System.Text;

namespace StoreApi
{
    public static class ServiceExtentions
    {
        #region Cors
        public static void ConfigureCors(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddCors(options =>
            {
                var AllowedUrls = appSettings.AllowedUrls;

                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(AllowedUrls).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        #endregion

        #region IIS

        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options => { });

        #endregion

        #region Mapper

        public static void ConfigureMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(m => { m.AddProfile(new AutoMapperProfile()); });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        #endregion

        #region Swagger
        public static void ConfigureSwagger(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.AppSecret);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreApi", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }

        #endregion

        #region Services
        public static void AddServices(this IServiceCollection services, AppSettings appSettings)
        {
            #region Singletons

            services.AddSingleton<AppSettings>(appSettings);

            #endregion
        }
        #endregion

        #region JWT
        public static void ConfigureJWT(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.AppSecret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidIssuers = appSettings.AllowedUrls,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => { return notBefore <= DateTime.UtcNow && expires >= DateTime.UtcNow; }
                };
            });
        }
        #endregion
    }
}
