using System;

namespace PairedCorrelationAnalysis
{
    using System.Collections.Generic;
    using System.Linq;

    public class CorrelationAnalysis
    {

        public double[] X
        {
            get => this.X;
            set
            {
                if (Y != default && Y.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.Y)} is already initialized; {nameof(this.X)} length should be equal to {nameof(this.Y)} length",
                        nameof(value)); 
                
                this.X = value;
            }
        }

        public double[] Y
        {
            get => this.Y;
            set
            {
                if (X != default && X.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.X)} is already initialized; {nameof(this.Y)} length should be equal to {nameof(this.X)} length",
                        nameof(value));

                this.Y = value;
            }
        }

        private IEnumerable<double> CovXYMultp
        {
            get
            {
                if (this.X == null)
                    throw new ArgumentNullException(nameof(this.X), $"{nameof(this.X)} cannot be Null");
                if (this.Y == null)
                    throw new ArgumentNullException(nameof(this.X), $"{nameof(this.Y)} cannot be Null");
                
                return X.Zip(Y, (x, y) => x * y);
            }
        }

        private double[] CovXYAvrg { get; set; }

        private double[] VarX { get; set; }
        private double[] VarXAvrg { get; set; }

        private double[] VarY { get; set; }
        private double[] VarYAvrg { get; set; }



    }
}
