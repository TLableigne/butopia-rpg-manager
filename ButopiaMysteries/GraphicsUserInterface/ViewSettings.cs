
namespace ButopiaMysteries.GraphicsUserInterface
{
    public static class ViewSettings
    {
        /// <summary>
        /// Pixel value of one pawn side (sleeve, leg).
        /// </summary>
        public static int DefaultPawnSide { get; } = 20;
        /// <summary>
        /// Pixel size of the bounding rectangle of one frame around a pawn.
        /// </summary>
        public static Size DefaultPawnFrame { get; } = new Size(100, 100);
        /// <summary>
        /// The basic colour of a pawn.
        /// </summary>
        public static Color DefaultPawnColour { get; } = Color.DarkCyan;
        /// <summary>
        /// The pen used to draw the outline of pawn frames.
        /// </summary>
        public static Pen FramePen { get; } = Pens.Black;
        /// <summary>
        /// The font used to draw the names.
        /// </summary>
        public static Font CharacterFont { get; } = SystemFonts.DefaultFont;
    }
}