namespace ProyectoFinal.UI.Reportes
{
    partial class ReporteCompraProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComprasProductosCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ComprasProductosCrystalReportViewer
            // 
            this.ComprasProductosCrystalReportViewer.ActiveViewIndex = -1;
            this.ComprasProductosCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComprasProductosCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComprasProductosCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComprasProductosCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ComprasProductosCrystalReportViewer.Name = "ComprasProductosCrystalReportViewer";
            this.ComprasProductosCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.ComprasProductosCrystalReportViewer.TabIndex = 0;
            // 
            // ReporteCompraProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComprasProductosCrystalReportViewer);
            this.Name = "ReporteCompraProductos";
            this.Text = "Reporte de compras de productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteCompraProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ComprasProductosCrystalReportViewer;
    }
}