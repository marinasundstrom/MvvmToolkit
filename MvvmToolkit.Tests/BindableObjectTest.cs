using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MvvmToolkit.Tests
{
    public class BindableObjectTest
    {
        [Fact(DisplayName = "PropertyChanged is invoked when property changed")]
        public void PropertyChangedIsInvokedWhenPropertyChanged()
        {
            string expectedValue = "test";

            TestBindableObject bindableObject = new TestBindableObject();

            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            Assert.Null(bindableObject.Foo);

            bindableObject.PropertyChanged += async (s, e) =>
            {
                await Task.Delay(500);

                autoResetEvent.Set();
            };

            bindableObject.Foo = expectedValue;

            autoResetEvent.WaitOne();

            Assert.Equal(expectedValue, bindableObject.Foo);
        }
    }

    public class TestBindableObject : BindableObject
    {
        private string foo;

        public string Foo
        {
            get => foo;
            set => SetProperty(ref foo, value);
        }
    }
}
