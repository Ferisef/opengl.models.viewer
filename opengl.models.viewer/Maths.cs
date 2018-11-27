using System;
using OpenTK;

namespace opengl.models.viewer {
  /// <summary>
  /// Contains methods of working with matrices and others.
  /// </summary>
  class Maths {
    /// <summary>
    /// Creating a transformation matrix.
    /// </summary>
    /// <param name="translation">Position.</param>
    /// <param name="rx">X-Axis angle.</param>
    /// <param name="ry">Y-Axis angle.</param>
    /// <param name="rz">Z-Axis angle.</param>
    /// <param name="scale">Scale.</param>
    /// <returns>Matrix.</returns>
    public static Matrix4 createTransformationMatrix(Vector3 translation, float rx, float ry, float rz, float scale) {
      Matrix4 matrix = Matrix4.Identity;
      matrix *= Matrix4.CreateRotationX(rx);
      matrix *= Matrix4.CreateRotationY(ry);
      matrix *= Matrix4.CreateRotationZ(rz);
      matrix *= Matrix4.CreateScale(scale);
      matrix *= Matrix4.CreateTranslation(translation);
      return matrix;
    }

    /// <summary>
    /// Creating a view matrix.
    /// </summary>
    /// <param name="camera">Camera.</param>
    /// <returns></returns>
    public static Matrix4 createVeiwMatrix(Camera camera) {
      Matrix4 matrix = Matrix4.Identity;
      matrix *= Matrix4.CreateRotationX(degToRad(camera.getPitch()));
      matrix *= Matrix4.CreateRotationY(degToRad(camera.getYaw()));
      Vector3 pos = camera.getPosition();
      Vector3 neg = new Vector3(-pos.X, -pos.Y, -pos.Z);
      matrix *= Matrix4.CreateTranslation(neg);
      return matrix;
    }

    /// <summary>
    /// Convert degrees to radians.
    /// </summary>
    /// <param name="angle">Angle in degrees.</param>
    /// <returns>Angle in radians.</returns>
    public static float degToRad(float angle) => (float)(Math.PI / 180) * angle;
  }
}
