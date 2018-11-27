using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;

namespace opengl.models.viewer {
  /// <summary>
  /// Render engine.
  /// </summary>
  class RenderEngine {
    private static Loader loader;
    private static StaticShader shader;
    private static Entity entity;
    private static Camera camera;
    private static Light light;

    private static char axis = ' ';
    private static bool preview = true;

    /// <summary>
    /// Preparing.
    /// </summary>
    /// <param name="modelData">Model data.</param>
    public static void prepare(ModelData modelData) {
      loader = new Loader();
      shader = new StaticShader();
      camera = new Camera();

      RawModel model = loader.loadToVAO(modelData.getVertices(), modelData.getNormals(), modelData.getIndices());
      entity = new Entity(model, new Vector3(0, -5.0f, -50.0f), 0, 0, 0, 1.0f);
      light = new Light(new Vector3(0, 0, -20.0f), new Vector3(1.0f, 1.0f, 1.0f));
    }

    /// <summary>
    /// Main render method.
    /// </summary>
    /// <param name="width">Window width.</param>
    /// <param name="height">Window height.</param>
    public static void render(int width, int height) {
      KeyboardState keyboard = Keyboard.GetState();
      camera.move(keyboard);

      if (preview && axis == ' ') entity.increaseRotation(0, 0.02f, 0);

      if (keyboard.IsKeyDown(Key.X)) axis = 'x';
      if (keyboard.IsKeyDown(Key.Y)) axis = 'y';
      if (keyboard.IsKeyDown(Key.Z)) axis = 'z';
      if (keyboard.IsKeyDown(Key.Space)) preview = !preview;
      if (keyboard.IsKeyDown(Key.Plus)) {
        switch (axis) {
          case 'x':
            entity.increaseRotation(0.02f, 0, 0);
            break;
          case 'y':
            entity.increaseRotation(0, 0.02f, 0);
            break;
          case 'z':
            entity.increaseRotation(0, 0, 0.02f);
            break;
        }
      }
      if (keyboard.IsKeyDown(Key.Minus)) {
        switch (axis) {
          case 'x':
            entity.increaseRotation(-0.02f, 0, 0);
            break;
          case 'y':
            entity.increaseRotation(0, -0.02f, 0);
            break;
          case 'z':
            entity.increaseRotation(0, 0, -0.02f);
            break;
        }
      }

      // visualisation
      GL.Enable(EnableCap.DepthTest);
      GL.ClearColor(0.33f, 0.33f, 0.33f, 1.0f);
      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

      Matrix4 transformationMatrix = Maths.createTransformationMatrix(entity.getPosition(), entity.getRX(), entity.getRY(), entity.getRZ(), entity.getScale());
      Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, width / (float)height, 0.1f, 1000.0f);

      shader.start();
      shader.loadLight(light);
      shader.loadTransformationMatrix(transformationMatrix);
      shader.loadProjectionMatrix(projectionMatrix);
      shader.loadViewMatrix(camera);

      GL.BindVertexArray(entity.getModel().getVaoID());
      GL.EnableVertexAttribArray(0);
      GL.EnableVertexAttribArray(1);
      GL.DrawElements(BeginMode.Triangles, entity.getModel().getVertexCount(), DrawElementsType.UnsignedInt, 0);
      GL.DisableVertexAttribArray(0);
      GL.DisableVertexAttribArray(1);
      GL.BindVertexArray(0);

      shader.stop();
    }

    /// <summary>
    /// Free memory.
    /// </summary>
    public static void cleanUp() {
      loader.cleanUp();
      shader.cleanUp();
    }
  }
}
