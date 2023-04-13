﻿using Sat.Recruitment.Business.Models;
using Sat.Recruitment.Business.Tests.UserServiceTests;
using Xunit;

namespace Sat.Recruitment.Business.Test.UserService.AssignMoney
{
    public class AssignMoneyTests : UserServiceTests
    {
        [Fact]
        public void Will_Return_Normal_Greather_Than_100()
        {
            #region Variables
            var user = new UserModel
            {
                Name = "John Doe",
                Email = "",
                Address = "",
                Money = 1000,
                Phone = "",
                UserType = "Normal"
            };
            #endregion

            #region Setup
            #endregion

            #region Call
            var result = Service.AssignMoney(user);
            #endregion

            #region Verify
            #endregion

            #region Assert
            Assert.IsType<decimal>(result);            
            Assert.False(result.IsSuccess);
            Assert.Equal(" The email is required The address is required The phone is required", result.Message);
            #endregion
        }

        [Fact]
        public void Will_Return_Normal_Less_Than_100_But_Greather_Than_10()
        {
            #region Variables
            var user = new UserModel
            {
                Name = "Juan",
                Email = "Juan@marmol.com",
                Address = "Peru 2464",
                Money = 1234,
                Phone = "+5491154762312",
                UserType = "Normal"
            };
            #endregion

            #region Setup
            // Simular la llamada a Directory.GetCurrentDirectory()
            System.IO.GetCurrentDirectory = () => "C:\\Test\\Files";

            // Crear un archivo de prueba en la ruta de prueba simulada
            string filePath = "C:\\Test\\Files\\Users.txt";
            System.IO.File.WriteAllText(filePath, "user1\nuser2\nuser3");

            // Crear una instancia de FileReader y llamar al método ReadUsersFromFile()
            FileReader reader = new FileReader();
            StreamReader result = reader.ReadUsersFromFile();

            // Comprobar que el resultado es el esperado
            string expected = "user1\nuser2\nuser3";
            #endregion

            #region Call
            var result = Service.CreateUser(user);
            #endregion

            #region Verify
            #endregion

            #region Assert
            Assert.IsType<ResultModel>(result);
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Message);
            #endregion
        }

        [Fact]
        public void Will_Return_SuperUser_Greather_Than_100()
        {
            #region Variables
            var user = new UserModel
            {
                Name = "John Doe",
                Email = "",
                Address = "",
                Money = 0,
                Phone = "",
                UserType = ""
            };
            #endregion

            #region Setup
            #endregion

            #region Call
            var result = Service.CreateUser(user);
            #endregion

            #region Verify
            #endregion

            #region Assert
            Assert.IsType<ResultModel>(result);
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Message);
            #endregion
        }
        
        [Fact]
        public void Will_Return_Premiun_Greather_Than_100()
        {
            #region Variables
            var user = new UserModel
            {
                Name = "John Doe",
                Email = "",
                Address = "",
                Money = 0,
                Phone = "",
                UserType = ""
            };
            #endregion

            #region Setup
            #endregion

            #region Call
            var result = Service.CreateUser(user);
            #endregion

            #region Verify
            #endregion

            #region Assert
            Assert.IsType<ResultModel>(result);
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Message);
            #endregion
        }
    }
}