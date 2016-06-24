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
        public void given_spin_in_state_up_when_spin_measured_then_result_is_up()
        {
            var spin = new Spin(SpinState.Up);
            SpinState measurementResult = apparatus.Measure(spin);
            measurementResult.Should().Be(SpinState.Up);
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_twice_then_result_is_up()
        {
            var spin = new Spin(SpinState.Up);
            apparatus.Measure(spin);
            SpinState measurementResult = apparatus.Measure(spin);            
            measurementResult.Should().Be(SpinState.Up);
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_and_apparatus_rotated_then_result_is_up()
        {
            var spin = new Spin(SpinState.Up);

            var measurement1 = apparatus.Measure(spin);
            apparatus.Rotate(180);
            var measurement2 = apparatus.Measure(spin);

            measurement1.Should().Be(SpinState.Up);
            measurement2.Should().Be(SpinState.Down);
        }
    }
}

