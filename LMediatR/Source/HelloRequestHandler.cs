using MediatR;

namespace LearnMediatR.Source
{
    public class HelloRequestHandler : IRequestHandler<HelloRequest, User>
    {
        public async Task<User> Handle(HelloRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("HelloRequestHandler 处理执行");
            var user = new User(request.Name);

            return await Task.FromResult(user);
        }

    }
}
