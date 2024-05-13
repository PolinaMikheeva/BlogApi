using BlogApi.Entities;
using BlogApi.MappingService;
using BlogApi.Models.Post;

namespace BlogApi.UnitTests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void TestMethod1()
        {

            // Arrange
            var date = DateTime.Now;

            var post = new Post {
                Id = 1,
                Title = "Title",
                User = new User
                {
                    Id = 1,
                    FullName = "Name"
                },
                Description = "Description",
                Complexity = "Easy",
                MinDescription = "Min",
                TimeReading = 2,
                Views = 11,
                Section = new DataAccess.Entities.Section
                {
                    Id = 1,
                    Name = "Name",
                },
                Date = date

            };

            // Act
            PostDto b = Mapper.Map<Post, PostDto>(post);

            // Assert
            Assert.AreEqual(1, b.Id);
            Assert.AreEqual("Title", b.Title);
            Assert.AreEqual("Name", b.UserFullName);
            Assert.AreEqual("Description", b.Description);
            Assert.AreEqual("Easy", b.Complexity);
            Assert.AreEqual("Min", b.MinDescription);
            Assert.AreEqual(2, b.TimeReading);
            Assert.AreEqual(11, b.Views);
            Assert.AreEqual("Name", b.SectionName);
            Assert.AreEqual(date, b.Date);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var a = new A { Id = 1, Name = "Иван", Description = "Описание" };

            // Act
            var b = Mapper.Map<A, B>(a);

            // Assert
            Assert.AreEqual(1, b.Id);
            Assert.AreEqual("Иван", b.Name);
            Assert.AreEqual("Описание", b.Description);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            var a1 = new A1 { Id = 1, Name = "Иван", Description = "Описание", C = new C 
            {
                Age = 18,
                Email = "Test"
            } };

            // Act
            var b = Mapper.Map<A1, B1>(a1);

            // Assert
            Assert.AreEqual(1, b.Id);
            Assert.AreEqual("Иван", b.Name);
            Assert.AreEqual("Описание", b.Description);

            Assert.AreEqual(18, b.C.Age);
            Assert.AreEqual("Test", b.C.Email);
        }
    }

    public class A
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class B
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class A1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public C C { get; set; }
    }

    public class B1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public C C { get; set; }
    }

    public class C
    {
        public string Email { get; set; }

        public int Age { get; set; }
    }
}