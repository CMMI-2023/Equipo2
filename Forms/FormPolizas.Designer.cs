
namespace Seguros_Irapuato.Forms
{
    partial class FormPolizas
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.lblH = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDA = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtNaccidentes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeach = new FontAwesome.Sharp.IconButton();
            this.btnhist = new FontAwesome.Sharp.IconButton();
            this.btnback = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(70, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 63;
            this.label5.Text = "Estado del auto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(70, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Tasa fija";
            // 
            // txtTasa
            // 
            this.txtTasa.Enabled = false;
            this.txtTasa.Location = new System.Drawing.Point(70, 242);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(125, 27);
            this.txtTasa.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(70, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Total";
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculos.Location = new System.Drawing.Point(407, 108);
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.RowHeadersWidth = 51;
            this.dgvVehiculos.RowTemplate.Height = 29;
            this.dgvVehiculos.Size = new System.Drawing.Size(282, 264);
            this.dgvVehiculos.TabIndex = 58;
            this.dgvVehiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehiculos_CellClick);
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblH.Location = new System.Drawing.Point(407, 75);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(54, 20);
            this.lblH.TabIndex = 57;
            this.lblH.Text = "Polizas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(70, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "ID Auto";
            // 
            // txtIDA
            // 
            this.txtIDA.Location = new System.Drawing.Point(70, 88);
            this.txtIDA.Name = "txtIDA";
            this.txtIDA.Size = new System.Drawing.Size(125, 27);
            this.txtIDA.TabIndex = 54;
            this.txtIDA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDA_KeyPress);
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(70, 167);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(125, 27);
            this.txtEstado.TabIndex = 64;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(70, 327);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(125, 27);
            this.txtTotal.TabIndex = 65;
            // 
            // txtNaccidentes
            // 
            this.txtNaccidentes.Enabled = false;
            this.txtNaccidentes.Location = new System.Drawing.Point(232, 167);
            this.txtNaccidentes.Name = "txtNaccidentes";
            this.txtNaccidentes.Size = new System.Drawing.Size(125, 27);
            this.txtNaccidentes.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(213, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Numero de accidentes";
            // 
            // btnSeach
            // 
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnSeach.FlatAppearance.BorderSize = 0;
            this.btnSeach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeach.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSeach.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSeach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeach.IconSize = 40;
            this.btnSeach.Location = new System.Drawing.Point(738, 327);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(46, 46);
            this.btnSeach.TabIndex = 68;
            this.btnSeach.UseVisualStyleBackColor = false;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // btnhist
            // 
            this.btnhist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnhist.FlatAppearance.BorderSize = 0;
            this.btnhist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhist.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnhist.IconColor = System.Drawing.Color.Gainsboro;
            this.btnhist.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhist.IconSize = 40;
            this.btnhist.Location = new System.Drawing.Point(738, 108);
            this.btnhist.Name = "btnhist";
            this.btnhist.Size = new System.Drawing.Size(46, 46);
            this.btnhist.TabIndex = 69;
            this.btnhist.UseVisualStyleBackColor = false;
            this.btnhist.Click += new System.EventHandler(this.btnhist_Click);
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.IconChar = FontAwesome.Sharp.IconChar.RotateBackward;
            this.btnback.IconColor = System.Drawing.Color.Gainsboro;
            this.btnback.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnback.IconSize = 40;
            this.btnback.Location = new System.Drawing.Point(738, 219);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(46, 46);
            this.btnback.TabIndex = 71;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // FormPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(829, 404);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnhist);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.txtNaccidentes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvVehiculos);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDA);
            this.Name = "FormPolizas";
            this.Text = "Polizas";
            this.Load += new System.EventHandler(this.FormPolizas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvVehiculos;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDA;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtNaccidentes;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnSeach;
        private FontAwesome.Sharp.IconButton btnhist;
        private FontAwesome.Sharp.IconButton btnback;
    }
}