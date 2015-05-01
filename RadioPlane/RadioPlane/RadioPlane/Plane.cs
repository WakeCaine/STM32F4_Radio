using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RadioPlane
{
    class Plane
    {
        public Animations PlayerAnimation;
        public Vector2 Position;
        public bool Active;
        public float StaticSpeed;
        public float speed;
        public float rotation;
        public bool Alive;
        public Matrix transform;

        public int Width
        {
            get { return PlayerAnimation.FrameWidth; }
        }

        public int Height
        {
            get { return PlayerAnimation.FrameHeight; }
        }

        public void Initialize(Animations animation, Vector2 position)
        {
            this.PlayerAnimation = animation;
            this.Position = position;

            this.Active = true;

            this.Alive = true;

            this.StaticSpeed = 3f;
            this.speed = 3f;

            this.rotation = 0f;
            UpdateTransform();
        }


        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Update(gameTime, this.rotation);
            PlayerAnimation.Position = Position;
            UpdateTransform();
        }

        public void UpdateTransform()
        {
            this.transform = Matrix.CreateTranslation(new Vector3(-(this.PlayerAnimation.spriteOrigin), 0.0f)) *
                        Matrix.CreateScale(this.PlayerAnimation.scale) *
                        Matrix.CreateRotationZ(this.rotation) *
                        Matrix.CreateTranslation(new Vector3(this.Position, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);
        }

    }
}
