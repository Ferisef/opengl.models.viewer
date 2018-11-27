using System;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace opengl.models.viewer {
  public partial class ModelPickerForm : Form {
    private ModelData model;

    public ModelPickerForm() {
      InitializeComponent();
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    }

    private void choose3DModelButton_Click(object sender, EventArgs e) {
      if (choose3DModelDialog.ShowDialog() == DialogResult.OK) {
        string pathToFile = choose3DModelDialog.FileName;

        FileInfo fileInfo = new FileInfo(pathToFile);
        fileNameLabel.Text = $"File Name: {fileInfo.Name}";
        fileSizeLabel.Text = $"File Size: {Math.Round((float)fileInfo.Length / 1024, 2)}KBytes";

        model = OBJFileLoader.loadOBJ(pathToFile);
        verticesCountLabel.Text = $"Vertices: {model.getVertices().Length}";
        indicesCountLabel.Text = $"Indices: {model.getNormals().Length}";
        texCoordsCountLabel.Text = $"Texture Coords: {model.getTexCoords().Length}";
        normalsCountLabel.Text = $"Normals: {model.getNormals().Length}";
      }
    }

    private void view3DModelButton_Click(object sender, EventArgs e) {
      if (model == null) {
        MessageBox.Show("You must select a model.", "Error");
        return;
      }
      Hide();
      new MainForm(1280, 720, 60, fileNameLabel.Text, model);
      Show();
    }
  }
}
