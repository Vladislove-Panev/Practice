using NUnit.Framework;
using Gaus;

namespace GausTests
{
    [TestFixture(1)]
    [TestFixture(2)]
    [TestFixture(3)]
    [TestFixture(4)]
    [TestFixture(5)]
    [TestFixture(6)]
    [TestFixture(7)]
    public class Tests
    {
        double[,] matrixForTest; 
        int rowForTest;
        double divForTest;

        double[,] expectedForDivideRow;
        double[] expectedForCutResult;

        int firstRowForSubtractRows, secondRowForSubtractRows;
        double countForSubtractRows;
        double[,] expectedForSubtractRows;

        double[,] expectedForCreateDownOneAndZero;

        double[,] expectedForCreateUpOneAndZero;

        double[] expectedForSolve; 

        int a;

        public Tests(int a)
        {
            this.a = a;
        }

        [TearDown]
        public void Restore()
        {
            switch (a)
            {
                case 1:
                    matrixForTest = new double[,]
                    {
                        { 1, 1, 1, 1 },
                        { 2, 2, 2, 2 },
                        { 3, 3, 3, 3 }
                    };
                    break;
                case 2:
                    matrixForTest = new double[,]
                    {
                        { 1, 1, 1, 0 },
                        { 8, 4, 6, 8 },
                        { 15, 3, 5, 0 }
                    };
                    break;
                case 3:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, 1 },
                        { 2, -3, 4 }
                    };
                    break;
                case 4:
                    matrixForTest = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };
                    break;
                case 5:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, -5, -1 },
                        { 2, -1, 3, 13 },
                        { 1, 2, -1, 9 }
                    };
                    break;
                case 6:
                    matrixForTest = new double[,]
                    {
                        { 4, 2, -1, 1 },
                        { 5, 3, -2, 2 },
                        { 3, 2, -3, 0 }
                    };
                    break;
                case 7:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, 1, 1, -2 },
                        { 1, -1, 4, -1, -1 },
                        { -2, -2, -3, 2, 4 },
                        { 1, 5, -1, 2, 4 }
                    };
                    break;
            }
        }

        [OneTimeSetUp]
        public void CreateMatrix()
        {
            switch (a)
            {
                case 1:
                    matrixForTest = new double[,]
                    {
                        { 1, 1, 1, 1 },
                        { 2, 2, 2, 2 },
                        { 3, 3, 3, 3 }
                    };
                    rowForTest = 1;
                    divForTest = 2;

                    expectedForDivideRow = new double[,]
                    {
                        { 1, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                        { 3, 3, 3, 3 }
                    };

                    expectedForCutResult = new double[] { 1, 2, 3 };

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 2;
                    countForSubtractRows = 1;

                    expectedForSubtractRows = new double[,]
                    {
                        { 1, 1, 1, 1 },
                        { 2, 2, 2, 2 },
                        { 2, 2, 2, 2 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 1, 1, 1 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { -10, -10, -10, -10 },
                        { -4, -4, -4, -4 },
                        { 3, 3, 3, 3 }
                    };

                    expectedForSolve = new double[] { 1, 0, 0}; 
                    break;
                case 2:
                    matrixForTest = new double[,]
                    {
                        { 1, 1, 1, 0 },
                        { 8, 4, 6, 8 },
                        { 15, 3, 5, 0 }
                    };
                    rowForTest = 1;
                    divForTest = 4;

                    expectedForDivideRow = new double[,]
                    {
                        { 1, 1, 1, 0 },
                        { 2, 1, 6/4d, 2 },
                        { 15, 3, 5, 0 }
                    };

                    expectedForCutResult = new double[] { 0, 8, 0 };

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 1;
                    countForSubtractRows = 3;

                    expectedForSubtractRows = new double[,]
                    {
                        { 1, 1, 1, 0 },
                        { 5, 1, 3, 8 },
                        { 15, 3, 5, 0 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 1, 1, 0 },
                        { 0, 1, 1/2d, -2 },
                        { 0, 0, 1, 6 }
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { -178, -30, -52, 16 },
                        { -82, -14, -24, 8 },
                        { 15, 3, 5, 0 }
                    };

                    expectedForSolve = new double[] { -1, -5, 6 };
                    break;
                case 3:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, 1 },
                        { 2, -3, 4 }
                    };
                    rowForTest = 0;
                    divForTest = 3;

                    expectedForDivideRow = new double[,]
                    {
                        { 1, 2/3d, 1/3d },
                        { 2, -3, 4 }
                    };

                    expectedForCutResult = new double[] { 1, 4};

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 1;
                    countForSubtractRows = -2;

                    expectedForSubtractRows = new double[,]
                    {
                        { 3, 2, 1 },
                        { 8, 1, 6 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 2/3d, 1/3d },
                        { 0, 1, (4 - (2 * 1/3d)) / (-3 - 2 * 2/3d) }
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { -1, 8, -7 },
                        { 2, -3, 4 }
                    };

                    expectedForSolve = new double[] { 1/3d - (4 - (2 * 1 / 3d)) / (-3 - 2 * 2 / 3d) * (2/3d), (4 - (2 * 1 / 3d)) / (-3 - 2 * 2 / 3d) };
                    break;
                case 4:
                    matrixForTest = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    rowForTest = 2;
                    divForTest = 2;

                    expectedForDivideRow = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    expectedForCutResult = new double[] { 0, 0, 0 };

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 2;
                    countForSubtractRows = 0;

                    expectedForSubtractRows = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }
                    };

                    expectedForSolve = new double[] { 0, 0, 0 };
                    break;
                case 5:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, -5, -1 },
                        { 2, -1, 3, 13 },
                        { 1, 2, -1, 9 }
                    };

                    rowForTest = 1;
                    divForTest = -1;

                    expectedForDivideRow = new double[,]
                    {
                        { 3, 2, -5, -1 },
                        { -2, 1, -3, -13 },
                        { 1, 2, -1, 9 }
                    };

                    expectedForCutResult = new double[] { -1, 13, 9 };

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 1;
                    countForSubtractRows = -1;

                    expectedForSubtractRows = new double[,]
                    {
                        { 3, 2, -5, -1 },
                        { 5, 1, -2, 12 },
                        { 1, 2, -1, 9 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 2/3d, -5/3d, -1/3d },
                        { 0, 1, -2.7142857142857149d, -5.8571428571428577d },
                        { 0, 0, 1, 3.9999999999999991d }
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { 20, 96, -82, 212 },
                        { -1, -7, 6, -14 },
                        { 1, 2, -1, 9 }
                    };

                    expectedForSolve = new double[] { 2.9999999999999991d, 5, 3.9999999999999991d };
                    break;
                case 6:
                    matrixForTest = new double[,]
                    {
                        { 4, 2, -1, 1 },
                        { 5, 3, -2, 2 },
                        { 3, 2, -3, 0 }
                    };

                    rowForTest = 0;
                    divForTest = 2;

                    expectedForDivideRow = new double[,]
                    {
                        { 2, 1, -1/2d, 1/2d },
                        { 5, 3, -2, 2 },
                        { 3, 2, -3, 0 }
                    };

                    expectedForCutResult = new double[] { 1, 2, 0 };

                    firstRowForSubtractRows = 2;
                    secondRowForSubtractRows = 1;
                    countForSubtractRows = 1;

                    expectedForSubtractRows = new double[,]
                    {
                        { 4, 2, -1, 1 },
                        { 2, 1, 1, 2 },
                        { 3, 2, -3, 0 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 1/2d, -1/4d, 1/4d },
                        { 0, 1, -1.5d, 1.5d },
                        { 0, 0, 1, 1}
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { -37, -24, 28, -7 },
                        { 11, 7, -8, 2 },
                        { 3, 2, -3, 0 }
                    };

                    expectedForSolve = new double[] { -1, 3, 1 };
                    break;
                case 7:
                    matrixForTest = new double[,]
                    {
                        { 3, 2, 1, 1, -2 },
                        { 1, -1, 4, -1, -1 },
                        { -2, -2, -3, 2, 4 },
                        { 1, 5, -1, 2, 4 }
                    };

                    rowForTest = 2;
                    divForTest = -2;

                    expectedForDivideRow = new double[,]
                    {
                        { 3, 2, 1, 1, -2 },
                        { 1, -1, 4, -1, -1 },
                        { 1, 1, 3/2d, -1, -2 },
                        { 1, 5, -1, 2, 4 }
                    };

                    expectedForCutResult = new double[] { -2, -1, 4d, 4d };

                    firstRowForSubtractRows = 0;
                    secondRowForSubtractRows = 1;
                    countForSubtractRows = -1;

                    expectedForSubtractRows = new double[,]
                    {
                        { 3, 2, 1, 1, -2 },
                        { 4, 1, 5, 0, -3 },
                        { -2, -2, -3, 2, 4 },
                        { 1, 5, -1, 2, 4 }
                    };

                    expectedForCreateDownOneAndZero = new double[,]
                    {
                        { 1, 2/3d, 1/3d, 1/3d, -2/3d },
                        { 0, (-1 - 2/3d) / (-1 - 2/3d), -2.2000000000000002d, 0.80000000000000004d, 0.20000000000000004d },
                        { 0, 0, 1, -0.84210526315789458d, -0.73684210526315785d},
                        { 0, 0, 0, 1, 1.927835051546392d}
                    };

                    expectedForCreateUpOneAndZero = new double[,]
                    {
                        { -284, -819, -122, -144, -313 },
                        { 14, 40, 6, 7, 15 },
                        { -4, -12, -1, -2, -4 },
                        { 1, 5, -1, 2, 4 }
                    };

                    expectedForSolve = new double[] { -2.010309278350515d, 0.60824742268041176d, 0.88659793814432974d, 1.927835051546392d };
                    break;
            }
        }

        [Test]
        public void DivideRowTest()
        {
            double[,] actual = Matrix.DivideRow(matrixForTest, rowForTest, divForTest);
            Assert.AreEqual(expectedForDivideRow, actual);
        }

        [Test]
        public void CutResultTest()
        {
            double[] actual = Matrix.CutResult(matrixForTest);
            Assert.AreEqual(expectedForCutResult, actual);
        }

        [Test]
        public void SubtractRowsTest()
        {
            double[,] actual = Matrix.SubtractRows(matrixForTest, firstRowForSubtractRows, secondRowForSubtractRows, countForSubtractRows);
            Assert.AreEqual(expectedForSubtractRows, actual);
        }

        [Test]
        public void CreateDownOneAndZeroTest()
        {
            double[,] actual = Matrix.CreateDownOneAndZero(matrixForTest);
            Assert.AreEqual(expectedForCreateDownOneAndZero, actual);
        }

        [Test]
        public void CreateUpOneAndZeroTest()
        {
            double[,] actual = Matrix.CreateUpOneAndZero(matrixForTest);
            Assert.AreEqual(expectedForCreateUpOneAndZero, actual);
        }

        [Test]
        public void SolveTest()
        {
            double[] actual = Matrix.Solve(matrixForTest);
            Assert.AreEqual(expectedForSolve, actual);
        }
    }
}