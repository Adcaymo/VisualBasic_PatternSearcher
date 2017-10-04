Public Class FoundResults
    Private m_BaseFileName As String
    Private m_InputLine As String
    Private m_LineNumber As Integer

    Public Sub New()
        Me.BaseFileName = ""
        Me.InputLine = ""
        Me.LineNumber = 0
    End Sub

    Public Sub New(baseFileName As String,
                   inputLine As String,
                   lineNumber As Integer)
        Me.BaseFileName = baseFileName
        Me.InputLine = inputLine
        Me.LineNumber = lineNumber
    End Sub

    Public Property BaseFileName() As String
        Get
            Return m_BaseFileName
        End Get
        Set(ByVal value As String)
            m_BaseFileName = value
        End Set
    End Property

    Public Property InputLine() As String
        Get
            Return m_InputLine
        End Get
        Set(ByVal value As String)
            m_InputLine = value
        End Set
    End Property

    Public Property LineNumber() As Integer
        Get
            Return m_LineNumber
        End Get
        Set(ByVal value As Integer)
            m_LineNumber = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("{0}: {1} - {2}", BaseFileName, LineNumber, InputLine)
    End Function
End Class
