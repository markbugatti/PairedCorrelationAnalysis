using System;

namespace PairedCorrelationAnalysis
{
    using System.Collections.Generic;
    using System.Linq;

    public class CorrelationAnalysis
    {
        private double[] _x;
        private double[] _y;

        public CorrelationAnalysis(double[] xMul, double[] yMul)
        {
            this.X = xMul;
            this.Y = yMul;
        }

        public CorrelationAnalysis(IEnumerable<double> xMul, IEnumerable<double> yMul)
        {
            this.X = xMul.ToArray();
            this.Y = yMul.ToArray();
        }

        public double[] X
        {
            get => this._x;
            set
            {
                if (this.Y != null && this.Y.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.Y)} is already initialized; {nameof(this.X)} length should be equal to {nameof(this.Y)} length",
                        nameof(value)); 
                
                this._x = value;
            }
        }

        public double[] Y
        {
            get => this._y;
            set
            {
                if (X != null && X.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.X)} is already initialized; {nameof(this.Y)} length should be equal to {nameof(this.X)} length",
                        nameof(value));

                this._y = value;
            }
        }

        private double XAvg
        {
            get
            {
                if (X == null)
                    throw new ArgumentNullException(nameof(X), $"{nameof(X)} should be initialized first");

                return X.Average();
            }
        }

        private double YAvg
        {
            get
            {
                if (Y == null)
                    throw new ArgumentNullException(nameof(Y), $"{nameof(Y)} should be initialized first");

                return Y.Average();
            }
        }

        public double CovXY
        {
            get
            {
                if (X == null) 
                    throw new ArgumentNullException(nameof(X), $"{nameof(X)} should be initialized first");
                if (Y == null) 
                    throw new ArgumentNullException(nameof(Y), $"{nameof(Y)} should be initialized first");
                
                var xyAvg = this.X.Zip(this.Y, (x, y) => x * y).Average();
                var MultOfXYAvrgs = XAvg * YAvg;

               return xyAvg - MultOfXYAvrgs;
            }
        }

        public double VarX
        {
            get
            {
                var xSqr = X.Select(p => p * p).Average();

                return xSqr - XAvg * XAvg;
            }
        }

        public double VarY
        {
            get
            {
                var ySqr = Y.Select(p => p * p).Average();

                return ySqr - YAvg * YAvg;
            }
        }

    }
}
