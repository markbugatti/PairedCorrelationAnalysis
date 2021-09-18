using System;
using NUnit.Framework;

namespace PairedCorrelationAnalysisTests
{
    using System.Diagnostics.CodeAnalysis;

    using PairedCorrelationAnalysis;

    public class Tests
    {
        private CorrelationAnalysis correlationAnalysisClient;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(
            new[] { 4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5 },
            new[] { 866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218 })]
        [Test]
        public void X_ShouldReturnX_WhenDataInitialized(double[] X, double[] Y)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(X, this.correlationAnalysisClient.X);
        }

        [TestCase(
            new[] { 4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5 },
            new[] { 866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218 })]
        [Test]
        public void Y_ShouldReturnY_WhenDataInitialized(double[] X, double[] Y)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(this.correlationAnalysisClient.Y, Y);
        }

        [Test]
        public void X_ShouldThrowNullReferenceException_WhenIsNotInitialized()
        {
            //Arrange

            //Assert
            Assert.Throws<NullReferenceException>( () =>
            {
                this.correlationAnalysisClient = new CorrelationAnalysis();
                var x = this.correlationAnalysisClient.X;
            });
        }

        [TestCase(
            new[] { 4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5 },
            new[] { 866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218 },
            -1055.89)]
        [Test]
        public void CovXY_ShouldBeCorrect_WhenDataInitialized(double[] X, double[] Y, double expected)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(this.correlationAnalysisClient.CovXY, expected, 0.01d);
        }
        
        [TestCase(
            new[] { 4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5 },
            new[] { 866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218 },
            28.97)]
        [Test]
        public void VarX_ShouldBeCorrect_WhenDataInitialized(double[] X, double[] Y, double expected)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(this.correlationAnalysisClient.VarX, expected, 0.01d);
        }  
        
        [TestCase(
            new[] { 4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5 },
            new[] { 866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218 },
            58944.35)]
        [Test]
        public void VarY_ShouldBeCorrect_WhenDataInitialized(double[] X, double[] Y, double expected)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(this.correlationAnalysisClient.VarY, expected, 0.01d);
        }

        [TestCase(
            new[] {4, 7, 7.1, 8.7, 11.7, 12.7, 12.8, 14.5, 15, 18.5, 20, 22.5},
            new[] {866d, 926, 783, 718, 355, 290, 625, 400, 510, 600, 180, 218},
            -0.808)]
        [Test]
        public void CorrelationCoefficient_ShouldBeCorrect_WhenDataInitialized(double[] X, double[] Y, double expected)
        {
            //Arrange
            this.correlationAnalysisClient = new CorrelationAnalysis(X, Y);

            //Assert
            Assert.AreEqual(this.correlationAnalysisClient.CorrelationCoefficient, expected, 0.001);
        }
    }
}