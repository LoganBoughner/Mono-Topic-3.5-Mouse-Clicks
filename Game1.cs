using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mono_Topic_3._5_Mouse_Clicks
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D quitTexture;
        Rectangle quitRect;
        MouseState mouseState;
        MouseState prevMouseState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            quitRect = new Rectangle(10, 10, 200, 80);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            quitTexture = Content.Load<Texture2D>("QuitButton");
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            
            if (mouseState.LeftButton == ButtonState.Pressed &&
prevMouseState.LeftButton == ButtonState.Released)
            {
                if (quitRect.Contains(mouseState.Position))
                    Exit();

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(quitTexture, quitRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
