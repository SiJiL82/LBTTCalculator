namespace LBTTCalculator
{
    //Class to store an LBTT band in
    public class LBTTBand
    {
        public double lower;
        public double upper;
        public double rate;

        //Constructor which sets the bands and rate
        public LBTTBand(double lower, double upper, double rate)
        {
            this.lower = lower;
            this.upper = upper;
            this.rate = rate;
        }
    }
}