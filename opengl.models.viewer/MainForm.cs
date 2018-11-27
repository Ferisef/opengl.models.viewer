using System;
using System.ComponentModel;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace opengl.models.viewer {
  /// <summary>
  /// Represents game window form.
  /// </summary>
  public class MainForm : GameWindow {
    public MainForm(int width, int height, int frameTime, string title, ModelData modelData)
        : base(width, height, GraphicsMode.Default, title) {
      RenderEngine.prepare(modelData);
      Run(1.0 / frameTime);
    }

    protected override void OnResize(EventArgs e) {
      base.OnResize(e);
      GL.Viewport(0, 0, Width, Height);
    }

    protected override void OnRenderFrame(FrameEventArgs e) {
      RenderEngine.render(Width, Height);
      SwapBuffers();
      base.OnRenderFrame(e);
    }

    protected override void OnClosing(CancelEventArgs e) {
      RenderEngine.cleanUp();
      base.OnClosing(e);
    }
  }
}
