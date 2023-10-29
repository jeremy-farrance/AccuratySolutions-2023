using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DotNetNuke.Entities.Users;

namespace Accuraty.Libraries.AccuLadder.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void IsAdminOrSuper_ReturnsTrue_IfUserIsSuperUser()
    {
      // Arrange
      var userInfo = new UserInfo
      {
        IsSuperUser = true,
      };

      // Act
      bool result = Accu.Dnn.IsAdminOrSuper(userInfo);

      // Assert
      Assert.IsTrue(result);
    }
  }
}
