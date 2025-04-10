using CSC360DemoDesignPatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoTests.Singleton {

    [TestClass]
    public class SingletonTests {
        [TestMethod]
        public void CanCreateAnInstanceOfTheClass() {

            //Arrange
            try {

            } catch (Exception ex) {
                Assert.Inconclusive(ex.Message);
            }
            //Act
            SingletonOne sut = SingletonOne.GetInstance();

            //Assert
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public void ReturnsTheSameInstanceOfTheClassNextInvocation() {
            //Arrange
            String initialGuid = String.Empty;
            SingletonOne sut = null;
            try {
                sut = SingletonOne.GetInstance();
                initialGuid = sut.InstanceGuid;
            } catch (Exception ex) {
                Assert.Inconclusive(ex.Message);
            }
            //Act
            sut = SingletonOne.GetInstance();
            SingletonOne sut2 = SingletonOne.GetInstance();

            //Assert
            Assert.AreEqual(sut.InstanceGuid, sut2.InstanceGuid);
            Assert.AreEqual(initialGuid, sut2.InstanceGuid);
        }
    }
}
