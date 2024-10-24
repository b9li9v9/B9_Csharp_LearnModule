using LearnJWT.Source;


namespace LearnJWT.Test
{
    public class TestJWT
    {
        public async Task TestJWTMain(bool io = false)
        {
            if (io)
            {
                var jwtGenerator = new JwtTokenGenerator();

                string secretKey = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                string issuer = "your-issuer";
                string audience = "your-audience";

                var claims = new Dictionary<string, string>
                {
                    { "username", "user1" },
                    { "role", "admin" },
                    { "haha", "haha" }
                };

                string token = jwtGenerator.GenerateJWT(secretKey, issuer, audience, claims);
                Console.WriteLine("Generated JWT: " + token);
            }
        }
    }
}
