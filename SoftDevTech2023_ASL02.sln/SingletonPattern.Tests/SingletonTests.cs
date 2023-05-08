using FluentAssertions;

namespace SingletonPattern.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void Instance_can_be_obtained_and_it_has_a_correct_date()
        {
            //not possible, because the constructor is private
            // var s1 = new Singleton();
            // var s2 = new Singleton();

            var s = Singleton.GetInstance();

            s.Should().NotBeNull();
            s.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
        }

        [Fact]
        public void Only_one_instance_exists()
        {
            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();

            ReferenceEquals(s1, s2).Should().BeTrue();
        }

        [Fact]
        public void Only_one_instance_exists_in_multithreaded_program()
        {
            Singleton s1 = null, s2 = null;

            Task task1 = Task.Factory.StartNew(() => s1 = Singleton.GetInstance());
            Task task2 = Task.Factory.StartNew(() => s2 = Singleton.GetInstance());

            Task.WaitAll(task1, task2);

            ReferenceEquals(s1, s2).Should().BeTrue();
        }
    }
}