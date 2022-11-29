using System;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.Tests
{
    public class OpticsComposerTests
    {
        [Fact]
        public void ComposeShouldChainLenses()
        {
            var person = new Person("Paul", "Louth", Map(
                                        (1, new Appt(1, DateTime.Parse("1/1/2010"), ApptState.NotArrived)),
                                        (2, new Appt(2, DateTime.Parse("2/1/2010"), ApptState.NotArrived)),
                                        (3, new Appt(3, DateTime.Parse("3/1/2010"), ApptState.NotArrived))));

            Lens<Person, ApptState> arrive(int id) => Person.appts
                                                            .Compose(Map<int, Appt>.item(id))
                                                            .Compose(Appt.state);

            var person2 = arrive(2).Set(ApptState.Arrived, person);

            Assert.True(person2.Appts[2].State == ApptState.Arrived);
        }

        [Fact]
        public void ComposeShouldChainLensesAndPrisms()
        {
            var expectedCar = new Car("Maserati", "Ghibli", 25000);
            var expectedWorker = new Worker("Joe Bloggs", 50000, expectedCar);
            var expected = new Job("Programmer", "Write code and tests.", expectedWorker);

            var car = new Car("Maserati", "Ghibli", 20000);
            var worker = new Worker("Joe Bloggs", 50000, car);
            var job = new Job("Programmer", "Write code and tests.", worker);

            Prism<Job, int> composedPrism = Job.worker
                                               .Compose(prism(Worker.car))
                                               .Compose(Car.mileage);

            var actual = composedPrism.Set(25000, job);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComposeShouldChainIsomorphismsAndLenses()
        {
            var expectedWorker = new Worker("modified", 50000, Option<Car>.None);
            var expected = new Job("Programmer", "Write code and tests.", expectedWorker);
            
            var worker = new Worker("Joe Bloggs", 50000, Option<Car>.None);
            var job = new Job("Programmer", "Write code and tests.", worker);

            Lens<Job, Seq<char>> composed = Job.worker
                                              .Compose(Worker.name)
                                              .Compose(IsomorphismTests.stringSeqIsomorphism);

            var actual = composed.Update(_ => "modified".ToSeq(), job);

            Assert.Equal(expected, actual);
        }

        [Fact]
        void ComposeShouldChainEpimorphsmsAndLenses()
        {
            var expectedWorker = new Engineer("Joe Bloggs", "55000", Option<Car>.None);
            var expected = new EngineeringJob("Programmer", "Write code and tests.", expectedWorker);

            var worker = new Engineer("Joe Bloggs", "50000", Option<Car>.None);
            var job = new EngineeringJob("Programmer", "Write code and tests.", worker);

            Prism<EngineeringJob, int> composed = EngineeringJob.worker
                                                                .Compose(Engineer.salary)
                                                                .Compose(EpimorphismTests.stringIntEpimorphism);

            var actual = composed.Update(x => x + 5000, job);

            Assert.Equal(expected, actual);
        }
    }

    [Record]
    public partial class Engineer
    {
        public readonly string Name;
        public readonly string Salary;
        public readonly Option<Car> Car;
    }

    [Record]
    public partial class EngineeringJob
    {
        public readonly string Name;
        public readonly string Description;
        public readonly Engineer Worker;
    }
}
