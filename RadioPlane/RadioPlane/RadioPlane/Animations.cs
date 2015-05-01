using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RadioPlane
{
    class Animations
    {
        public Texture2D texture;
        public Rectangle sourceRect = new Rectangle();
        public Color color;
        public Vector2 Position;
        public Vector2 spriteOrigin;
        public Color[] colorData;

        public float rotation;

        public int elapsedTime;
        public int frameTime;
        public int frameCount;
        public int currentFrame;
        public int lineFrame;
        public int FrameWidth;
        public int FrameHeight;
        public float scale;
        public bool Active;
        public bool Looping;
        

        public void Initialize(Texture2D textur, Vector2 position, int frameWidth, int frameHeight,
                                int frameCount, int frametime, Color color, float scale, bool looping, int lframe)
        {
            Position = position;
            texture = textur;
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;
            this.lineFrame = lframe;
            Looping = looping;

            elapsedTime = 0;
            currentFrame = 0;

            Active = true;

            this.colorData = new Color[texture.Width * texture.Height];
            textur.GetData<Color>(colorData);
        }

        public void Update(GameTime gameTime, float rot)
        {
            if (this.Active == false) return;


            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds; 

            if (elapsedTime > frameTime)
            {
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (Looping == false)
                    {
                        Active = false;
                    }
                }
                elapsedTime = 0;
            }
            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
            spriteOrigin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);            
            this.rotation = rot;                                                                
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(texture, Position, sourceRect, Color.White, rotation, spriteOrigin, scale, SpriteEffects.None, 0);  
            }
        }

    }
}
