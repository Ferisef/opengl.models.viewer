using OpenTK;
using OpenTK.Input;

namespace opengl.models.viewer {
  /// <summary>
  /// Camera.
  /// </summary>
  class Camera {
    private static readonly float STEP = 0.2f;

    private Vector3 position = new Vector3(0, 0, 0);
    private float pitch;
    private float yaw;
    private float roll;

    /// <summary>
    /// Constructor.
    /// </summary>
    public Camera() { }

    /// <summary>
    /// Camera move.
    /// </summary>
    /// <param name="keyboard">Keyboard.</param>
    public void move(KeyboardState keyboard) {
      if (keyboard.IsKeyDown(Key.W)) {
        position.Z -= STEP;
      }
      if (keyboard.IsKeyDown(Key.S)) {
        position.Z += STEP;
      }
      if (keyboard.IsKeyDown(Key.D)) {
        position.X += STEP;
      }
      if (keyboard.IsKeyDown(Key.A)) {
        position.X -= STEP;
      }
      if (keyboard.IsKeyDown(Key.Q)) {
        yaw += STEP;
      }
      if (keyboard.IsKeyDown(Key.E)) {
        yaw -= STEP;
      }
      if (keyboard.IsKeyDown(Key.ShiftLeft)) {
        pitch -= STEP;
      }
      if (keyboard.IsKeyDown(Key.ControlLeft)) {
        pitch += STEP;
      }
    }

    public Vector3 getPosition() => position;

    public float getPitch() => pitch;

    public float getYaw() => yaw;

    public float getRoll() => roll;
  }
}
