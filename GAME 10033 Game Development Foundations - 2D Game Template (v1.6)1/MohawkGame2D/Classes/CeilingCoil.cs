using System;

namespace MohawkGame2D
{
    public class CeilingCoil()
    {
        // Coil variables
        public float TeslaX;
        public float TeslaY;
        public float TeslaW;
        public float TeslaH;

        // Generator variables
        public float SphereX;
        public float SphereY;
        public float SphereRadius;

        public void Update()
        {
            // Base
            Draw.Rectangle(TeslaX, TeslaY, TeslaW, TeslaH);

            // Electric generator
            Draw.Circle(SphereX, SphereY, SphereRadius);

        }
    }
}