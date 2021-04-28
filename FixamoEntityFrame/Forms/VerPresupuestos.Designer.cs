namespace FixamoEntityFrame.Forms
{
    partial class VerPresupuestos
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.nroPresup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.busqNro = new System.Windows.Forms.CheckBox();
            this.busqFecha = new System.Windows.Forms.CheckBox();
            this.fechaPresup = new System.Windows.Forms.DateTimePicker();
            this.busqTodos = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Presupuestos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 168);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 495);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1098, 168);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 88);
            this.button1.TabIndex = 5;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nroPresup
            // 
            this.nroPresup.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nroPresup.Location = new System.Drawing.Point(676, 56);
            this.nroPresup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nroPresup.Name = "nroPresup";
            this.nroPresup.Size = new System.Drawing.Size(159, 25);
            this.nroPresup.TabIndex = 1;
            this.nroPresup.TextChanged += new System.EventHandler(this.nroPresup_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(420, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Buscar por:";
            // 
            // busqNro
            // 
            this.busqNro.AutoSize = true;
            this.busqNro.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqNro.Location = new System.Drawing.Point(516, 59);
            this.busqNro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busqNro.Name = "busqNro";
            this.busqNro.Size = new System.Drawing.Size(146, 24);
            this.busqNro.TabIndex = 0;
            this.busqNro.Text = "Nro. Presupuesto:";
            this.busqNro.UseVisualStyleBackColor = true;
            this.busqNro.CheckedChanged += new System.EventHandler(this.busqNro_CheckedChanged);
            // 
            // busqFecha
            // 
            this.busqFecha.AutoSize = true;
            this.busqFecha.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqFecha.Location = new System.Drawing.Point(516, 92);
            this.busqFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busqFecha.Name = "busqFecha";
            this.busqFecha.Size = new System.Drawing.Size(74, 24);
            this.busqFecha.TabIndex = 2;
            this.busqFecha.Text = "Fecha:";
            this.busqFecha.UseVisualStyleBackColor = true;
            this.busqFecha.CheckedChanged += new System.EventHandler(this.busqFecha_CheckedChanged);
            // 
            // fechaPresup
            // 
            this.fechaPresup.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaPresup.Location = new System.Drawing.Point(595, 91);
            this.fechaPresup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fechaPresup.Name = "fechaPresup";
            this.fechaPresup.Size = new System.Drawing.Size(200, 25);
            this.fechaPresup.TabIndex = 3;
            this.fechaPresup.ValueChanged += new System.EventHandler(this.fechaPresup_ValueChanged);
            // 
            // busqTodos
            // 
            this.busqTodos.AutoSize = true;
            this.busqTodos.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqTodos.Location = new System.Drawing.Point(516, 126);
            this.busqTodos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.busqTodos.Name = "busqTodos";
            this.busqTodos.Size = new System.Drawing.Size(184, 24);
            this.busqTodos.TabIndex = 4;
            this.busqTodos.Text = "Todos los Presupuestos";
            this.busqTodos.UseVisualStyleBackColor = true;
            this.busqTodos.CheckedChanged += new System.EventHandler(this.busqTodos_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1098, 264);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 88);
            this.button2.TabIndex = 6;
            this.button2.Text = "Eliminar Presupuesto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // VerPresupuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 701);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.busqTodos);
            this.Controls.Add(this.fechaPresup);
            this.Controls.Add(this.busqFecha);
            this.Controls.Add(this.busqNro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nroPresup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VerPresupuestos";
            this.Text = "VerPresupuestos";
            this.Load += new System.EventHandler(this.VerPresupuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nroPresup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox busqNro;
        private System.Windows.Forms.CheckBox busqFecha;
        private System.Windows.Forms.DateTimePicker fechaPresup;
        private System.Windows.Forms.CheckBox busqTodos;
        private System.Windows.Forms.Button button2;
    }
}