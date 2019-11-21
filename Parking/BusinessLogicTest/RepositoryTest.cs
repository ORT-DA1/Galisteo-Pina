using Data;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest
{
    [TestClass]
    public class RepositoryTest
    {
        public class TestClass
        {
            public int TestId { get; set; } = 0;
        }

        TestClass TestObject { get; set; }
        Mock<DbContext> MockContext { get; set; }
        Mock<DbSet<TestClass>> MockDbSet { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestObject = new TestClass();
            MockContext = new Mock<DbContext>();
            MockDbSet = new Mock<DbSet<TestClass>>();
            MockContext.Setup(x => x.Set<TestClass>()).Returns(MockDbSet.Object);
            MockDbSet.Setup(x => x.Add(It.IsAny<TestClass>())).Returns(TestObject);
        }

        [TestMethod]
        public void AddTestPass()
        {

            // Act
            var repository = new Repository<TestClass>(MockContext.Object);
            repository.Add(TestObject);

            //Assert
            MockContext.Verify(x => x.Set<TestClass>());
            MockDbSet.Verify(x => x.Add(It.Is<TestClass>(y => y == TestObject)));
        }


        [TestMethod]
        public void GetAllTestPass()
        {

            var myEntities = new List<TestClass>()
             {
                new TestClass() { TestId = 1 },
                new TestClass() { TestId = 2 },
                new TestClass() { TestId = 3 }
             };

            var mockContext = new Mock<DbContext>();
            var mockDbSet = new Mock<DbSet<TestClass>>();
            mockContext.Setup(x => x.Set<TestClass>()).Returns(()=>mockDbSet.Object);

      
            var queryable = myEntities.AsQueryable();
            mockDbSet.As<IQueryable<TestClass>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<TestClass>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<TestClass>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<TestClass>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var repo = new Repository<TestClass>(mockContext.Object);
            var results = repo.GetAll();

            Assert.AreEqual(3, results.Count());
        }
    }

}

