namespace AgendaBeca
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGuardar = new Button();
            buttonCancelar = new Button();
            buttonEliminar = new Button();
            buttonNuevo = new Button();
            buttonModificar = new Button();
            dataGridViewDatos = new DataGridView();
            groupBoxContacto = new GroupBox();
            lblId = new Label();
            textBoxId = new TextBox();
            lblObservaciones = new Label();
            textBoxObservaciones = new TextBox();
            lblTelefono = new Label();
            textBoxTelefono = new TextBox();
            lblFechaNacimiento = new Label();
            dateTimePickerFechaNacimiento = new DateTimePicker();
            lblNombre = new Label();
            textBoxNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatos).BeginInit();
            groupBoxContacto.SuspendLayout();
            SuspendLayout();
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(556, 338);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(112, 34);
            buttonGuardar.TabIndex = 10;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(694, 338);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(112, 34);
            buttonCancelar.TabIndex = 11;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(216, 338);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(112, 34);
            buttonEliminar.TabIndex = 13;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonNuevo
            // 
            buttonNuevo.Location = new Point(78, 338);
            buttonNuevo.Name = "buttonNuevo";
            buttonNuevo.Size = new Size(112, 34);
            buttonNuevo.TabIndex = 12;
            buttonNuevo.Text = "Nuevo";
            buttonNuevo.UseVisualStyleBackColor = true;
            buttonNuevo.Click += buttonNuevo_Click;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(356, 338);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(112, 34);
            buttonModificar.TabIndex = 14;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // dataGridViewDatos
            // 
            dataGridViewDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDatos.ColumnHeadersVisible = false;
            dataGridViewDatos.Location = new Point(69, 391);
            dataGridViewDatos.Name = "dataGridViewDatos";
            dataGridViewDatos.RowHeadersWidth = 62;
            dataGridViewDatos.RowTemplate.Height = 33;
            dataGridViewDatos.Size = new Size(748, 198);
            dataGridViewDatos.TabIndex = 15;
            // 
            // groupBoxContacto
            // 
            groupBoxContacto.Controls.Add(lblId);
            groupBoxContacto.Controls.Add(textBoxId);
            groupBoxContacto.Controls.Add(lblObservaciones);
            groupBoxContacto.Controls.Add(textBoxObservaciones);
            groupBoxContacto.Controls.Add(lblTelefono);
            groupBoxContacto.Controls.Add(textBoxTelefono);
            groupBoxContacto.Controls.Add(lblFechaNacimiento);
            groupBoxContacto.Controls.Add(dateTimePickerFechaNacimiento);
            groupBoxContacto.Controls.Add(lblNombre);
            groupBoxContacto.Controls.Add(textBoxNombre);
            groupBoxContacto.Location = new Point(69, 36);
            groupBoxContacto.Name = "groupBoxContacto";
            groupBoxContacto.Size = new Size(737, 296);
            groupBoxContacto.TabIndex = 16;
            groupBoxContacto.TabStop = false;
            groupBoxContacto.Text = "Contacto:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(39, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(32, 25);
            lblId.TabIndex = 19;
            lblId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(223, 30);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(91, 31);
            textBoxId.ReadOnly = true;
            textBoxId.TabIndex = 18;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(39, 198);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(132, 25);
            lblObservaciones.TabIndex = 17;
            lblObservaciones.Text = "Observaciones:";
            // 
            // textBoxObservaciones
            // 
            textBoxObservaciones.Location = new Point(223, 198);
            textBoxObservaciones.Multiline = true;
            textBoxObservaciones.Name = "textBoxObservaciones";
            textBoxObservaciones.Size = new Size(438, 88);
            textBoxObservaciones.TabIndex = 16;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(39, 159);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(83, 25);
            lblTelefono.TabIndex = 15;
            lblTelefono.Text = "Teléfono:";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(223, 156);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(186, 31);
            textBoxTelefono.TabIndex = 14;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(39, 115);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(178, 25);
            lblFechaNacimiento.TabIndex = 13;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // dateTimePickerFechaNacimiento
            // 
            dateTimePickerFechaNacimiento.Location = new Point(223, 110);
            dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            dateTimePickerFechaNacimiento.Size = new Size(300, 31);
            dateTimePickerFechaNacimiento.TabIndex = 12;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(39, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(223, 67);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(272, 31);
            textBoxNombre.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 622);
            Controls.Add(groupBoxContacto);
            Controls.Add(dataGridViewDatos);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonNuevo);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonGuardar);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatos).EndInit();
            groupBoxContacto.ResumeLayout(false);
            groupBoxContacto.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonGuardar;
        private Button buttonCancelar;
        private Button buttonEliminar;
        private Button buttonNuevo;
        private Button buttonModificar;
        private DataGridView dataGridViewDatos;
        private GroupBox groupBoxContacto;
        private Label lblId;
        private TextBox textBoxId;
        private Label lblObservaciones;
        private TextBox textBoxObservaciones;
        private Label lblTelefono;
        private TextBox textBoxTelefono;
        private Label lblFechaNacimiento;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private Label lblNombre;
        private TextBox textBoxNombre;
    }
}
