using System;
using System.Security.Cryptography.X509Certificates;

namespace MohawkGame2D
{
    public class Laser()
    {

        // Base variables
        public float BaseX;
        public float BaseY;
        public float BaseW;
        public float BaseH;

        // Laser variables
        public float LaserX;
        public float LaserY;
        public float LaserW;
        public float LaserH;

        // Colors
        public Color BaseColor;
        public Color LaserColor = new(204, 51, 51);

        public void Update()
        {
            // Base
            Draw.SetFillColor(BaseColor);
            Draw.Rectangle(BaseX, BaseY, BaseW, BaseH);

            // Laser
            Draw.SetFillColor(LaserColor);
            Draw.Rectangle(LaserX, LaserY, LaserW, LaserH);

        }
    }
}
