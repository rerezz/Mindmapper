using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace MindmapperCore
{
    /// <summary>
    /// Class who controlls the display of the mindmap
    /// </summary>
    internal class DisplayController
    {
        private const int ITEM_WIDTH = 100;
        private const int ITEM_HEIGTH = 50;
        private const int CONNECTION_LENGTH = 50;
        private Canvas m_Canvas;
        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas">canvas to display the mindmap</param>
        public DisplayController(Canvas canvas)
        {
            m_Canvas = canvas;
        }
        
        /// <summary>
        /// Clears the display
        /// </summary>
        private void ClearDisplay()
        {
            m_Canvas.Children.Clear();
        }

        /// <summary>
        /// Displays the given mindmap
        /// </summary>
        /// <param name="m_Mindmap">mindmap</param>
        internal void DisplayMindmap(Mindmap m_Mindmap)
        {
            ClearDisplay();
            DisplayMindmapStructure(m_Mindmap.GetFirstItem());
        }

        /// <summary>
        /// Displays a mindmap structure starting from a root element
        /// </summary>
        /// <param name="rootElement">root item</param>
        private void DisplayMindmapStructure(Item rootElement)
        {
            int posTop = 250;
            int posLeft = 250;

            DisplayItemElement(rootElement, posTop, posLeft);
            DisplaySubStructure(rootElement, posTop, posLeft, ConnectionDirections.Direction.None);
        }

        /// <summary>
        /// Displays the substructure of an element.
        /// </summary>
        /// <param name="element">mindmap item</param>
        /// <param name="top">current position top</param>
        /// <param name="left">current position left</param>
        private void DisplaySubStructure(Item element, int top, int left, ConnectionDirections.Direction excludingDirection)
        {
            int[] connectionPoints;
            int[] newElementPosition;
            ConnectionDirections.Direction oppositeDirection;
            Item nextElement;

            foreach (KeyValuePair<ConnectionDirections.Direction,ItemConnection> connection in element.Connections)
            {
                if (connection.Key != excludingDirection)
                {
                    connectionPoints = GetItemConnectionPoints(connection.Key, top, left);
                    oppositeDirection = ConnectionDirections.GetOppositeDirection(connection.Key);
                    newElementPosition = GetElementPosition(oppositeDirection,connectionPoints[2], connectionPoints[3]);
                    DisplayConnection(connectionPoints[0], connectionPoints[1], connectionPoints[2], connectionPoints[3]);
                    nextElement = connection.Value.GetOtherItem(element.Name);
                    DisplayItemElement(nextElement, newElementPosition[0], newElementPosition[1]);
                    DisplaySubStructure(nextElement, newElementPosition[0], newElementPosition[1], oppositeDirection);
                }
            }
        }

        /// <summary>
        /// Displays one single element
        /// </summary>
        /// <param name="item">mindmap item to display</param>
        /// <param name="top">position top</param>
        /// <param name="left">position left</param>
        private void DisplayItemElement(Item item, int top, int left)
        {
            Ellipse mindmapItem = new Ellipse();
            Label itemCaption = new Label();
            Brush brush = GetColorBrush(item.Color);

            mindmapItem.Stroke = brush;
            mindmapItem.Width = ITEM_WIDTH;
            mindmapItem.Height = ITEM_HEIGTH;

            itemCaption.Content = item.Caption;
            itemCaption.Width = ITEM_WIDTH;
            itemCaption.Height = ITEM_HEIGTH;
            itemCaption.HorizontalAlignment = HorizontalAlignment.Left;
            itemCaption.VerticalAlignment = VerticalAlignment.Center;
            itemCaption.HorizontalContentAlignment = HorizontalAlignment.Center;
            itemCaption.VerticalContentAlignment = VerticalAlignment.Center;

            m_Canvas.Children.Add(mindmapItem);
            m_Canvas.Children.Add(itemCaption);

            Canvas.SetTop(mindmapItem, top);
            Canvas.SetLeft(mindmapItem, left);
            Canvas.SetTop(itemCaption, top);
            Canvas.SetLeft(itemCaption, left);
        }

        /// <summary>
        /// Displays a connector line
        /// </summary>
        /// <param name="top1">position of first point</param>
        /// <param name="left1">position of first point</param>
        /// <param name="top2">position of second point</param>
        /// <param name="left2">position of second point</param>
        private void DisplayConnection(int top1, int left1, int top2, int left2)
        {
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Black;
            line.X1 = left1;
            line.X2 = left2;
            line.Y1 = top1;
            line.Y2 = top2;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            line.StrokeThickness = 2;

            m_Canvas.Children.Add(line);
        }
        
        /// <summary>
        /// Returns a color brush
        /// </summary>
        /// <param name="color">color</param>
        /// <returns>brush</returns>
        private static Brush GetColorBrush(string color)
        {
            switch (color)
            {
                case "red":
                    return Brushes.Red;
                case "blue":
                    return Brushes.Blue;
                case "green":
                    return Brushes.Green;
                case "yellow":
                    return Brushes.Yellow;
                case "violet":
                    return Brushes.Violet;
                default:
                    return Brushes.Black;
            }
        }

        /// <summary>
        /// Returns the start point for a connection to an other object
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <returns></returns>
        private int[] GetItemConnectionPoints(ConnectionDirections.Direction direction,int top, int left)
        {
            int[] position = new int[4];
            
            switch (direction)
            {
                case ConnectionDirections.Direction.North:
                    position[0] = top;
                    position[1] = left + ITEM_WIDTH / 2;
                    position[2] = position[0] - CONNECTION_LENGTH;
                    position[3] = position[1];
                    break;
                default:
                    position[0] = top;
                    position[1] = left;
                    break;
            }

            return position;
        }

        /// <summary>
        /// Gets the item position based of a connection point
        /// </summary>
        /// <param name="direction">connection point direction</param>
        /// <param name="top">top</param>
        /// <param name="left">left</param>
        /// <returns>position</returns>
        private int[] GetElementPosition(ConnectionDirections.Direction direction, int top, int left)
        {
            int[] position = new int[2];

            switch (direction)
            {
                case ConnectionDirections.Direction.South:
                    position[0] = top - ITEM_HEIGTH;
                    position[1] = left - ITEM_WIDTH / 2;
                    break;
                default:
                    position[0] = top;
                    position[1] = left;
                    break;
            }

            return position;
        }

    }
}
