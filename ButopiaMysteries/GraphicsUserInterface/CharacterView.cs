using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ButopiaMysteries.Logic;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A class that display a summarised character.
    /// </summary>
    public class CharacterView
    {
        /// <summary>
        /// The associated sheet.
        /// </summary>
        public MysterySheet Sheet {  get; init; }
        private Point location;
        /// <summary>
        /// The colour of the pawn.
        /// </summary>
        public Color Colour { get; internal set; } = ViewSettings.DefaultPawnColour;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sheet">the sheet</param>
        /// <param name="location">the pixel location</param>
        public CharacterView(MysterySheet sheet, Point location)
        {
            this.Sheet = sheet;
            this.location = location;
        }
        /// <summary>
        /// Call this method to draw the character in a window.
        /// </summary>
        /// <param name="graphics">the graphics context</param>
        public void Draw(Graphics graphics)
        {
            Rectangle r = new(location, ViewSettings.DefaultPawnFrame);
            graphics.DrawRectangle(ViewSettings.FramePen, r);
            DrawPawn(graphics, new Point(location.X+ViewSettings.DefaultPawnSide, location.Y), Colour);
            graphics.DrawString(Sheet.Name, ViewSettings.CharacterFont, new  SolidBrush(Colour), location.X, r.Bottom-ViewSettings.DefaultPawnSide);
        }
        /// <summary>
        /// Method to check if the mouse is in the bounding rectangle of the drawn item.
        /// </summary>
        /// <param name="point">a location in pixels</param>
        /// <returns>true iff the point is contained</returns>
        public bool Contains(Point point)
        {
            return new Rectangle(location, ViewSettings.DefaultPawnFrame).Contains(point);
        }
        /// <summary>
        /// An helper method that draws a simple geometric pawn using a circle and two rectangles : O|-
        /// </summary>
        /// <param name="graphics">the graphics context</param>
        /// <param name="basePoint">the starting location (top left)</param>
        /// <param name="colour">the colour of the drawing</param>
        static private void DrawPawn(Graphics graphics, Point basePoint, Color colour)
        {
            Point circleOrigin = new(basePoint.X + ViewSettings.DefaultPawnSide, basePoint.Y);
            Point hOrigin = new(basePoint.X, basePoint.Y + ViewSettings.DefaultPawnSide);
            Point vOrigin = new(basePoint.X + ViewSettings.DefaultPawnSide, basePoint.Y + ViewSettings.DefaultPawnSide * 2);
            Brush brush = new SolidBrush(colour);
            graphics.FillEllipse(brush, new Rectangle(circleOrigin, new Size(ViewSettings.DefaultPawnSide, ViewSettings.DefaultPawnSide)));
            graphics.FillRectangle(brush, new Rectangle(hOrigin, new Size(ViewSettings.DefaultPawnSide * 3, ViewSettings.DefaultPawnSide)));
            graphics.FillRectangle(brush, new Rectangle(vOrigin, new Size(ViewSettings.DefaultPawnSide, ViewSettings.DefaultPawnSide * 2)));
        }

        public void Move(Point nouvPosition)
        {
            location = nouvPosition;
        }
    }
}
