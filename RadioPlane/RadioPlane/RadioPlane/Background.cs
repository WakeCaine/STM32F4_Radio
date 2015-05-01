using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace RadioPlane
{
    class Background
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Rectangle destinationRect;
        public Vector2 Position;
        public float ObjectSpeed;

        public void Draw(SpriteBatch sprit)
        {
            sprit.Draw(texture, destinationRect, rectangle, Color.White);
        }

    }

    class Scrolling : Background
    {

        public Scrolling(Texture2D texture, Rectangle rect, Vector2 Pos, float s)
        {
            this.texture = texture;
            this.rectangle = rect;
            this.Position = Pos;
            this.ObjectSpeed = s;
        }

        public void Update(float speed)
        {
            destinationRect = new Rectangle((int)Position.X, (int)Position.Y, (int)(this.rectangle.Width), (int)(this.rectangle.Height));
            this.Position.X -= speed;
        }

    }

    class AllBackground
    {
        public List<Scrolling> Backgrounds;
        public ContentManager Content;
        public float playerSpeed;

        public AllBackground(ContentManager content, Plane player)
        {
            Backgrounds = new List<Scrolling>();
            this.Content = content;
            playerSpeed = player.speed;
            AddAll();
        }

        public void AddAll()
        {
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("miniclouds1"), new Rectangle(0, 0, 1000, 400), Vector2.Zero, 1.7f));
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("miniclouds2"), new Rectangle(0, 0, 1000, 400), new Vector2(1000, 0), 1.7f));
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("bigclouds1"), new Rectangle(0, 0, 1000, 400), Vector2.Zero, 3.4f));
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("bigclouds2"), new Rectangle(0, 0, 1000, 400), new Vector2(1000, 0), 3.4f));
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("bggrass2"), new Rectangle(0, 0, 1000, 200), new Vector2(0, 420), playerSpeed));
            Backgrounds.Add(new Scrolling(Content.Load<Texture2D>("bggrass2"), new Rectangle(0, 0, 1000, 200), new Vector2(1000, 420), playerSpeed));
        }

        public void UpdateAll()
        {
            for (int i = 0; i < Backgrounds.Count; i += 2)
            {
                if (Backgrounds[i].Position.X + Backgrounds[i].texture.Width <= 0)
                    Backgrounds[i].Position.X = Backgrounds[i+1].Position.X + Backgrounds[i+1].texture.Width;
                if (Backgrounds[i+1].Position.X + Backgrounds[i+1].texture.Width <= 0)
                    Backgrounds[i+1].Position.X = Backgrounds[i].Position.X + Backgrounds[i].texture.Width;
            }
        }

        public void AllDraw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Backgrounds.Count; i++)
            {
                Backgrounds[i].Draw(spriteBatch);
            }
        }
    }
}
