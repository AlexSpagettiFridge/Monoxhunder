using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monoxhunder.GameLoop;

/// <summary>
/// Entrypoint <see cref="Game"/> that utilizes <see cref="Scene"/>.
/// </summary>
public class GameMain : Game
{
    public static GameMain Instance => instance;
    public GraphicsDeviceManager Graphics => graphics;
    public InputHandler InputHandler => inputHandler;
    private InputHandler inputHandler;
    private Scene currentScene = null;

    private static GameMain instance;
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Scene CurrentScene => currentScene;

    public GameMain(Scene startScene, string title, int width, int height, bool fullscreen)
    {
        instance = this;
        inputHandler = new InputHandler();
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
        inputHandler.Update(gameTime);
        currentScene.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        currentScene.Draw(gameTime, spriteBatch);
    }

}
