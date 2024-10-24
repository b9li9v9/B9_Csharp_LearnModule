using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LearnJWT.Source
{
    public class JwtTokenGenerator
    {
        public string GenerateJWT(string secretKey, string issuer, string audience, Dictionary<string, string> claims)
        {
            // Step 1: 创建对称密钥
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));

            // Step 2: 创建签名凭证
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Step 3: 创建声明列表
            var claimsList = new List<Claim>();
            foreach (var claim in claims)
            {
                claimsList.Add(new Claim(claim.Key, claim.Value));
            }

            // Step 4: 创建JWT令牌
            var token = new JwtSecurityToken(
                issuer: issuer,                      // 发行者
                audience: audience,                  // 受众
                claims: claimsList,                  // 声明
                expires: DateTime.Now.AddMinutes(30), // 过期时间
                signingCredentials: creds);           // 签名凭证

            // Step 5: 返回JWT字符串
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}

