using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NetworkGame
{
    using Lidgren.Network;
    using System;
    using System.Collections.Generic;

    class NetEntity
    {
        static int _uuid;

        public int uuid;
        
        public NetEntity(NetPeer netClient)
        {
            _uuid += 1;
            uuid = _uuid;

            this.NetClient = netClient;
        }

        public Vector2 pos;

        public NetPeer NetClient { get; set; }
    }

    class GameServer
    {
        /// <summary>
        /// A list that holds NetEntitys.
        /// </summary>
        public List<NetEntity> NetEntities { get; set; } = new List<NetEntity>();

        public bool Running { get; private set; }

        public NetServer NetServer { get; set; }
        public NetPeerConfiguration Config { get; set; }

        public void StartServer()
        {
            this.Config = new NetPeerConfiguration("game")
            {
                Port = 12345
            };

            var server = new NetServer(Config);
            this.NetServer = server;

            server.Start();
            Console.WriteLine("Server starting up... binding to socket...");

            Running = false;
            while (Running == false)
            {
                if (server.Status == NetPeerStatus.Running)
                {
                    Running = true;
                    Console.WriteLine("Server is up and running.");
                }
            }
        }

        /// <summary>
        /// In Update we listen to messages.
        /// </summary>
        public void Update()
        {
            for(int i = 0; i < NetServer.Connections.Count; ++i)
            {
                var con = NetServer.Connections[i];
                var peer = con.Peer;

                NetIncomingMessage message;
                while ((message = peer.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        // Handle custom messages
                        case NetIncomingMessageType.Data:

                            var netbuffer = message.ReadString();

                            //var data = message.ReadAllProperties(this.NetEntities[i]);

                            // Something like this might be neccessary? Note: Does not work.
                            //if(message.SenderConnection.RemoteUniqueIdentifier == NetEntities[i].NetClient.UniqueIdentifier)
                            //{
                            //}

                            Console.WriteLine(string.Format("Custom data from uuid:{0}, buffer:{1}", NetEntities[i].uuid, netbuffer));

                            if(netbuffer.StartsWith("move:"))
                            {
                                if(netbuffer.Equals("move:up"))
                                {
                                    NetEntities[i].pos.Y -= 1;
                                }
                                else if (netbuffer.Equals("move:down"))
                                {
                                    NetEntities[i].pos.Y += 1;
                                }
                                else if (netbuffer.Equals("move:left"))
                                {
                                    NetEntities[i].pos.X -= 1;
                                }
                                else if (netbuffer.Equals("move:right"))
                                {
                                    NetEntities[i].pos.X += 1;
                                }
                            }

                            break;

                        // Handle connection status messages
                        case NetIncomingMessageType.StatusChanged:

                            switch (message.SenderConnection.Status)
                            {
                                /* .. */
                                case NetConnectionStatus.Connected:
                                {
                                    Console.WriteLine("NetConnectionStatus Connected");
                                    NetEntities.Add(new NetEntity(message.SenderConnection.Peer));
                                    break;
                                }


                                case NetConnectionStatus.Disconnected:
                                {
                                    Console.WriteLine("NetConnectionStatus Disconnected");

                                    break;
                                }
                            }
                            break;

                        // Handle debug messages (only received when compiled in DEBUG mode)
                        case NetIncomingMessageType.DebugMessage:
                            Console.WriteLine(message.ReadString());
                            break;

                        // Unknown
                        default:
                            Console.WriteLine("Unhandled message with type: " + message.MessageType);
                            break;
                    }
                }
            }



            

        }
    }

    class GameClient
    {
        public bool Connected { get; private set; }
        public NetClient NetClient { get; set; }
        public NetPeerConfiguration Config { get; set; }

        // Connection connected to.
        public NetConnection NetConnection { get; set; }


        /// <summary>
        /// In Update we listen to messages.
        /// </summary>
        public void Update()
        {
            var msg = NetClient.WaitMessage(1); // Not sure why we need maxmillis

            if (msg != null)
            {

                Console.WriteLine("Received message from server.");
            }
        }


        public void ConnectToServer(string ip)
        {
            this.Config = new NetPeerConfiguration("game");
            this.NetClient = new NetClient(Config);

            NetClient.Start();

            Console.WriteLine("Client started.");

            this.NetConnection = NetClient.Connect(host: ip, port: 12345);

            Connected = false;
            int i = 0;

            while (Connected == false)
            {
                Console.WriteLine("Connecting to server... waiting for server packet (" + i.ToString() + " iterations).");
                i += 1;

                // Wait for the server message
                var msg = NetClient.WaitMessage(100); // Not sure why we need maxmillis

                if (NetClient.ConnectionStatus == NetConnectionStatus.Connected)
                {
                    Console.WriteLine("Client connected to server.");
                    Connected = true;
                }
            }

        }
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameServer server;
        GameClient client;


        Camera2DControlled camera;

        SpriteFont font;
        Texture2D tex;
        Rectangle sprite;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        protected override void Initialize()
        {
            server = new GameServer();
            client = new GameClient();

            server.StartServer();

            client.ConnectToServer("127.0.0.1");




            camera = new Camera2DControlled();
            camera.Zoom = 1f;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            font = Content.Load<SpriteFont>("font");
            tex = Content.Load<Texture2D>("girl");
            sprite = new Rectangle(0, 0, 16, 22);
        }


        protected override void UnloadContent()
        {
        }


        KeyboardState ks;
        bool camera_set;

        protected override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape))
                Exit();


            client.Update();
            server.Update();

            if (ks.IsKeyDown(Keys.W))
            {
                var msg = client.NetClient.CreateMessage();
                msg.Write("move:up");
                client.NetClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            }
            else if (ks.IsKeyDown(Keys.A))
            {
                var msg = client.NetClient.CreateMessage();
                msg.Write("move:left");
                client.NetClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            }
            else if (ks.IsKeyDown(Keys.S))
            {
                var msg = client.NetClient.CreateMessage();
                msg.Write("move:down");
                client.NetClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            }
            else if (ks.IsKeyDown(Keys.D))
            {
                var msg = client.NetClient.CreateMessage();
                msg.Write("move:right");
                client.NetClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            }

            camera.UpdateControls((float)gameTime.ElapsedGameTime.TotalSeconds);

            if(!camera_set)
            {
                if (server != null)
                {
                    if (server.NetEntities != null && server.NetEntities.Count != 0)
                    {
                        Vector2 pos = new Vector2(
                            server.NetEntities[0].pos.X + (GraphicsDevice.Viewport.Width) * 0.5f,
                            server.NetEntities[0].pos.Y + (GraphicsDevice.Viewport.Height) * 0.5f);

                        camera.Position = pos;

                        camera_set = true;
                    }
                }
            }


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            //spriteBatch.Draw(tex_background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            //spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, camera.GetTransformation(this.GraphicsDevice));
            // TODO: Add your drawing code here

            foreach (NetEntity e in server.NetEntities)
            {
                spriteBatch.Draw(tex, e.pos, sprite, Color.White);

                spriteBatch.DrawString(font, e.uuid.ToString(), e.pos - Vector2.One * 8, Color.Yellow);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
