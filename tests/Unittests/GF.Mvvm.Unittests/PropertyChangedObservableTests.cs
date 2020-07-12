using NUnit.Framework;

namespace GF.Mvvm.Unittests
{
    [TestFixture]
    public class PropertyChangedObservableTests
    {
        private class TestObservableA : PropertyChangeObservable
        {
            private string _propertyB;
            public string PropertyA { get; set; }

            public string PropertyB
            {
                get => _propertyB;
                set => this.SetField(ref _propertyB, value);
            }
        }

        [Test]
        public void PropertyChange_RaisesPropertyChangedEvent()
        {
            // Arrange
            var observable = new TestObservableA();
            var eventCounter = 0;
            observable.PropertyChanged += (sender, args) => eventCounter++;

            // Act
            // A does not Raise the event because it is not using SetField method
            observable.PropertyA = "A";
            observable.PropertyB = "B";

            // Assert
            Assert.That(observable.PropertyA, Is.EqualTo("A"));
            Assert.That(observable.PropertyB, Is.EqualTo("B"));
            Assert.That(eventCounter, Is.EqualTo(1));
        }

        [Test]
        public void PropertyChange_RaisesPropertyChangingBeforeChangedEvent()
        {
            // Arrange
            var observable = new TestObservableA();
            var eventCounter = 0;
            var changingOrderNumber = 0;
            var changedOrderNumber = 0;
            observable.PropertyChanging += (sender, args) => { changingOrderNumber = ++eventCounter; };
            observable.PropertyChanged += (sender, args) => { changedOrderNumber = ++eventCounter; };

            // Act
            // A does not Raise the event because it is not using SetField method
            observable.PropertyA = "A";
            observable.PropertyB = "B";

            // Assert
            Assert.That(observable.PropertyA, Is.EqualTo("A"));
            Assert.That(observable.PropertyB, Is.EqualTo("B"));
            Assert.That(eventCounter, Is.EqualTo(2));
            Assert.That(changingOrderNumber, Is.EqualTo(1));
            Assert.That(changedOrderNumber, Is.EqualTo(2));
        }

        [Test]
        public void PropertyChange_RaisesPropertyChangingEvent()
        {
            // Arrange
            var observable = new TestObservableA();
            var eventCounter = 0;
            observable.PropertyChanging += (sender, args) => eventCounter++;

            // Act
            // A does not Raise the event because it is not using SetField method
            observable.PropertyA = "A";
            observable.PropertyB = "B";

            // Assert
            Assert.That(observable.PropertyA, Is.EqualTo("A"));
            Assert.That(observable.PropertyB, Is.EqualTo("B"));
            Assert.That(eventCounter, Is.EqualTo(1));
        }
    }
}