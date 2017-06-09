Imports System
Imports System.Web.HttpUtility

'Author:
'   Full name: Mathias Lykkegaard Lorenzen
'   Nickname: Mathy
'   Email: mathias.lorenzen@flamefusion.net
'   Website: http://fsearch.us

Public Class WolframAlphaAssumption

    Private WA_Word As String
    Private WA_Categories As New List(Of String)

    Public Property Word As String
        Get
            Return WA_Word
        End Get
        Set(ByVal value As String)
            WA_Word = value
        End Set
    End Property

    Public Property Categories As List(Of String)
        Get
            Return WA_Categories
        End Get
        Set(ByVal value As List(Of String))
            WA_Categories = value
        End Set
    End Property

End Class

Public Class WolframAlphaQuery

    'Private Const MainRoot As String = "http://api.wolframalpha.com/v1/query.jsp"

    Private WA_APIKey As String

    Public Property APIKey As String
        Get
            Return WA_APIKey
        End Get
        Set(ByVal value As String)
            WA_APIKey = value
        End Set
    End Property

    Private WA_Format As String
    Private WA_Substitution As String
    Private WA_Assumption As String
    Private WA_Query As String
    Private WA_PodTitle As String
    Private WA_TimeLimit As Integer
    Private WA_AllowCached As Boolean
    Private WA_Asynchronous As Boolean
    Private WA_MoreOutput As Boolean

    Public Property MoreOutput As Boolean
        Get
            Return WA_MoreOutput
        End Get
        Set(ByVal value As Boolean)
            WA_MoreOutput = value
        End Set
    End Property

    Public Property Format As String
        Get
            Return WA_Format
        End Get
        Set(ByVal value As String)
            WA_Format = value
        End Set
    End Property

    Public Property Asynchronous As Boolean
        Get
            Return WA_Asynchronous
        End Get
        Set(ByVal value As Boolean)
            WA_Asynchronous = value
        End Set
    End Property

    Public Property AllowCaching As Boolean
        Get
            Return WA_AllowCached
        End Get
        Set(ByVal value As Boolean)
            WA_AllowCached = False
        End Set
    End Property

    Public Property Query As String
        Get
            Return WA_Query
        End Get
        Set(ByVal value As String)
            WA_Query = value
        End Set
    End Property

    Public Property TimeLimit As Integer
        Get
            Return WA_TimeLimit
        End Get
        Set(ByVal value As Integer)
            WA_TimeLimit = value
        End Set
    End Property

    Public Sub AddPodTitle(ByVal PodTitle As String, Optional ByVal CheckForDuplicates As Boolean = False)
        If CheckForDuplicates = True AndAlso WA_PodTitle.Contains("&PodTitle=" & UrlEncode(PodTitle)) Then
            Exit Sub
        End If
        WA_PodTitle &= "&podtitle=" & UrlEncode(PodTitle)
    End Sub

    Public Sub AddSubstitution(ByVal Substitution As String, Optional ByVal CheckForDuplicates As Boolean = False)
        If CheckForDuplicates = True AndAlso WA_Substitution.Contains("&substitution=" & UrlEncode(Substitution)) Then
            Exit Sub
        End If
        WA_Substitution &= "&substitution=" & UrlEncode(Substitution)
    End Sub

    Public Sub AddAssumption(ByVal Assumption As String, Optional ByVal CheckForDuplicates As Boolean = False)
        If CheckForDuplicates = True AndAlso WA_Assumption.Contains("&substitution=" & UrlEncode(Assumption)) Then
            Exit Sub
        End If
        WA_Assumption &= "&assumption=" & UrlEncode(Assumption)
    End Sub

    Public Sub AddAssumption(ByVal Assumption As WolframAlphaAssumption, Optional ByVal CheckForDuplicates As Boolean = False)
        If CheckForDuplicates = True AndAlso WA_Assumption.Contains("&substitution=" & UrlEncode(Assumption.Word)) Then
            Exit Sub
        End If
        WA_Assumption &= "&assumption=" & UrlEncode(Assumption.Word)
    End Sub

    Private Function UrlEncode(word As String) As String
        Return word
    End Function

    Public ReadOnly Property Substitutions() As String()
        Get
            Return WA_Substitution.Split(New String() {"&substitution="}, StringSplitOptions.RemoveEmptyEntries)
        End Get
    End Property

    Public ReadOnly Property Assumptions() As String()
        Get
            Return WA_Assumption.Split(New String() {"&assumption="}, StringSplitOptions.RemoveEmptyEntries)
        End Get
    End Property

    Public ReadOnly Property PodTitles() As String()
        Get
            Return WA_PodTitle.Split(New String() {"&assumption="}, StringSplitOptions.RemoveEmptyEntries)
        End Get
    End Property

    Public ReadOnly Property FullQueryString As String
        Get
            Return "?appid=" & WA_APIKey & "&moreoutput=" & MoreOutput & "&timelimit=" & TimeLimit & "&format=" & WA_Format & "&input=" & WA_Query & WA_Assumption & WA_Substitution
        End Get
    End Property

    Public Class WolframAlphaQueryFormat
        Public Shared Image As String = "image"
        Public Shared HTML As String = "html"
        Public Shared PDF As String = "pdf"
        Public Shared PlainText As String = "plaintext"
        Public Shared MathematicaInput As String = "minput"
        Public Shared MathematicaOutput As String = "moutput"
        Public Shared MathematicaMathMarkupLanguage As String = "mathml"
        Public Shared MathematicaExpressionMarkupLanguage As String = "expressionml"
        Public Shared ExtensibleMarkupLanguage As String = "xml"
    End Class

End Class

Public Class WolframAlphaValidationResult

    Private WA_ParseData As String
    Private WA_Assumptions As List(Of WolframAlphaAssumption)
    Private WA_Success As Boolean
    Private WA_Error As Boolean
    Private WA_Timing As Double

    Public Property Success As Boolean
        Get
            Return WA_Success
        End Get
        Set(ByVal value As Boolean)
            WA_Success = value
        End Set
    End Property

    Public Property ParseData As String
        Get
            Return WA_ParseData
        End Get
        Set(ByVal value As String)
            WA_ParseData = value
        End Set
    End Property

    Public Property Assumptions As List(Of WolframAlphaAssumption)
        Get
            Return WA_Assumptions
        End Get
        Set(ByVal value As List(Of WolframAlphaAssumption))
            WA_Assumptions = value
        End Set
    End Property

    Public Property ErrorOccured As Boolean
        Get
            Return WA_Error
        End Get
        Set(ByVal value As Boolean)
            WA_Error = value
        End Set
    End Property

    Public Property Timing As Double
        Get
            Return WA_Timing
        End Get
        Set(ByVal value As Double)
            WA_Timing = value
        End Set
    End Property

End Class

Public Class WolframAlphaEngine

    Private WA_APIKey As String

    Private WA_QueryResult As WolframAlphaQueryResult
    Private WA_ValidationResult As WolframAlphaValidationResult

    Public Sub New(ByVal APIKey As String)
        WA_APIKey = APIKey
    End Sub

    Public Property APIKey As String
        Get
            Return WA_APIKey
        End Get
        Set(ByVal value As String)
            WA_APIKey = value
        End Set
    End Property

    Public ReadOnly Property QueryResult As WolframAlphaQueryResult
        Get
            Return WA_QueryResult
        End Get
    End Property

    Public ReadOnly Property ValidationResult As WolframAlphaValidationResult
        Get
            Return WA_ValidationResult
        End Get
    End Property

#Region "Overloads of ValidateQuery"

    Public Function ValidateQuery(ByVal Query As WolframAlphaQuery) As WolframAlphaValidationResult

        If Query.APIKey = "" Then
            If Me.APIKey = "" Then
                Throw New Exception("To use the Wolfram Alpha API, you must specify an API key either through the parsed WolframAlphaQuery, or on the WolframAlphaEngine itself.")
            End If
            Query.APIKey = Me.APIKey
        End If

        If Query.Asynchronous = True AndAlso Query.Format = WolframAlphaQuery.WolframAlphaQueryFormat.HTML Then
            Throw New Exception("Wolfram Alpha does not allow asynchronous operations while the format for the query is not set to ""HTML"".")
        End If

        Dim WebRequest As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("http://preview.wolframalpha.com/api/v1/validatequery.jsp" & Query.FullQueryString), System.Net.HttpWebRequest)
        WebRequest.KeepAlive = True
        Dim Response As String = New IO.StreamReader(WebRequest.GetResponse().GetResponseStream()).ReadToEnd()

        Return ValidateQuery(Response)

    End Function

    Public Function ValidateQuery(ByVal Response As String) As WolframAlphaValidationResult

        Dim Document As New Xml.XmlDocument
        Dim Result As WolframAlphaValidationResult = Nothing
        Try
            Document.LoadXml(Response)
            Result = ValidateQuery(Document)
        Catch
        End Try
        Document = Nothing

        Return Result

    End Function

    Public Function ValidateQuery(ByVal Response As Xml.XmlDocument) As WolframAlphaValidationResult

        System.Threading.Thread.Sleep(1)

        Dim MainNode As Xml.XmlNode = Response.SelectNodes("/validatequeryresult")(0)

        WA_ValidationResult = New WolframAlphaValidationResult
        WA_ValidationResult.Success = MainNode.Attributes("success").Value
        WA_ValidationResult.ErrorOccured = MainNode.Attributes("error").Value
        WA_ValidationResult.Timing = MainNode.Attributes("timing").Value
        WA_ValidationResult.ParseData = MainNode.SelectNodes("parsedata")(0).InnerText
        WA_ValidationResult.Assumptions = New List(Of WolframAlphaAssumption)

        For Each Node As Xml.XmlNode In MainNode.SelectNodes("assumptions")

            System.Threading.Thread.Sleep(1)

            Dim Assumption As New WolframAlphaAssumption

            Assumption.Word = Node.SelectNodes("word")(0).InnerText

            Dim SubNode As Xml.XmlNode = Node.SelectNodes("categories")(0)

            For Each ContentNode As Xml.XmlNode In SubNode.SelectNodes("category")

                System.Threading.Thread.Sleep(1)

                Assumption.Categories.Add(ContentNode.InnerText)

            Next

            WA_ValidationResult.Assumptions.Add(Assumption)

        Next

        Return WA_ValidationResult

    End Function

#End Region

#Region "Overloads of LoadResponse"

    Public Function LoadResponse(ByVal Query As WolframAlphaQuery) As WolframAlphaQueryResult

        If Query.APIKey = "" Then
            If Me.APIKey = "" Then
                Throw New Exception("To use the Wolfram Alpha API, you must specify an API key either through the parsed WolframAlphaQuery, or on the WolframAlphaEngine itself.")
            End If
            Query.APIKey = Me.APIKey
        End If

        If Query.Asynchronous = True AndAlso Query.Format = WolframAlphaQuery.WolframAlphaQueryFormat.HTML Then
            Throw New Exception("Wolfram Alpha does not allow asynchronous operations while the format for the query is not set to ""HTML"".")
        End If

        Dim WebRequest As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("http://preview.wolframalpha.com/api/v1/query.jsp" & Query.FullQueryString), System.Net.HttpWebRequest)
        WebRequest.KeepAlive = True
        Dim Response As String = New IO.StreamReader(WebRequest.GetResponse().GetResponseStream()).ReadToEnd()

        Return LoadResponse(Response)

    End Function
    Public Function LoadResponse(ByVal Response As String) As WolframAlphaQueryResult

        Dim Document As New Xml.XmlDocument
        Dim Result As WolframAlphaQueryResult = Nothing
        Try
            Document.LoadXml(Response)
            Result = LoadResponse(Document)
        Catch
        End Try
        Document = Nothing

        Return Result

    End Function
    Public Function LoadResponse(ByVal Response As Xml.XmlDocument) As WolframAlphaQueryResult

        System.Threading.Thread.Sleep(1)

        Dim MainNode As Xml.XmlNode = Response.SelectNodes("/queryresult")(0)
        WA_QueryResult = New WolframAlphaQueryResult
        WA_QueryResult.Success = MainNode.Attributes("success").Value
        WA_QueryResult.ErrorOccured = MainNode.Attributes("error").Value
        WA_QueryResult.NumberOfPods = MainNode.Attributes("numpods").Value
        WA_QueryResult.Timing = MainNode.Attributes("timing").Value
        WA_QueryResult.TimedOut = MainNode.Attributes("timedout").Value
        WA_QueryResult.DataTypes = MainNode.Attributes("datatypes").Value
        WA_QueryResult.Pods = New List(Of WolframAlphaPod)

        For Each Node As Xml.XmlNode In MainNode.SelectNodes("pod")

            System.Threading.Thread.Sleep(1)

            Dim Pod As New WolframAlphaPod

            Pod.Title = Node.Attributes("title").Value
            Pod.Scanner = Node.Attributes("scanner").Value
            Pod.Position = Node.Attributes("position").Value
            Pod.ErrorOccured = Node.Attributes("error").Value
            Pod.NumberOfSubPods = Node.Attributes("numsubpods").Value
            Pod.SubPods = New List(Of WolframAlphaSubPod)

            For Each SubNode As Xml.XmlNode In Node.SelectNodes("subpod")

                System.Threading.Thread.Sleep(1)

                Dim SubPod As New WolframAlphaSubPod
                SubPod.Title = SubNode.Attributes("title").Value

                For Each ContentNode As Xml.XmlNode In SubNode.SelectNodes("plaintext")

                    System.Threading.Thread.Sleep(1)

                    SubPod.PodText = ContentNode.InnerText

                Next

                For Each ContentNode As Xml.XmlNode In SubNode.SelectNodes("img")

                    System.Threading.Thread.Sleep(1)

                    Dim Image As New WolframAlphaImage
                    Image.Location = New Uri(ContentNode.Attributes("src").Value)
                    Image.HoverText = ContentNode.Attributes("alt").Value
                    Image.Title = ContentNode.Attributes("title").Value
                    Image.Width = ContentNode.Attributes("width").Value
                    Image.Height = ContentNode.Attributes("height").Value
                    SubPod.PodImage = Image

                Next

                Pod.SubPods.Add(SubPod)

            Next

            WA_QueryResult.Pods.Add(Pod)

        Next

        Return WA_QueryResult

    End Function

#End Region

End Class

Public Class WolframAlphaQueryResult

    Private WA_Pods As List(Of WolframAlphaPod)
    Private WA_Success As Boolean
    Private WA_Error As Boolean
    Private WA_NumberOfPods As Integer
    Private WA_DataTypes As String
    Private WA_TimedOut As String
    Private WA_Timing As Double
    Private WA_ParseTiming As Double

    Public Property Pods As List(Of WolframAlphaPod)
        Get
            Return WA_Pods
        End Get
        Set(ByVal value As List(Of WolframAlphaPod))
            WA_Pods = value
        End Set
    End Property

    Public Property Success As Boolean
        Get
            Return WA_Success
        End Get
        Set(ByVal value As Boolean)
            WA_Success = value
        End Set
    End Property

    Public Property ErrorOccured As Boolean
        Get
            Return WA_Error
        End Get
        Set(ByVal value As Boolean)
            WA_Error = value
        End Set
    End Property

    Public Property NumberOfPods As Integer
        Get
            Return WA_NumberOfPods
        End Get
        Set(ByVal value As Integer)
            WA_NumberOfPods = value
        End Set
    End Property

    Public Property DataTypes As String
        Get
            Return WA_DataTypes
        End Get
        Set(ByVal value As String)
            WA_DataTypes = value
        End Set
    End Property

    Public Property TimedOut As String
        Get
            Return WA_TimedOut
        End Get
        Set(ByVal value As String)
            WA_TimedOut = value
        End Set
    End Property

    Public Property Timing As Double
        Get
            Return WA_Timing
        End Get
        Set(ByVal value As Double)
            WA_Timing = value
        End Set
    End Property

    Public Property ParseTiming As Double
        Get
            Return WA_ParseTiming
        End Get
        Set(ByVal value As Double)
            WA_ParseTiming = value
        End Set
    End Property

End Class

Public Class WolframAlphaPod

    Private WA_SubPods As List(Of WolframAlphaSubPod)
    Private WA_Title As String
    Private WA_Scanner As String
    Private WA_Position As Integer
    Private WA_Error As Boolean
    Private WA_NumberOfSubPods As Integer

    Public Property SubPods As List(Of WolframAlphaSubPod)
        Get
            Return WA_SubPods
        End Get
        Set(ByVal value As List(Of WolframAlphaSubPod))
            WA_SubPods = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return WA_Title
        End Get
        Set(ByVal value As String)
            WA_Title = value
        End Set
    End Property

    Public Property Scanner As String
        Get
            Return WA_Scanner
        End Get
        Set(ByVal value As String)
            WA_Scanner = value
        End Set
    End Property

    Public Property Position As Integer
        Get
            Return WA_Position
        End Get
        Set(ByVal value As Integer)
            WA_Position = value
        End Set
    End Property

    Public Property ErrorOccured As Boolean
        Get
            Return WA_Error
        End Get
        Set(ByVal value As Boolean)
            WA_Error = value
        End Set
    End Property

    Public Property NumberOfSubPods As Integer
        Get
            Return WA_NumberOfSubPods
        End Get
        Set(ByVal value As Integer)
            WA_NumberOfSubPods = value
        End Set
    End Property

End Class

Public Class WolframAlphaSubPod

    Private WA_Title As String
    Private WA_PodText As String
    Private WA_PodImage As WolframAlphaImage

    Public Property Title As String
        Get
            Return WA_Title
        End Get
        Set(ByVal value As String)
            WA_Title = value
        End Set
    End Property

    Public Property PodText As String
        Get
            Return WA_PodText
        End Get
        Set(ByVal value As String)
            WA_PodText = value
        End Set
    End Property

    Public Property PodImage As WolframAlphaImage
        Get
            Return WA_PodImage
        End Get
        Set(ByVal value As WolframAlphaImage)
            WA_PodImage = value
        End Set
    End Property

End Class

Public Class WolframAlphaImage

    Private WA_Location As Uri
    Private WA_Width As Integer
    Private WA_Height As Integer
    Private WA_Title As String
    Private WA_HoverText As String

    Public Property Location As Uri
        Get
            Return WA_Location
        End Get
        Set(ByVal value As Uri)
            WA_Location = value
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return WA_Width
        End Get
        Set(ByVal value As Integer)
            WA_Width = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return WA_Height
        End Get
        Set(ByVal value As Integer)
            WA_Height = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return WA_Title
        End Get
        Set(ByVal value As String)
            WA_Title = value
        End Set
    End Property

    Public Property HoverText As String
        Get
            Return WA_HoverText
        End Get
        Set(ByVal value As String)
            WA_HoverText = value
        End Set
    End Property

End Class