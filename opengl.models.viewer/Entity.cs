using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  /// Entity.
  /// </summary>
  class Entity {
    private RawModel model;
    private Vector3 position;
    private float rx;
    private float ry;
    private float rz;
    private float scale;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="model">Raw model data.</param>
    /// <param name="position">Position.</param>
    /// <param name="rx">X-Axis rotation.</param>
    /// <param name="ry">Y-Axis rotation.</param>
    /// <param name="rz">Z-Axis rotation.</param>
    /// <param name="scale">Scale.</param>
    public Entity(RawModel model, Vector3 position, float rx, float ry, float rz, float scale) {
      this.model = model;
      this.position = position;
      this.rx = rx;
      this.ry = ry;
      this.rz = rz;
      this.scale = scale;
    }

    /// <summary>
    /// Increase position.
    /// </summary>
    /// <param name="value">Value.</param>
    public void increasePosition(Vector3 value) {
      position += value;
    }

    /// <summary>
    /// Increase rotation.
    /// </summary>
    /// <param name="x">X-Axis rotation.</param>
    /// <param name="y">Y-Axis rotation.</param>
    /// <param name="z">Z-Axis rotation.</param>
    public void increaseRotation(float x, float y, float z) {
      rx += x;
      ry += y;
      rz += z;
    }

    public RawModel getModel() => model;

    public Vector3 getPosition() => position;

    public float getRX() => rx;

    public float getRY() => ry;

    public float getRZ() => rz;

    public void setScale(float scale) {
      this.scale = scale;
    }

    public float getScale() => scale;
  }
}
