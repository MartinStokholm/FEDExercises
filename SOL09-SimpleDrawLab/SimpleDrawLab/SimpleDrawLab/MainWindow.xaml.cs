using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;

namespace SimpleDrawLab
{
    public enum DrawingTool { Line, Ellipsis, Rectangle };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color drawColor;
        Point startPos;
        Point currPos;
        Shape currShape;
        bool isDrawing = false;
        DrawingTool tool;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            KeyUp += new KeyEventHandler(MainWindow_KeyUp);
            MouseDown += new MouseButtonEventHandler(MainWindow_MouseDown);
            MouseMove += new MouseEventHandler(MainWindow_MouseMove);
            MouseUp += new MouseButtonEventHandler(MainWindow_MouseUp);
            SetColor(Colors.Black);
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPos = e.GetPosition(canvas);
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0
                | (Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
                {
                    tool = DrawingTool.Ellipsis;
                    currShape = new Ellipse();
                }
                else
                {
                    tool = DrawingTool.Rectangle;
                    currShape = new Rectangle();
                }
                Canvas.SetLeft(currShape, startPos.X);
                Canvas.SetTop(currShape, currPos.Y);
                currShape.Width = 2;
                currShape.Height = 2;
                currShape.Fill = new SolidColorBrush(drawColor);
            }
            else
            {
                tool = DrawingTool.Line;
                Line l = new Line(); ;
                l.Stroke = new SolidColorBrush(drawColor);
                l.StrokeThickness = 2.0;
                l.X1 = startPos.X;
                l.Y1 = currPos.Y;
                l.X2 = currPos.X + 1;
                l.Y2 = currPos.Y + 1;
                currShape = l;
            }

            // Capture the mouse and prepare for future events.
            CaptureMouse();
            canvas.Children.Add(currShape);
            isDrawing = true;
        }

        void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            currPos = e.GetPosition(canvas);
            tbxX.Text = currPos.X.ToString("F0");
            tbxY.Text = currPos.Y.ToString("F0");
            if (isDrawing)
                if (tool != DrawingTool.Line)
                {
                    double width = currPos.X - startPos.X;
                    double height = currPos.Y - startPos.Y;
                    currShape.Width = (width > 1 ? width : 2);
                    currShape.Height = (height > 1 ? height : 2);
                }
                else
                {
                    Line l = currShape as Line;
                    l.X2 = currPos.X;
                    l.Y2 = currPos.Y;
                }
        }

        void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
            ReleaseMouseCapture();
        }

        void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.B:
                    SetColor(Colors.Black);
                    break;
                case Key.Y:
                    SetColor(Colors.Yellow);
                    break;
                case Key.R:
                    SetColor(Colors.Red);
                    break;
                case Key.G:
                    SetColor(Colors.Green);
                    break;
                case Key.W:
                    SetColor(Colors.GreenYellow);
                    break;
                case Key.U:
                    SetColor(Colors.Blue);
                    break;
                default:
                    break;
            }
        }

        private void SetColor(Color color)
        {
            drawColor = color;
            rctColor.Fill = new SolidColorBrush(drawColor);
        }
    }
}