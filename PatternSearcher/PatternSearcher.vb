Imports System.IO

Public Class PatternSearcher
    Private m_FileType As String
    Private m_IsCaseSensitive As Boolean
    Private m_Pattern As String
    Private m_StartingLocation As String

    Public Property SearchResultsObj As SearchResults

    Public Sub New()
        m_FileType = ""
        m_IsCaseSensitive = False
        m_Pattern = ""
        m_StartingLocation = ""
    End Sub

    Public Sub New(fileType As String,
                   isCaseSensitive As Boolean,
                   pattern As String,
                   startingLocation As String)
        Me.FileType = fileType
        Me.IsCaseSensitive = isCaseSensitive
        Me.Pattern = pattern
        Me.StartingLocation = startingLocation
    End Sub

    Public Property FileType() As String
        Get
            Return m_FileType
        End Get
        Set(ByVal value As String)
            m_FileType = value
        End Set
    End Property

    Public Property IsCaseSensitive() As Boolean
        Get
            Return m_IsCaseSensitive
        End Get
        Set(ByVal value As Boolean)
            m_IsCaseSensitive = value
        End Set
    End Property

    Public Property Pattern() As String
        Get
            Return m_Pattern
        End Get
        Set(ByVal value As String)
            m_Pattern = value
        End Set
    End Property

    Public Property StartingLocation() As String
        Get
            Return m_StartingLocation
        End Get
        Set(ByVal value As String)
            m_StartingLocation = value
        End Set
    End Property

    Public Sub SearchDirectory()
        If Pattern = "" Then
            Exit Sub
        Else
            Try
                Dim files() As String = Directory.GetFiles(StartingLocation)
                SearchResultsObj = New SearchResults

                Dim watch As Stopwatch = Stopwatch.StartNew() 'start time for processing time
                ReadFiles(files)
                watch.Stop() 'end time for processing time
                SearchResultsObj.Time = watch.Elapsed.TotalMilliseconds
            Catch ex As Exception
                Throw New Exception("Exception raised.")
            End Try
        End If
    End Sub

    'helper methods
    Private Sub ReadFiles(files() As String)
        For Each filePath In files
            Dim lineCount As Integer = 1
            Dim fileContent() As String = File.ReadAllLines(filePath)

            If IsCaseSensitive Then
                If IsValidDataType(filePath) Then
                    For Each line In fileContent
                        If line.Contains(Pattern) Then
                            ProcessFile(filePath, line, lineCount)
                        End If
                        lineCount += 1
                    Next
                End If
            Else
                If IsValidDataType(filePath) Then
                    For Each line In fileContent
                        If line.IndexOf(Pattern, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                            ProcessFile(filePath, line, lineCount)
                        End If
                        lineCount += 1
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub ProcessFile(filePath As String, line As String, lineCount As Integer)
        Dim frObj As New FoundResults
        Dim fileName = filePath.Split("\"c)

        frObj.BaseFileName = fileName(fileName.Length - 1)
        frObj.InputLine = line
        frObj.LineNumber = lineCount
        SearchResultsObj.Matches += 1
        SearchResultsObj.Results.Add(frObj)
    End Sub

    Private Function IsValidDataType(filePath As String) As Boolean
        Dim fileTypes() As String = {"txt", "xml", "html", "*"}

        Dim fileNameTokens() As String = filePath.Split("\"c)
        Dim baseFileName As String = fileNameTokens(fileNameTokens.Length - 1)
        Dim baseFileNameTokens() As String = baseFileName.Split("."c)
        Dim extension As String = baseFileNameTokens(baseFileNameTokens.Length - 1)

        If fileTypes.Contains(extension) Then
            Return True
        End If
        Return False
    End Function
End Class
