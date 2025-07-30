using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoxhunder
{
    public abstract class Scene : IDisposable
    {
        public virtual void Initialize()
        {

        }

        public virtual void Update(GameTime delta)
        {

        }

        public virtual void Draw(GameTime delta, SpriteBatch spriteBatch)
        {

        }

        public void Dispose()
        {
            Unload();
        }
        
        public virtual void Unload(){}
    }
}