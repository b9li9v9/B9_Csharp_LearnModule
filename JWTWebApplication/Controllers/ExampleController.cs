using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTWebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public string GetHi()
        {

            return "Example say hi";
        }

        [HttpGet]
        // Jwt Token 的生成[HttpGet]
        public string GetOrdinaryBaseToekn()
        {
            // 注意，必须和上面的 JwtBearer 配置一致，且密钥最少16位，太少会报错！
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));
            // 同样，我们在上面的 JwtBearer 配置中，需要验证的是什么，这里也要生成对应的条件，缺了就会导致认证失败，假如这里发行人改成其他，验证那边就不通过
            SecurityToken securityToken = new JwtSecurityToken(
                // 和上面一样，同样遵循 3+2 规则
                issuer: "issuer",        // 发行人
                audience: "audience",        // 订阅人
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),        // 安全密钥 和 加密算法


                expires: DateTime.Now.AddHours(1),        // 过期时间
                claims: new Claim[] { }        // 添加 Claim（声明主体），添加uid、username、role等都放在这里
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);    // 返回 Token字符串
        }

        [HttpGet]
        [Authorize(Roles = "vip")]
        public string GetVipHi()
        {
            return "Vip Hi!";
        }

        [HttpGet]
        // Jwt Token 的生成[HttpGet]
        public string GetRoleBaseVipToken()
        {
            // 注意，必须和上面的 JwtBearer 配置一致，且密钥最少16位，太少会报错！
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));
            // 同样，我们在上面的 JwtBearer 配置中，需要验证的是什么，这里也要生成对应的条件，缺了就会导致认证失败，假如这里发行人改成其他，验证那边就不通过
            SecurityToken securityToken = new JwtSecurityToken(
                // 和上面一样，同样遵循 3+2 规则
                issuer: "issuer",        // 发行人
                audience: "audience",        // 订阅人
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),        // 安全密钥 和 加密算法


                expires: DateTime.Now.AddHours(1),        // 过期时间
                claims: new Claim[] 
                    {
                        new Claim(ClaimTypes.Role, "vip"),
                    }        // 添加 Claim（声明主体），添加uid、username、role等都放在这里
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);    // 返回 Token字符串
        }

        [Authorize(Policy = "AdminAndVIP")]
        [HttpGet]//[FromBody] dynamic model
        public string GetPolicyAdminAndUserHi()
        {
            return "PolicyAdminAndUserHi";
        }


        //ClaimsPrincipal 翻译过来 "声明主体"  “证件主体” “证件当事人”
        [HttpGet]
        // Jwt Token 的生成[HttpGet]
        public string GetPolicyAdminAndVIPToken()
        {
            // 注意，必须和上面的 JwtBearer 配置一致，且密钥最少16位，太少会报错！
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ixkeE8eu2345k4zsixkeE8eu2345k4zs"));
            // 同样，我们在上面的 JwtBearer 配置中，需要验证的是什么，这里也要生成对应的条件，缺了就会导致认证失败，假如这里发行人改成其他，验证那边就不通过
            SecurityToken securityToken = new JwtSecurityToken(
                // 和上面一样，同样遵循 3+2 规则
                issuer: "issuer",        // 发行人
                audience: "audience",        // 订阅人
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),        // 安全密钥 和 加密算法


                expires: DateTime.Now.AddHours(1),        // 过期时间
                claims: new Claim[]
                    {
                        new Claim(ClaimTypes.Role, "vip"),
                        new Claim(ClaimTypes.Role, "admin"),
                    }        // 添加 Claim（声明主体），添加uid、username、role等都放在这里
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);    // 返回 Token字符串
        }

    }
}
