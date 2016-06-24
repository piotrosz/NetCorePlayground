using FluentAssertions;
using Xunit;

namespace Quantum
{
    public class SpinMeasurementTests
    {
        private Apparatus apparatus;

        public SpinMeasurementTests()
        {
            apparatus = new Apparatus();
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_then_the_measurement_result_is_up()
        {
            var spin = new Spin(SpinState.Up);
            SpinState measurementResult = apparatus.Measure(spin);
            measurementResult.Should().Be(SpinState.Up);
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_twice_then_the_measurement_result_is_up()
        {
            var spin = new Spin(SpinState.Up);
            apparatus.Measure(spin);
            SpinState measurementResult = apparatus.Measure(spin);            
            measurementResult.Should().Be(SpinState.Up);
        }
    }
}

