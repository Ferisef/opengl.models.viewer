using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  /// Light.
  /// </summary>
  class Light {
    private Vector3 position;
    private Vector3 color;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="position">Light position.</param>
    /// <param name="color">Light color.</param>
    public Light(Vector3 position, Vector3 color) {
      this.position = position;
      this.color = color;
    }

    public void setPosition(Vector3 position) {
      this.position = position;
    }

    public Vector3 getPosition() => position;

    public void setColor(Vector3 color) {
      this.color = color;
    }

    public Vector3 getColor() => color;
  }
}
