using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monoxhunder;

public class GameMain : Game
{
    public static GameMain Instance => instance;
    public GraphicsDeviceManager Graphics => graphics;
    private Scene currentScene = null;

    private static GameMain instance;
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Scene CurrentScene => currentScene;

    public GameMain(Scene startScene, string title, int width, int height, bool fullscreen)
    {
        instance = this;

        graphics = new(this)
        {
            PreferredBackBufferWidth = width,
            PreferredBackBufferHeight = height,
            IsFullScreen = fullscreen
        };
        graphics.ApplyChanges();
        Window.Title = title;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        currentScene = startScene;
    }

    /// <summary>
    /// Swaps currentScene for newScene. Disposes of old Scene.
    /// </summary>
    /// <param name="newScene">New currentScene</param>
    public void SwapScene(Scene newScene)
    {
        if (currentScene != null)
        {
            currentScene.Dispose();
        }
        currentScene = newScene;
        currentScene.Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        currentScene.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        currentScene.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        currentScene.Draw(gameTime, spriteBatch);
    }

}
