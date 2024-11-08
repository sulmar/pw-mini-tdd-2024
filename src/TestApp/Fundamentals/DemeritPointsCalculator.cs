using System;

namespace TestApp.Fundamentals
{
    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 50;

        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException();

            if (speed <= SpeedLimit) return 0;

            const int kmPerDemeritPoint = 5;

            var demeritPoints = (SpeedLimit - speed) / kmPerDemeritPoint;

            return demeritPoints;
        }
    }
}
