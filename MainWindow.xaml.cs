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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u4DiceArrays
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        Random r = new Random();
        int[] diceRolls = new int[13];
        public MainWindow()
        {
            InitializeComponent();

            //initialize array elements
            for (int i = 0; i < diceRolls.Length; i++)
            {
                diceRolls[i] = 0;
            }

            //simulate 1000 dice rolls
            for (int i = 0; i < 1000; i++)
            {
                //count how many times the dice roll
                diceRolls[r.Next(1, 7) + r.Next(1, 7)]++;
            }
            //draw rectangles for the rolls
            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.WriteLine(diceRolls[i]);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = Brushes.Red;
                rectangle.Width = this.Width / 640.0 * (640.0 / 15.0)-5;
                rectangle.Height = diceRolls[i] / 1000.0 * 640.0;
                canvas.Children.Add(rectangle);

                //spread the rectangles out
                Canvas.SetLeft(rectangle, (640.0 / 15.0)*i);
                //move them to the bottom of the screen
                Canvas.SetTop(rectangle, 640 - rectangle.Height);
            }

        }
    }
}
