using CSC360DemoDesignPatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoTests.Singleton {

    [TestClass]
    public class SingletonTwoTests {
        [TestMethod]
        public void CanCreateAnInstanceOfTheClass() {

            //Arrange
            try {

            } catch (Exception ex) {
                Assert.Inconclusive(ex.Message);
            }
            //Act
            SingletonTwo sut = SingletonTwo.Instance;

            //Assert
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public void ReturnsTheSameInstanceOfTheClassNextInvocation() {
            //Arrange
            String initialGuid = String.Empty;
            SingletonTwo sut = null;
            try {
                sut = SingletonTwo.Instance;
                initialGuid = sut.InstanceGuid;
            } catch (Exception ex) {
                Assert.Inconclusive(ex.Message);
            }
            //Act
            sut = SingletonTwo.Instance;
            SingletonTwo sut2 = SingletonTwo.Instance;

            //Assert
            Assert.AreEqual(sut.InstanceGuid, sut2.InstanceGuid);
            Assert.AreEqual(initialGuid, sut2.InstanceGuid);
        }
    }
}
