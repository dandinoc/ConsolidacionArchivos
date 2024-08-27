<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        DataGridView1 = New DataGridView()
        Button1 = New Button()
        Button2 = New Button()
        TextBox1 = New TextBox()
        Button3 = New Button()
        ListBox1 = New ListBox()
        ListBox2 = New ListBox()
        PictureBox1 = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView1.ColumnHeadersHeight = 40
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 29
        DataGridView1.ScrollBars = ScrollBars.Vertical
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(475, 450)
        DataGridView1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(504, 25)
        Button1.Name = "Button1"
        Button1.Size = New Size(122, 41)
        Button1.TabIndex = 1
        Button1.Text = "CONTABILIZAR"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(504, 72)
        Button2.Name = "Button2"
        Button2.Size = New Size(122, 41)
        Button2.TabIndex = 2
        Button2.Text = "CONSOLIDAR"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Enabled = False
        TextBox1.Location = New Point(481, 157)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(273, 23)
        TextBox1.TabIndex = 3
        TextBox1.Visible = False
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(632, 72)
        Button3.Name = "Button3"
        Button3.Size = New Size(122, 41)
        Button3.TabIndex = 4
        Button3.Text = "ACTUALIZAR"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.Enabled = False
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(487, 254)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(120, 94)
        ListBox1.TabIndex = 5
        ListBox1.Visible = False
        ' 
        ' ListBox2
        ' 
        ListBox2.Enabled = False
        ListBox2.FormattingEnabled = True
        ListBox2.ItemHeight = 15
        ListBox2.Location = New Point(622, 254)
        ListBox2.Name = "ListBox2"
        ListBox2.Size = New Size(120, 94)
        ListBox2.TabIndex = 6
        ListBox2.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.cerrar_simbolo_de_boton_circular
        PictureBox1.Location = New Point(720, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(34, 38)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(760, 450)
        ControlBox = False
        Controls.Add(PictureBox1)
        Controls.Add(ListBox2)
        Controls.Add(ListBox1)
        Controls.Add(Button3)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form2"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "AVISOS DE MERCADERIA"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
