namespace DABWinForms
{
    partial class CheqeuAdmin
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dABDataSet = new DABWinForms.DABDataSet();
            this.chequeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chequeTableAdapter = new DABWinForms.DABDataSetTableAdapters.chequeTableAdapter();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dABDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 81);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroDataGridViewTextBoxColumn,
            this.banqueDataGridViewTextBoxColumn,
            this.montantDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.chequeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(784, 425);
            this.dataGridView1.TabIndex = 1;
            // 
            // dABDataSet
            // 
            this.dABDataSet.DataSetName = "DABDataSet";
            this.dABDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chequeBindingSource
            // 
            this.chequeBindingSource.DataMember = "cheque";
            this.chequeBindingSource.DataSource = this.dABDataSet;
            // 
            // chequeTableAdapter
            // 
            this.chequeTableAdapter.ClearBeforeFill = true;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // banqueDataGridViewTextBoxColumn
            // 
            this.banqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.banqueDataGridViewTextBoxColumn.DataPropertyName = "banque";
            this.banqueDataGridViewTextBoxColumn.HeaderText = "banque";
            this.banqueDataGridViewTextBoxColumn.Name = "banqueDataGridViewTextBoxColumn";
            this.banqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montantDataGridViewTextBoxColumn
            // 
            this.montantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.montantDataGridViewTextBoxColumn.DataPropertyName = "montant";
            this.montantDataGridViewTextBoxColumn.HeaderText = "montant";
            this.montantDataGridViewTextBoxColumn.Name = "montantDataGridViewTextBoxColumn";
            this.montantDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CheqeuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 506);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheqeuAdmin";
            this.Text = "CheqeuAdmin";
            this.Load += new System.EventHandler(this.CheqeuAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dABDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DABDataSet dABDataSet;
        private System.Windows.Forms.BindingSource chequeBindingSource;
        private DABDataSetTableAdapters.chequeTableAdapter chequeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn banqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montantDataGridViewTextBoxColumn;
    }
}