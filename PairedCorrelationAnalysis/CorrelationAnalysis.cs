using System;

namespace PairedCorrelationAnalysis
{
    using System.Collections.Generic;
    using System.Linq;

    public class CorrelationAnalysis
    {
        private double[] _x;
        private double[] _y;

        public CorrelationAnalysis()
        {
        }

        public CorrelationAnalysis(double[] xMul, double[] yMul)
        {
            this._x = xMul;
            this._y = yMul;
        }

        public CorrelationAnalysis(IEnumerable<double> xMul, IEnumerable<double> yMul)
        {
            this._x = xMul.ToArray();
            this._y = yMul.ToArray();
        }

        /// <summary>
        /// The sample of independent values
        /// </summary>
        public double[] X
        {
            get
            {
                if (this._x == null) throw new NullReferenceException($"{nameof(X)} should be initialized first");

                return this._x;
            }
            set
            {
                if (this._y != null && this._y.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.Y)} is already initialized; {nameof(this.X)} length should be equal to {nameof(this.Y)} length",
                        nameof(value)); 
                
                this._x = value;
            }
        }

        /// <summary>
        /// The sample of dependent values corresponding to X.
        /// Each single value in this sample should correspond to values in X sample.
        /// </summary>
        public double[] Y
        {
            get
            {
                if (this._y == null) throw new NullReferenceException($"{nameof(Y)} should be initialized first");
                
                return this._y;
            }
            set
            {
                if (_x != null && _x.Length != value.Length)
                    throw new ArgumentException(
                        $"{nameof(this.X)} is already initialized; {nameof(this.Y)} length should be equal to {nameof(this.X)} length",
                        nameof(value));

                this._y = value;
            }
        }
        
        /// <summary>
        /// Average of sample X 
        /// </summary>
        private double XAvg
        {
            get
            {
                if (X == null)
                    throw new ArgumentNullException(nameof(X), $"{nameof(X)} should be initialized first");

                return X.Average();
            }
        }

        /// <summary>
        /// Average of sample Y 
        /// </summary>
        private double YAvg
        {
            get
            {
                if (Y == null)
                    throw new ArgumentNullException(nameof(Y), $"{nameof(Y)} should be initialized first");

                return Y.Average();
            }
        }

        /// <summary>
        /// Sample covariance (Вибіркова коваріація)
        /// </summary>
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

        /// <summary>
        /// X's sample variance (Вибіркова дисперсія X)
        /// </summary>
        public double VarX
        {
            get
            {
                if (X == null) throw new ArgumentNullException(nameof(X), $"{nameof(X)} should be initialized first");
                
                var xSqr = X.Select(p => p * p).Average();
                return xSqr - XAvg * XAvg;
            }
        }

        /// <summary>
        /// Y's sample variance (Вибіркова дисперсія Y)
        /// </summary>
        public double VarY
        {
            get
            {
                if (Y == null) throw new ArgumentNullException(nameof(Y), $"{nameof(Y)} should be initialized first");

                var ySqr = Y.Select(p => p * p).Average();
                return ySqr - YAvg * YAvg;
            }
        }

        /// <summary>
        /// The correlation coefficient (Коефіцієнт кореляції)
        /// </summary>
        public double CorrelationCoefficient => CovXY / Math.Sqrt(VarX * VarY);
    }
}
