using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RadioPlane
{
    class Button
    {
        public Vector2 Size;
        public Vector2 Position;
        public Rectangle rectangle;
        public Color colorOn;
        public Color colorOff;
        public Color CurrentColor;
        public Texture2D texture;
        public bool visible;
        public bool isClicked;
        public bool Enabled;
        public bool Checked;

        public Button()
        {
            colorOff = new Color(250, 250, 150, 100);
            colorOn = new Color(250, 250, 150, 200);
            CurrentColor = colorOff;
            isClicked = false;
            Enabled = true;
            Checked = false;
        }

        public void Init(Vector2 position, Texture2D textur, int w, int h)
        {
            Size = new Vector2(w, h);
            this.Position = position;
            this.rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            this.texture = textur;
            visible = true;
        }

        public void Set()
        {
            Checked = true;
        }

        public void unSet()
        {
            Checked = false;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, CurrentColor);
        }
    }
}
