using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using MLibrary;

namespace MazeZero
{
    /// <summary>
    /// Interaction logic for Maze1.xaml
    /// </summary>
    public partial class Maze1 : Window
    {
        int CurrentRow = 1, CurrentCoulmn = 0;
        System.Timers.Timer T = new System.Timers.Timer();

         Stack<Directions> Solution;

        public Maze1()
        {
            InitializeComponent();

            
            BFSAlgorithm BFS = new BFSAlgorithm(new bool?[,] {
                {false, false, false, false, false, false, false, false, false, false},
                {false, null, null, null, null, false, null, null, null, false},
                {false, false, null, false, false, false, null, null, null, false},
                {false, null, null, false, null, null, null, null, null, false},
                {false, null, null, null, null, null, null, null, null, false},
                {false, false, false, false, false, false, null, false, false, false},
                {false, null, null, null, null, null, null, false, null, true},
                {false, null, false, false, false, false, null, false, null, false},
                {false, null, null, null, null, null, null,null, null, false},
                {false, false, false, false, false, false, false, false, false, false}

            }, CurrentRow, CurrentCoulmn);

            Solution = BFS.getSolution();

            if (Solution != null)
            {
                T.Interval = 500;
                T.Elapsed += T_Elapsed;
                T.Enabled = true;
            }
            else
                System.Windows.Forms.MessageBox.Show("No Solution");

            
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            Directions D = Solution.Pop();

            Container.Dispatcher.Invoke(new MethodInvoker(delegate
            {
                if (D == Directions.Right)
                    GoRight();
                else if (D == Directions.Down)
                    GoDown();
                else if (D == Directions.Left)
                    GoLeft();
                else if (D == Directions.Up)
                    GoUp();
            }));

            if (Solution.Count == 0)
            {
                T.Enabled = false;
                System.Windows.MessageBox.Show("Congratulation you win !");
            }
            
        }

        #region Go Right

        private void GoRight()
        {
            Rectangle R = new Rectangle();
            R.SetValue(Grid.ColumnProperty, ++CurrentCoulmn);
            R.SetValue(Grid.RowProperty, CurrentRow);
            R.Fill = Brushes.LightBlue;
            Container.Children.Add(R);
        }

        #endregion

        #region Go Down

        private void GoDown()
        {
            Rectangle R = new Rectangle();
            R.SetValue(Grid.ColumnProperty, CurrentCoulmn);
            R.SetValue(Grid.RowProperty, ++CurrentRow);
            R.Fill = Brushes.LightBlue;
            Container.Children.Add(R);
        }

        #endregion

        #region Go Left

        private void GoLeft()
        {
            int newCol = CurrentCoulmn - 1;

            if (newCol >= 0)
            {
                Rectangle R = new Rectangle();
                R.SetValue(Grid.ColumnProperty, --CurrentCoulmn);
                R.SetValue(Grid.RowProperty, CurrentRow);
                R.Fill = Brushes.LightBlue;
                Container.Children.Add(R);
            }

        }

        #endregion

        #region Go Up

        private void GoUp()
        {
            int newRow = CurrentRow - 1;
            if (!(newRow == 0))
            {
                Rectangle R = new Rectangle();
                R.SetValue(Grid.ColumnProperty, CurrentCoulmn);
                R.SetValue(Grid.RowProperty, --CurrentRow);
                R.Fill = Brushes.LightBlue;
                Container.Children.Add(R);
            }

        }

        #endregion

    }
}
