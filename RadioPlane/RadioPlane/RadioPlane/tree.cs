using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RadioPlane
{
    class tree
    {
        public Animations EnemyAnimation;
        public Vector2 Position;
        public bool Active;
        public Matrix transform;
        public int Width
        {
            get { return EnemyAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return EnemyAnimation.FrameHeight; }
        }

        public void Initialize(Animations animation, Vector2 position)
        {
            EnemyAnimation = animation;
            Position = position;
            Active = true;
            UpdateTransform();
        }

        public void Update(GameTime gameTime, float speed)
        {
            Position.X -= speed;
            EnemyAnimation.Position = Position;
            UpdateTransform();
            EnemyAnimation.Update(gameTime, 0f);
        }

        public void UpdateTransform()
        {
            this.transform = Matrix.CreateTranslation(new Vector3(-(this.EnemyAnimation.spriteOrigin), 0.0f)) *
                        Matrix.CreateScale(this.EnemyAnimation.scale) *
                        Matrix.CreateRotationZ(0f) *
                        Matrix.CreateTranslation(new Vector3(this.Position, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            EnemyAnimation.Draw(spriteBatch);
        }


    }
}
