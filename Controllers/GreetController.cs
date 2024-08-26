using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using learn_grpc_metier;
using Grpc.Net.Client;

namespace learn_grpc_gateway.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GreetController : ControllerBase
  {

    private readonly Greeter.GreeterClient _greeterClient;

    public GreetController(Greeter.GreeterClient greeterClient)
    {
      _greeterClient = greeterClient;
    }

    [HttpPost]
    public async Task<IActionResult> Greet([FromBody] HelloRequest request)
    {
      /*var request = new HelloRequest
      {
        Name = "David"
      };*/

      var reply = await _greeterClient.SayHello1Async (request);

      return Ok(reply.Message);
    }

  }
}
