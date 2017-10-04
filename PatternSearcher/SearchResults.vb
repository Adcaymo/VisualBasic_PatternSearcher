Public Class SearchResults
    Private m_Matches As Integer
    Private m_Results As List(Of FoundResults)
    Private m_Time As Double

    Public Sub New()
        Me.Matches = 0
        Me.Results = New List(Of FoundResults)
        Me.Time = 0
    End Sub

    Public Sub New(matches As Integer,
                   results As List(Of FoundResults),
                   time As Integer)
        Me.Matches = matches
        Me.Results = results
        Me.Time = time
    End Sub

    Public Property Matches() As Integer
        Get
            Return m_Matches
        End Get
        Set(ByVal value As Integer)
            m_Matches = value
        End Set
    End Property

    Public Property Results() As List(Of FoundResults)
        Get
            Return m_Results
        End Get
        Set(ByVal value As List(Of FoundResults))
            m_Results = value
        End Set
    End Property

    Public Property Time() As Double
        Get
            Return m_Time
        End Get
        Set(ByVal value As Double)
            m_Time = value
        End Set
    End Property
End Class
