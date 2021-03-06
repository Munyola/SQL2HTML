﻿Public Class TableContainer
    Public Property Tables As List(Of Table)

    Public Sub New()
        Tables = New List(Of Table)
    End Sub

    ''' <summary>
    ''' Transforms multiple tables to HTML in valid XHTML 1.0
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Function ToHTML() As String
        Dim sql As String = ""

        sql = "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">" &
        "<html xmlns=""http://www.w3.org/1999/xhtml"" lang=""en"" xml:lang=""en"">" &
        "<head>" &
        "<meta http-equiv=""Content-type"" content=""text/html;charset=UTF-8"" /> " &
        "<title>Database Compare</title>" &
        "<link rel=""stylesheet"" href=""styles.css"" />" &
        "</head><body>" &
        "<p><img src=""logo.gif"" alt=""Logo"" height=""71"" width=""170""/><br /></p><h1>Database Structure Documentation</h1>"
        '^ line above needs to be adjusted to your wishes

        For Each table In Tables
            sql = sql & table.ToHTML
        Next

        sql = sql & "<p><a href=""http://validator.w3.org/check?uri=referer""><img " &
                            "src=""http://www.w3.org/Icons/valid-xhtml10"" alt=""Valid XHTML 1.0 Strict"" height=""31"" width=""88""/></a>" &
                            String.Format(" Generated by SQL2HTML on {0}", Now()) &
                    "</p>"

        sql = sql & "</body></html>"

        Return sql
    End Function

End Class
