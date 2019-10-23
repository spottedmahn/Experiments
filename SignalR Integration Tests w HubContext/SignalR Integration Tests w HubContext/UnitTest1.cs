using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SignalR_Integration_Tests_w_HubContext
{
    [TestClass]
    public class UnitTest1
    {
        //https://lurumad.github.io/integration-tests-in-aspnet-core-signalr
        [TestMethod]
        public async Task Hub()
        {
            TestServer server = null;
            var message = "Integration Testing in Microsoft AspNetCore SignalR";
            var echo = string.Empty;
            var webHostBuilder = new WebHostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSignalR();
                })
                .Configure(app =>
                {
                    app.UseSignalR(routes => routes.MapHub<EchoHub>("/echo"));
                });

            server = new TestServer(webHostBuilder);
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost/echo",
                    o => o.HttpMessageHandlerFactory = _ => server.CreateHandler())
                .Build();

            connection.On<string>("OnMessageRecieved", msg =>
            {
                echo = msg;
            });

            await connection.StartAsync();
            await connection.InvokeAsync("Send", message);

            echo.Should().Be(message);
        }

        [TestMethod]
        public async Task HubContext()
        {
            var webHostBuilder = new WebHostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSignalR();
                })
                .Configure(app =>
                {
                    app.UseSignalR(routes => routes.MapHub<StrongEchoHub>("/echo"));
                });

            var server = new TestServer(webHostBuilder);
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost/echo",
                    o => o.HttpMessageHandlerFactory = _ => server.CreateHandler())
                .Build();

            var hubContextMsg = string.Empty;
            connection.On<string>("OnMessageRecievedFromHubContext", msg =>
            {
                hubContextMsg = msg;
            });

            await connection.StartAsync();

            var message = "Integration Testing in Microsoft AspNetCore SignalR";
            var hubContext = server.Host.Services.GetService<IHubContext<StrongEchoHub, IStrongEchoHub>>();
            await hubContext.Clients.All.OnMessageRecievedFromHubContext(message);

            hubContextMsg.Should().Be(message);
        }

        [TestMethod]
        public async Task HubContextHack()
        {
            var webHostBuilder = new WebHostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSignalR();
                })
                .Configure(app =>
                {
                    app.UseSignalR(routes => routes.MapHub<StrongEchoHub>("/echo"));
                });

            var server = new TestServer(webHostBuilder);
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost/echo",
                    o => o.HttpMessageHandlerFactory = _ => server.CreateHandler())
                .Build();

            var hubContextMsg = string.Empty;
            var hubMsg = string.Empty;
            connection.On<string>("OnMessageRecievedFromHubContext", msg =>
            {
                hubContextMsg = msg;
            });

            connection.On<string>("OnMessageRecievedFromHub", msg =>
            {
                hubMsg = msg;
            });

            await connection.StartAsync();

            var message = "Integration Testing in Microsoft AspNetCore SignalR";
            var hubContext = server.Host.Services.GetService<IHubContext<StrongEchoHub, IStrongEchoHub>>();
            await hubContext.Clients.All.OnMessageRecievedFromHubContext(message);
            await connection.InvokeAsync("SendFromHub", "blah " + message);

            hubContextMsg.Should().Be(message);
            hubMsg.Should().Be("blah " + message);
        }
    }
}
