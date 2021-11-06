using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AhDung.WinForm.Controls
{
    /* to do:
     * rotate arrow
     * image, include gif
     * flat and popup styles
     */
    /// <summary>
    /// A button with split area
    /// </summary>
    public class SplitButton : Button
    {
        bool _inPrimary;
        int _splitWidth = 20;

        [Description("Split area clicked event")]
        public event EventHandler ClickSplit;

        [Description("Split area width")]
        [DefaultValue(20)]
        public int SplitWidth
        {
            get => _splitWidth;
            set
            {
                if (_splitWidth == value)
                    return;

                if (value < 0)
                    value = 0;
                else if (value > Width)
                    value = Width;

                _splitWidth = value;
                Invalidate();
            }
        }

        [DefaultValue(null)]
        public ContextMenu SplitDropDownMenu { get; set; }

        [DefaultValue(null)]
        public ContextMenuStrip SplitDropDownMenuStrip { get; set; }

        [Description("Only allow Standard")]
        [DefaultValue(FlatStyle.Standard)]
        public new FlatStyle FlatStyle
        {
            get => base.FlatStyle;
            set
            {
                if (value == FlatStyle.System)
                    value = FlatStyle.Standard;

                if (base.FlatStyle != value)
                    base.FlatStyle = value;
            }
        }

        int SplitLeft => Width - SplitWidth;

        Rectangle PrimaryRectangle => new(0, 0, SplitLeft, Height);

        Rectangle SplitRectangle => new(SplitLeft, 0, SplitWidth, Height);

        PropertyInfo _mouseIsDownProperty;

        PropertyInfo MouseIsDownProperty => _mouseIsDownProperty ??= typeof(ButtonBase).GetProperty("MouseIsDown", BindingFlags.NonPublic | BindingFlags.Instance);

        PropertyInfo _mouseIsOverProperty;

        PropertyInfo MouseIsOverProperty => _mouseIsOverProperty ??= typeof(ButtonBase).GetProperty("MouseIsOver", BindingFlags.NonPublic | BindingFlags.Instance);

        MethodInfo _createTextFormatFlagsMethod;

        MethodInfo CreateTextFormatFlagsMethod => _createTextFormatFlagsMethod ??= typeof(ControlPaint).GetMethod("CreateTextFormatFlags", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(Control), typeof(System.Drawing.ContentAlignment), typeof(bool), typeof(bool) }, null);

        PropertyInfo _showToolTipProperty;

        PropertyInfo ShowToolTipProperty => _showToolTipProperty ??= typeof(ButtonBase).GetProperty("ShowToolTip", BindingFlags.NonPublic | BindingFlags.Instance);

        MethodInfo _paintBackgroundMethod;

        MethodInfo PaintBackgroundMethod => _paintBackgroundMethod ??= typeof(Control).GetMethod("PaintBackground", BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(PaintEventArgs), typeof(Rectangle) }, null);

        protected bool MouseIsDown => (bool)MouseIsDownProperty.GetValue(this, null);

        protected bool MouseIsOver => (bool)MouseIsOverProperty.GetValue(this, null);

        public SplitButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            FlatStyle = FlatStyle.Standard;
        }

        protected virtual void OnSplitClick(EventArgs e)
        {
            if (ClickSplit is { } handler)
            {
                handler(this, e);
            }
            else if (SplitDropDownMenu is { } menu)
            {
                menu.Show(this, new(0, Height));
            }
            else if (SplitDropDownMenuStrip is { } menuStrip)
            {
                menuStrip.Show(this, new(0, Height));
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                _inPrimary = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (e is MouseEventArgs me && me.X >= SplitLeft)
            {
                OnSplitClick(e);
                return;
            }

            base.OnClick(e);
        }

        int _lastX;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            var _splitLeft = SplitLeft;
            _inPrimary = e.X < _splitLeft;

            if (_lastX < _splitLeft && e.X >= _splitLeft
                || _lastX >= _splitLeft && e.X < _splitLeft)
            {
                Invalidate();
            }

            _lastX = e.X;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Debug.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: paint");
            var withStyle = Application.RenderWithVisualStyles;

            var g = e.Graphics;
            g.Clear(BackColor);

            var orgClip = e.ClipRectangle;

            //primary
            var primaryState = DetermineState(true);
            g.ExcludeClip(SplitRectangle);
            if (withStyle)
            {
                ButtonRenderer.DrawButton(g, ClientRectangle, primaryState);
            }
            else
            {
                DrawClassicalButton(primaryState);
            }

            //text
            var pr = PrimaryRectangle;
            pr.Inflate(-4, -4);
            if (!withStyle && primaryState == PushButtonState.Pressed)
                pr.Offset(1, 1);
            var textFlags = (TextFormatFlags)CreateTextFormatFlagsMethod.Invoke(null, new object[] { this, TextAlign, (bool)ShowToolTipProperty.GetValue(this, null), UseMnemonic });
            if (!withStyle && !Enabled)
            {
                //disable-style highlight layer
                pr.Offset(1, 1);
                TextRenderer.DrawText(g, Text, Font, pr, SystemColors.ButtonHighlight, textFlags);
                pr.Offset(-1, -1);
            }

            TextRenderer.DrawText(g, Text, Font, pr, Enabled ? ForeColor : SystemColors.ButtonShadow, textFlags);

            //split
            g.SetClip(orgClip);
            g.ExcludeClip(PrimaryRectangle);
            var splitState = DetermineState(false);
            if (withStyle)
            {
                ButtonRenderer.DrawButton(g, ClientRectangle, splitState);
            }
            else
            {
                DrawClassicalButton(splitState);
            }

            //separator
            if (!withStyle && !Enabled)
            {
                //disable-style highlight layer
                var splitRect = SplitRectangle;
                splitRect.Offset(1, 1);
                g.DrawLine(SystemPens.ButtonHighlight, splitRect.Left, 5, splitRect.Left, Height - 4);
            }

            g.DrawLine(SystemPens.ButtonShadow, SplitRectangle.Left, 4, SplitRectangle.Left, Height - 4 - 1);

            //arrow
            var x = SplitRectangle.Left + SplitRectangle.Width / 2 - 4;
            var y = Height / 2 - 1;
            if (!withStyle)
            {
                if (splitState == PushButtonState.Pressed || !Enabled)
                {
                    x++;
                    y++;
                }

                if (!Enabled)
                {
                    var shodowPoints = new[]
                    {
                        new Point(x, y), //left-top
                        new Point(x + 7, y), //right-top
                        new Point(x + 3, y + 4), //bottom
                    };
                    g.FillPolygon(SystemBrushes.ButtonHighlight, shodowPoints);
                    x--;
                    y--;
                }
            }

            var points = new[]
            {
                new Point(x, y), //left-top
                new Point(x + 7, y), //right-top
                new Point(x + 3, y + 4), //bottom
            };
            g.FillPolygon(Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow, points);

            //focus cues
            if (Focused && ShowFocusCues)
            {
                g.SetClip(orgClip);
                var rect = ClientRectangle;
                if (withStyle)
                    rect.Inflate(-3, -3);
                else
                    rect.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(g, rect);
            }

            void DrawClassicalButton(PushButtonState state)
            {
                var rect = ClientRectangle;
                PaintBackgroundMethod.Invoke(this, new object[] { e, rect });
                if (IsDefault)
                {
                    //draw default edge
                    g.DrawRectangle(SystemPens.ControlText, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

                    //deflate content
                    rect.Inflate(-1, -1);
                }

                if (state == PushButtonState.Pressed)
                {
                    ControlPaint.DrawBorder(g, rect, SystemColors.ButtonShadow, ButtonBorderStyle.Solid);
                }
                else
                {
                    var p1 = new Point(rect.X + rect.Width - 1, rect.Y); // upper inner right.
                    var p2 = new Point(rect.X, rect.Y); // upper left.
                    var p3 = new Point(rect.X, rect.Y + rect.Height - 1); // bottom inner left.
                    var p4 = new Point(rect.X + rect.Width - 1, rect.Y + rect.Height - 1); // inner bottom right.

                    g.DrawLine(SystemPens.ButtonHighlight, p1, p2); // top (right-left)
                    g.DrawLine(SystemPens.ButtonHighlight, p2, p3); // left(up-down)

                    p1.Offset(0, -1);
                    g.DrawLine(SystemPens.ControlDarkDark, p3, p4);
                    g.DrawLine(SystemPens.ControlDarkDark, p4, p1);

                    // Draw inset - use the back ground color here to have a thinner border 
                    p1.Offset(-1, 2);
                    p2.Offset(1, 1);
                    p3.Offset(1, -1);
                    p4.Offset(-1, -1);

                    // top + left inset
                    g.DrawLine(SystemPens.ButtonFace, p1, p2); //top (right-left)
                    g.DrawLine(SystemPens.ButtonFace, p2, p3); //left(up-down)

                    // Bottom + right inset
                    p1.Offset(0, -1);
                    g.DrawLine(SystemPens.ButtonShadow, p3, p4); // bottom(left-right)
                    g.DrawLine(SystemPens.ButtonShadow, p4, p1); // right (bottom-up)
                }
            }

            PushButtonState DetermineState(bool isPrimary)
            {
                if (!Enabled)
                {
                    return PushButtonState.Disabled;
                }

                if (_inPrimary == isPrimary)
                {
                    if (MouseIsDown)
                    {
                        return PushButtonState.Pressed;
                    }

                    if (MouseIsOver)
                    {
                        return PushButtonState.Hot;
                    }
                }

                return IsDefault ? PushButtonState.Default : PushButtonState.Normal;
            }
        }
    }
}