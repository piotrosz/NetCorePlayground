using FluentAssertions;
using Xunit;
using static System.Math;

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
            var measurementResult = apparatus.Measure(spin);
            measurementResult.Value.Should().Be(1);
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_twice_then_result_is_up()
        {
            var spin = new Spin(SpinState.Up);
            apparatus.Measure(spin);
            var measurementResult = apparatus.Measure(spin);            
            measurementResult.Value.Should().Be(1);
        }

        [Fact]
        public void given_spin_in_state_up_when_spin_measured_and_apparatus_flipped_then_result_is_down()
        {
            var spin = new Spin(SpinState.Up);

            var measurement1 = apparatus.Measure(spin);
            apparatus.Rotate(180);
            var measurement2 = apparatus.Measure(spin);

            measurement1.Value.Should().Be(1);
            measurement2.Value.Should().Be(-1);
        }

        [Fact]
        public void given_spin_in_state_up_when_apparatus_rotated_by_90_degrees_then_result_is_up_with_50_percent_probability()
        {
            var spin = new Spin(SpinState.Up);

            apparatus.Rotate(90);
            var measurement = apparatus.Measure(spin);
            Abs(measurement.Value).Should().BeLessThan(0.00001);
        }
    }
}

