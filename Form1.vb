Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rutaArhivo1 As String = "C:\Users\dandinoc\Documents\Nueva carpeta\SEGALCOCE20240823105146167.txt"
        Dim rutaArhivo2 As String = "C:\Users\dandinoc\Documents\Nueva carpeta\20240823-100926-726_SEGALCOCS2024082310081920.txt"
        Dim contenido1 As String
        Dim contenido2 As String

        Using reader1 As New StreamReader(rutaArhivo1)
            Do While Not reader1.EndOfStream()
                contenido1 = reader1.ReadLine()
                If contenido1 <> "[INICIO]" And contenido1 <> "[FIN]" Then
                    ListBox1.Items.Add(contenido1)
                End If
            Loop
        End Using
        Using reader2 As New StreamReader(rutaArhivo2)
            Do While Not reader2.EndOfStream()
                contenido2 = reader2.ReadLine()
                If contenido2 <> "[INICIO]" And contenido2 <> "[FIN]" Then
                    ListBox2.Items.Add(contenido2)
                End If
            Loop
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fecha As Date = Now()
        Dim rutaescritura As String = "C:\Users\dandinoc\Documents\Nueva carpeta\SGCLCOMA" + fecha.ToString("yyyyMMddHHmmss") + ".txt"
        Dim listaconcatenada As New List(Of String)

        For Each item In ListBox1.Items
            listaconcatenada.Add(item)
        Next

        For Each item In ListBox2.Items
            listaconcatenada.Add(item)
        Next

        Using writer As New StreamWriter(rutaescritura)
            writer.WriteLine("[INICIO]")
            For Each item In listaconcatenada
                writer.WriteLine(item)
            Next
            writer.WriteLine("[FIN]")
        End Using
    End Sub
End Class
