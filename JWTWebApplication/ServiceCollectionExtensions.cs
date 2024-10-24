using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using JWTWebApplication.Permissions;
using JWTWebApplication.Authorization;
using System.Diagnostics;

namespace JWTWebApplication
{
    public static class ServiceCollectionExtensions
    {
        //“DefaultChallengeScheme” 可以翻译为 “默认质询方案”。
        //“Default” 意为 “默认”；“Challenge” 可翻译为 “质询”“挑战”；“Scheme” 可以翻译为 “方案”“计划”“架构”。结合语境这里翻译为 “默认质询方案” 较为合适。

        //默认身份验证方案是系统默认采用的验证方式。
       //质询方案是当身份验证失败时，系统用来要求用户重新提供凭证的机制。
        //两者关系：默认身份验证方案是质询方案的基础。如果身份验证失败，系统才会触发质询。
        internal static IServiceCollection AddOrdinaryBaseAuthentication(this IServiceCollection services)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));    // 注意：这里的key不能低于16位
            
            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })       // 注入认证服务，认证类型：Bearer
                .AddJwtBearer(o =>        // 注入 Jwt Bearer认证 服务，对其进行配置
                                          // 对 jwt 进行配置
                    {
                        o.TokenValidationParameters = new TokenValidationParameters()        // 对Token的认证是哪些参数，这里设置
                        {
                            // 这里的参数遵循 3（必要） + 2（可选） 个参数的规则
                            // 1、是否开启秘钥认证，验证秘钥
                            ValidateIssuerSigningKey = true,        // 验证发行者签名秘钥
                            IssuerSigningKey = securityKey,        // 发行者签名秘钥是？

                            // 2、验证发行人
                            ValidateIssuer = true,        // 验证发行者
                            ValidIssuer = "issuer",        // 验证发行者的名称是？

                            // 3、验证订阅人
                            ValidateAudience = true,        // 是否验证订阅者
                            ValidAudience = "audience",        // 验证订阅者的名称是？

                            // 1+1
                            // 过期时间 和 生命周期
                            RequireExpirationTime = true,        // 使用过期时间
                            ValidateLifetime = true,        // 验证生命周期
                        };
                    }
                );
            return services;
        }

        internal static IServiceCollection AddRoleBasedAuthentication(this IServiceCollection services)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));    // 注意：这里的key不能低于16位

            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })       // 注入认证服务，认证类型：Bearer
                .AddJwtBearer(o =>        // 注入 Jwt Bearer认证 服务，对其进行配置
                                          // 对 jwt 进行配置
                {
                    o.TokenValidationParameters = new TokenValidationParameters()        // 对Token的认证是哪些参数，这里设置
                    {
                        // 这里的参数遵循 3（必要） + 2（可选） 个参数的规则
                        // 1、是否开启秘钥认证，验证秘钥
                        ValidateIssuerSigningKey = true,        // 验证发行者签名秘钥
                        IssuerSigningKey = securityKey,        // 发行者签名秘钥是？

                        // 2、验证发行人
                        ValidateIssuer = true,        // 验证发行者
                        ValidIssuer = "issuer",        // 验证发行者的名称是？

                        // 3、验证订阅人
                        ValidateAudience = true,        // 是否验证订阅者
                        ValidAudience = "audience",        // 验证订阅者的名称是？

                        // 1+1
                        // 过期时间 和 生命周期
                        RequireExpirationTime = true,        // 使用过期时间
                        ValidateLifetime = true,        // 验证生命周期
                    };
                }
                );
            return services;
        }

        internal static IServiceCollection AddPolicyBasedAuthorization(this IServiceCollection services)
        {

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));    // 注意：这里的key不能低于16位

            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })       // 注入认证服务，认证类型：Bearer
                .AddJwtBearer(o =>        // 注入 Jwt Bearer认证 服务，对其进行配置
                                          // 对 jwt 进行配置
                {
                    o.TokenValidationParameters = new TokenValidationParameters()        // 对Token的认证是哪些参数，这里设置
                    {
                        // 这里的参数遵循 3（必要） + 2（可选） 个参数的规则
                        // 1、是否开启秘钥认证，验证秘钥
                        ValidateIssuerSigningKey = true,        // 验证发行者签名秘钥
                        IssuerSigningKey = securityKey,        // 发行者签名秘钥是？

                        // 2、验证发行人
                        ValidateIssuer = true,        // 验证发行者
                        ValidIssuer = "issuer",        // 验证发行者的名称是？

                        // 3、验证订阅人
                        ValidateAudience = true,        // 是否验证订阅者
                        ValidAudience = "audience",        // 验证订阅者的名称是？

                        // 1+1
                        // 过期时间 和 生命周期
                        RequireExpirationTime = true,        // 使用过期时间
                        ValidateLifetime = true,        // 验证生命周期
                    };
                }
                );

            services.AddAuthorization(o => {
                o.AddPolicy("AdminAndVIP", o => {
                    o.RequireRole("vip").RequireRole("admin").Build();
                });
            });
            return services;
        }

        internal static IServiceCollection AddCustomPolicyBasedAuthorization(this IServiceCollection services)
        {

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));    // 注意：这里的key不能低于16位

            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })       // 注入认证服务，认证类型：Bearer
                .AddJwtBearer(o =>        // 注入 Jwt Bearer认证 服务，对其进行配置
                                          // 对 jwt 进行配置
                {
                    o.TokenValidationParameters = new TokenValidationParameters()        // 对Token的认证是哪些参数，这里设置
                    {
                        // 这里的参数遵循 3（必要） + 2（可选） 个参数的规则
                        // 1、是否开启秘钥认证，验证秘钥
                        ValidateIssuerSigningKey = true,        // 验证发行者签名秘钥
                        IssuerSigningKey = securityKey,        // 发行者签名秘钥是？

                        // 2、验证发行人
                        ValidateIssuer = true,        // 验证发行者
                        ValidIssuer = "issuer",        // 验证发行者的名称是？

                        // 3、验证订阅人
                        ValidateAudience = true,        // 是否验证订阅者
                        ValidAudience = "audience",        // 验证订阅者的名称是？

                        // 1+1
                        // 过期时间 和 生命周期
                        RequireExpirationTime = true,        // 使用过期时间
                        ValidateLifetime = true,        // 验证生命周期
                    };
                }
                );

                services.AddAuthorization(options =>
                {
                        options.AddPolicy(AppClaim.Permission, policy =>
                            policy.Requirements.Add(new CustomPermissionRequirement(AppPermissions.AllPermissions.Select(p => p.Name).ToList())));

                    Debug.WriteLine(AppPermissions.AllPermissions.Select(p => p.Name).ToList());
                });
            

                

            services.AddSingleton<IAuthorizationHandler, CustomPermissionAuthorizationHandler>();
            return services;
        }
    }
}

/*只需登录: 只使用 AddAuthentication。
需要权限控制: 使用 AddAuthentication 和 AddAuthorization，前者负责身份验证，后者负责权限检查。*/
