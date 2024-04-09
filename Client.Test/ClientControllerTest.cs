using Client.API.Controllers;
using Client.Service;
using Microsoft.AspNetCore.Mvc;

namespace Client.Test
{
    public class ClientControllerTest
    {
        private readonly ClientController _controller;
        private readonly IClientService _service;
        public ClientControllerTest()
        {
            _service = new ClientService();
            _controller = new ClientController(_service);
        }
        [Fact]
        public void Get_ClientById()
        {
            // Act
            var okResult = _controller.GetClient(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Search_Client()
        {
            // Act
            var okResult = _controller.SearchClients("John", "7803147453088", "1234567890");
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}