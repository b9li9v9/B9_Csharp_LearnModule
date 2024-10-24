using MediatR;


namespace LearnMediatR.Source
{
    public class HelloRequest : IRequest<User>
    {
        public string Name { get; set; }
    }

}
