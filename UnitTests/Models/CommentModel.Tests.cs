using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{

    /// <summary>
    /// UnitTests for CommentModel
    /// </summary>
    public class CommentModelTests
    {
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region Id
        [Test]
        public void CommentModel_Valid_Id_Should_Return_Id()
        {
            // Arrange
            var data = new CommentModel() { Id = "ExampleId" };

            // Act
            var id = data.Id;

            // Assert
            Assert.AreEqual("ExampleId", id);
        }
        #endregion Id

        #region Commen
        [Test]
        public void CommentModel_Valid_Comment_Should_Return_Comment()
        {
            // Arrange
            var data = new CommentModel() { Comment = "ExampleComment" };

            // Act
            var comment = data.Comment;

            // Assert
            Assert.AreEqual("ExampleComment", comment);
        }
        #endregion Commen
    }

}