using System;
using System.ComponentModel;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace opengl.models.viewer {
  /// <summary>
  /// Game window form.
  /// </summary>
  public class MainForm : GameWindow {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="width">Width.</param>
    /// <param name="height">Height.</param>
    /// <param name="frameTime">FPS.</param>
    /// <param name="title">Title.</param>
    /// <param name="modelData">Model data.</param>
    public MainForm(int width, int height, int frameTime, string title, ModelData modelData)
        : base(width, height, GraphicsMode.Default, title) {
      RenderEngine.prepare(modelData);
      Run(1.0 / frameTime);
    }

    protected override void OnResize(EventArgs e) {
      GL.Viewport(0, 0, Width, Height);
    }

    protected override void OnRenderFrame(FrameEventArgs e) {
      RenderEngine.render(Width, Height);
      SwapBuffers();
    }

    protected override void OnClosing(CancelEventArgs e) {
      RenderEngine.cleanUp();
    }
  }
}
