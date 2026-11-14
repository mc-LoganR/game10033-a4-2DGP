using System;

namespace MohawkGame2D
{
    public class Spike()
    {
        // Position variables
        public float triX1;
        public float triX2;
        public float triX3;
        public float triY1;
        public float triY2;

        public void Update()
        {
            Draw.SetLineColor(Color.Black);
            Draw.SetFillColor(Color.DarkGray);
            Draw.Triangle(triX1, triY1, triX2, triY2, triX3, triY1);
        }
    }
}
