using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Osu__Song_Sorter
{
    class CustomTrackBar : Control
    {
        private int numberTicks = 10;
        private Rectangle trackRectangle = new Rectangle();
        private Rectangle thumbRectangle = new Rectangle();
        private int currentTickPosition = 0;
        private float tickSpace = 0;
        private bool thumbClicked = false;
        private TrackBarThumbState thumbState =
            TrackBarThumbState.Normal;

        public CustomTrackBar(int ticks, Size trackBarSize)
        {
            this.Location = new Point(10, 10);
            this.Size = trackBarSize;
            this.numberTicks = ticks;
            this.BackColor = Color.DarkCyan;
            this.DoubleBuffered = true;

            // Calculate the initial sizes of the bar, 
            // thumb and ticks.
            SetupTrackBar();
        }

        // Calculate the sizes of the bar, thumb, and ticks rectangle.
        private void SetupTrackBar()
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            using (Graphics g = this.CreateGraphics())
            {
                // Calculate the size of the track bar.
                trackRectangle.X = ClientRectangle.X + 2;
                trackRectangle.Y = ClientRectangle.Y + 28;
                trackRectangle.Width = ClientRectangle.Width - 4;
                trackRectangle.Height = 4;


                // Calculate the size of the thumb.
                thumbRectangle.Size =
                    TrackBarRenderer.GetTopPointingThumbSize(g,
                    TrackBarThumbState.Normal);

                thumbRectangle.X = CurrentTickXCoordinate();
                thumbRectangle.Y = trackRectangle.Y - 8;
            }
        }

        private int CurrentTickXCoordinate()
        {
            if (tickSpace == 0)
            {
                return 0;
            }
            else
            {
                return ((int)Math.Round(tickSpace) *
                    currentTickPosition);
            }
        }

        // Draw the track bar.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                this.Parent.Text = "CustomTrackBar Disabled";
                return;
            }

            this.Parent.Text = "CustomTrackBar Enabled";

            TrackBarRenderer.DrawHorizontalTrack(e.Graphics,
                trackRectangle);
            //SolidBrush blueBrush = new SolidBrush(Color.Blue);
            //e.Graphics.FillEllipse(blueBrush, thumbRectangle);
            TrackBarRenderer.DrawTopPointingThumb(e.Graphics,
                thumbRectangle, thumbState);
        }

        // Determine whether the user has clicked the track bar thumb.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            if (this.thumbRectangle.Contains(e.Location))
            {
                thumbClicked = true;
                thumbState = TrackBarThumbState.Pressed;
            }

            this.Invalidate();
        }

        // Redraw the track bar thumb if the user has moved it.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            if (thumbClicked == true)
            {
                if (e.Location.X > trackRectangle.X &&
                    e.Location.X < (trackRectangle.X +
                    trackRectangle.Width - thumbRectangle.Width))
                {
                    thumbClicked = false;
                    thumbState = TrackBarThumbState.Hot;
                    this.Invalidate();
                }

                thumbClicked = false;
            }
        }

        // Track cursor movements.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            // The user is moving the thumb.
            if (thumbClicked == true)
            {
                // Track movements to the next tick to the right, if 
                // the cursor has moved halfway to the next tick.
                if (currentTickPosition < numberTicks - 1 &&
                    e.Location.X > CurrentTickXCoordinate() +
                    (int)(tickSpace))
                {
                    currentTickPosition++;
                }

                // Track movements to the next tick to the left, if 
                // cursor has moved halfway to the next tick.
                else if (currentTickPosition > 0 &&
                    e.Location.X < CurrentTickXCoordinate() -
                    (int)(tickSpace / 2))
                {
                    currentTickPosition--;
                }

                thumbRectangle.X = CurrentTickXCoordinate();
            }

            // The cursor is passing over the track.
            else
            {
                thumbState = thumbRectangle.Contains(e.Location) ?
                    TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }

            Invalidate();
        }
    }
}
