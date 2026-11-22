using System;

namespace MohawkGame2D
{
    public class Spike()
    {
        // Color variables
        public Color SpikeColor = Color.Black;

        // Position variables
        public float TriX1;
        public float TriX2;
        public float TriX3;
        public float TriY1;
        public float TriY2;

        public void Update()
        {
            // Spike
            Draw.SetLineColor(Color.DarkGray);
            Draw.SetFillColor(SpikeColor);
            Draw.Triangle(TriX1, TriY1, TriX2, TriY2, TriX3, TriY1);
        }
    }
}
