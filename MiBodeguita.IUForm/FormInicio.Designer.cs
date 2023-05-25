
namespace MiBodeguita.IUForm
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRegistras = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oTROSToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oTROSToolStripMenuItem
            // 
            this.oTROSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrartoolStripMenuItem,
            this.mostrarToolStripMenuItem});
            this.oTROSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oTROSToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.oTROSToolStripMenuItem.Image = global::MiBodeguita.IUForm.Properties.Resources.compras;
            this.oTROSToolStripMenuItem.Name = "oTROSToolStripMenuItem";
            this.oTROSToolStripMenuItem.Size = new System.Drawing.Size(125, 29);
            this.oTROSToolStripMenuItem.Text = "Productos";
            // 
            // registrartoolStripMenuItem
            // 
            this.registrartoolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.registrartoolStripMenuItem.Name = "registrartoolStripMenuItem";
            this.registrartoolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.registrartoolStripMenuItem.Text = "Registrar";
            this.registrartoolStripMenuItem.Click += new System.EventHandler(this.registrartoolStripMenuItem_Click);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRegistras,
            this.toolStripMenuItemMostrar});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripMenuItem1.Image = global::MiBodeguita.IUForm.Properties.Resources.producto;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 29);
            this.toolStripMenuItem1.Text = "Compras";
            // 
            // toolStripMenuItemRegistras
            // 
            this.toolStripMenuItemRegistras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripMenuItemRegistras.Name = "toolStripMenuItemRegistras";
            this.toolStripMenuItemRegistras.Size = new System.Drawing.Size(180, 30);
            this.toolStripMenuItemRegistras.Text = "Registrar";
            this.toolStripMenuItemRegistras.Click += new System.EventHandler(this.toolStripMenuItemRegistras_Click);
            // 
            // toolStripMenuItemMostrar
            // 
            this.toolStripMenuItemMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripMenuItemMostrar.Name = "toolStripMenuItemMostrar";
            this.toolStripMenuItemMostrar.Size = new System.Drawing.Size(180, 30);
            this.toolStripMenuItemMostrar.Text = "Mostrar";
            this.toolStripMenuItemMostrar.Click += new System.EventHandler(this.toolStripMenuItemMostrar_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 601);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mi Bodeguita";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegistras;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMostrar;
    }
}

