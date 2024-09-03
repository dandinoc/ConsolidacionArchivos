Imports System.IO
Imports System.Text.Json


Public Class Form2
    'ruta de origen de creacion de archivos
    Dim rutaArchivoOrigen As String = "\\10.130.65.147\ImportExport\LaColonia\SalidasAuto\" '"C:\Users\dandinoc\Documents\Nueva carpeta\" '
    'ruta de salida de cara a cliente
    Dim rutasalida As String = "\\10.130.65.147\ImportExport\LaColonia\Salidas\" '"C:\Users\dandinoc\Documents\Nueva carpeta\salida\" '
    'ruta de salida de archivo consolidado de cara a cliente
    Dim rutaconsolidad As String = rutasalida '"C:\Users\dandinoc\Documents\Nueva carpeta\salida\consolidado\"
    'ruta de respaldo de archivos originales
    Dim rutaBackup As String = "\\10.130.65.147\ImportExport\LaColonia\Salidas\Backup\" '"C:\Users\dandinoc\Documents\Nueva carpeta\salida\backup\" '
    'nombre de archivos buscados
    Dim nombreFichero As String = "SEGALCOCE*.txt"
    'lista de archivos
    Dim listaArchivos As New List(Of Listado)
    Dim listaValoresSeleccionados As New List(Of String)
    Dim listaValoresOCSeleccionada As New List(Of String)
    Dim listaOCarchivo1 As New List(Of String)
    Dim listaOCarchivo2 As New List(Of String)
    'nombre de ruta archivos para consolidacion
    Dim archivoConsolidacion1 As String
    Dim archivoConsolidacion2 As String
    'linea busqueda de valor de #OC
    Dim lineaBuscada As Integer = 3
    'posicion inicio y longitud de valores para extraccion de #OC
    Dim posicionInicial As Integer = 1
    Dim longitudValor As Integer = 18
    'contenido de los archivos a consolidadr
    Dim contenido1 As String
    Dim contenido2 As String
    'contador de posicion de lienas
    Dim numLin As Integer
    Dim linOC As Integer
    'nombre de archivos que seran consolidados y movidos
    Dim archivo1 As String
    Dim archivo2 As String
    Dim orden1 As String
    Dim orden2 As String
    'valro de fichero a contabilizar
    Dim archivoImportar As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3_Click(Me, EventArgs.Empty)
        Timer1.Start()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim valArchivo As String = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
        archivoImportar = valArchivo
        TextBox1.Text = valArchivo
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'archivo original
        Dim pathpesalidaauto As String = rutaArchivoOrigen + archivoImportar
        'archivo detino
        Dim path2pesalidaauto As String = rutasalida + archivoImportar
        'arcivo destino backup
        Dim path2pesalidaBackup As String = rutaBackup + archivoImportar
        Try
            'mover el fichero a destino backup
            My.Computer.FileSystem.MoveFile(pathpesalidaauto, path2pesalidaBackup)
            'mover el fichero a destino salida
            My.Computer.FileSystem.CopyFile(path2pesalidaBackup, path2pesalidaauto)
        Catch ex As Exception
            MessageBox.Show("Es necesario dar click sobre almenos una OC para contabilizar!!")
        End Try
        'refrescar la lista de archivos en pantalla
        Button3_Click(Me, EventArgs.Empty)
    End Sub

    Dim valorBuscado As String = ""
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'vaciar el listado de archivos
        DataGridView1.DataSource = Nothing
        'vaciar la lista de datos
        listaArchivos.Clear()

        Try
            'definir ruta de origen de la informacion
            Dim archivos() As String = Directory.GetFiles(rutaArchivoOrigen, nombreFichero)
            'recorrer y buscar todos los ficheros que cumplan los valores definidos
            For Each archivo As String In archivos
                Dim textofin2 As String = "[H1]" & vbCrLf & "000000003"
                Dim objReaderOESalidaManual As StreamReader
                objReaderOESalidaManual = New StreamReader(archivo)
                Dim sLineOESalidaManual As String = ""
                Dim encOESalidaManual As String

                sLineOESalidaManual = objReaderOESalidaManual.ReadToEnd()
                objReaderOESalidaManual.Close()
                encOESalidaManual = InStr(sLineOESalidaManual, textofin2)
                If encOESalidaManual > 0 Then
                    'leer el contenido de los archivos encontrados
                    Using reader As New StreamReader(archivo)
                        Dim ContLineas As Integer = 0
                        'leer hasta el final cada archivo
                        While Not reader.EndOfStream
                            ContLineas += 1
                            'obtener el valor de cada linea del archivo
                            Dim linea As String = reader.ReadLine()
                            'si se llega a la linea buscada
                            If ContLineas = lineaBuscada Then
                                'guardar valor buscado dentro de la lista de datos
                                listaArchivos.Add(New Listado With {.ORDEN = linea.Substring(posicionInicial - 1, longitudValor),
                                                  .COMENTARIO = linea.Substring(32, 27),
                                                  .FICHERO = archivo.Substring(archivo.LastIndexOf("\") + 1).ToString})
                            End If
                        End While
                    End Using
                Else
                    My.Computer.FileSystem.MoveFile(archivo, rutaBackup + archivo.Substring(archivo.LastIndexOf("\") + 1).ToString)
                End If


            Next
        Catch ex As Exception
            MessageBox.Show("Error al obtener los archivos: " & ex.Message)
        End Try
        'mostrar los valores listados
        DataGridView1.DataSource = listaArchivos
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'obtener el nombre de los ficheros seleccionados en el listado
        If DataGridView1.SelectedRows.Count > 2 Then
            DataGridView1.SelectedRows(DataGridView1.SelectedRows.Count - 1).Selected = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'se valida y obtiene valores seleccionados de la lista de valores
            For Each fila As DataGridViewRow In DataGridView1.SelectedRows
                Dim fichero As String = fila.Cells("FICHERO").Value
                Dim orden As String = fila.Cells("ORDEN").Value
                listaValoresSeleccionados.Add($"{fichero}")
                listaValoresOCSeleccionada.Add($"{orden}")
            Next
            'se asignan los valores seleccionados a variables para su trabajo
            For i As Integer = 0 To listaValoresSeleccionados.Count - 1
                If i = 0 Then
                    archivoConsolidacion1 = rutaArchivoOrigen + listaValoresSeleccionados(i)
                    archivo1 = listaValoresSeleccionados(i)
                    orden1 = listaValoresOCSeleccionada(i)
                Else
                    archivoConsolidacion2 = rutaArchivoOrigen + listaValoresSeleccionados(i)
                    archivo2 = listaValoresSeleccionados(i)
                    orden2 = listaValoresOCSeleccionada(i)
                End If
            Next
            'se lee y guarda el contenido del primer fichero validando que este no incluya etiquetas de inicio y fin

            Using reader1 As New StreamReader(archivoConsolidacion1)
                Do While Not reader1.EndOfStream()
                    contenido1 = reader1.ReadLine()
                    numLin += 1
                    If contenido1 = "[H1]" Then
                        linOC = numLin + 1
                    End If
                    If numLin = linOC Then
                        listaOCarchivo1.Add($"{contenido1.Substring(posicionInicial - 1, longitudValor)}")
                    End If
                    If contenido1 <> "[INICIO]" And contenido1 <> "[FIN]" Then
                        ListBox1.Items.Add(contenido1)
                    End If
                Loop
                numLin = 0
                linOC = 0
            End Using
            'se lee y guarda el contenido del segundo fichero partiendo de la linea 4 donde se guarda la primera etiqueta H2
            Using reader2 As New StreamReader(archivoConsolidacion2)
                Do While Not reader2.EndOfStream()
                    contenido2 = reader2.ReadLine()
                    numLin += 1
                    If contenido2 = "[H1]" Then
                        linOC = numLin + 1
                    End If
                    If numLin = linOC Then
                        listaOCarchivo2.Add($"{contenido2.Substring(posicionInicial - 1, longitudValor)}")
                    End If
                    If contenido1 <> "[INICIO]" And contenido1 <> "[FIN]" Then ' And numLin >= 2 Then
                        ListBox2.Items.Add(contenido2)
                    End If
                Loop
            End Using

            'se definen valores del nombre del nuevo fichero
            Dim fecha As Date = Now()
            Dim Aconsolidado As String = fecha.ToString("yyyyMMddHHmmss") + ".txt"
            Dim rutaescritura As String = rutasalida + "SGCLCOMA" + Aconsolidado
            Dim rutaescritura2 As String = rutaconsolidad + "SGCLCOMA" + Aconsolidado
            Dim listaconcatenada As New List(Of String)

            'se procesa el contenido del primer fichero dentro de la variable contenedora
            For Each item In ListBox1.Items
                listaconcatenada.Add(item)
            Next
            'se procesa el contenido del segundo fichero dentro de la variable contenedora
            For Each item In ListBox2.Items
                listaconcatenada.Add(item)
            Next
            If listaOCarchivo1.Intersect(listaOCarchivo2).Count() > 0 Then
                'If orden1 = orden2 Then
                'se crea y escribe nuevo fichero con los datos de origen
                Using writer As New StreamWriter(rutaescritura)
                    writer.WriteLine("[INICIO]")
                    For Each item In listaconcatenada
                        writer.WriteLine(item)
                    Next
                    writer.WriteLine("[FIN]")
                End Using
                'se crea y escribe backup del nuevo fichero con los datos de origen
                Using writer As New StreamWriter(rutaescritura2)
                    writer.WriteLine("[INICIO]")
                    For Each item In listaconcatenada
                        writer.WriteLine(item)
                    Next
                    writer.WriteLine("[FIN]")
                End Using
                'se definen rutas de respaldo de Ordenes consolidadas
                Dim path2pesalidaauto As String = rutaconsolidad + archivo1 + "_CONSOLIDADOEN_" + Aconsolidado
                Dim path3pesalidaauto As String = rutaconsolidad + archivo2 + "_CONSOLIDADOEN_" + Aconsolidado
                'se mueven los ficheros a una carpeta de respaldo despues de su consolidacion
                My.Computer.FileSystem.MoveFile(archivoConsolidacion1, path2pesalidaauto)
                My.Computer.FileSystem.MoveFile(archivoConsolidacion2, path3pesalidaauto)
            Else
                MessageBox.Show("Los archivos seleccionados no contienen las mismas OC")
            End If

            listaOCarchivo1.Clear()
            listaOCarchivo2.Clear()

            'se llama funcion dentro de bonton3 para refrescar la pantalla y las listas
            Button3_Click(Me, EventArgs.Empty)
        Catch ex As Exception
            'se envia notificacion de valores insuficientes para la consolidacion
            MessageBox.Show("Es obligatorio seleccionar mas de un archivo para consolidadr!!")
            'se limpia la lista de valores
            listaValoresSeleccionados.Clear()
            'se llama funcion dentro de bonton3 para refrescar la pantalla y las listas
            Button3_Click(Me, EventArgs.Empty)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'llamado a cierre de aplicacion
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button3_Click(Me, EventArgs.Empty)
    End Sub
End Class



