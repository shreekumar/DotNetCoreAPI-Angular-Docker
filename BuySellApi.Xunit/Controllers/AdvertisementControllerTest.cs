using BuySellApi.Controllers;
using BuySellApi.Core;
using BuySellApi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace BuySellApi.Xunit.Controllers
{
    public class AdvertisementControllerTest
    {
        AdvertisementsController _controller;
        IAdvertisement _advertisement;

        public AdvertisementControllerTest()
        {
            _advertisement = new AdvertisementInmemoryRepository();
            _controller = new AdvertisementsController(_advertisement);
        }

        [Fact]
        public void Get_WhenCalled_ReturnAllAdvertisements()
        {
            // Act
            var advertisements = _controller.FindAll();
            // Assert
            Assert.IsType<ActionResult<IEnumerable<Advertisement>>>(advertisements.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnAdvertisementById()
        {
            // Act
            var advertisement = _controller.Find(1);
            // Assert
            Assert.IsType<ActionResult<Advertisement>>(advertisement.Result);
        }
    }
}
