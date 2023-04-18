using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManagement.Controllers;
using TaskManagement.Interface;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.API.Tests
{
    public class StatusControllerTest
    {
        private TaskManagementContext _taskManagementContext;
        private readonly StatusController _controller;
        private readonly IStatusRepository _service;
 
        public StatusControllerTest(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
            _service = new StatusRepository(taskManagementContext);
            _controller = new StatusController(_service);
        }
        [Fact]
        public List<TblStatus> Get_WhenCalled_ReturnsByIdItems()
        {
            var mock = new Mock<IStatusRepository>();
            List<TblStatus> tblStatuses = new List<TblStatus>();
            tblStatuses.Add(new TblStatus { StatusId = 1, StatusName = "InProgress" });

            mock.Setup(p => p.GetStatusByID(1)).Returns(tblStatuses);
            StatusController status = new StatusController(mock.Object);
            List<TblStatus> result = status.GetStatusByID(1);
             
            // Act
            var okResult = _controller.GetStatusByID(1);
            // Assert
            return Assert.IsType<List<TblStatus>>(okResult);
        }
        [Fact]
        public List<TblStatus> Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAllStatus();
            // Assert
            return Assert.IsType<List<TblStatus>>(okResult);
        }
    }
}