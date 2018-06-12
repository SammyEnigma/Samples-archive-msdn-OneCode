﻿'**************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETClientCallbacksWithoutPostback
' Copyright (c) Microsoft Corporation
'
' The web application illustrates how to implement a client postback or partial
' postback to raise the server code or update some elements in HTML markup. Such 
' as TextBox, ListView, GridView. As we know that we can user ASP.NET AJAX control
' to call a Asynchronous request to server, but in this sample, we will implement
' ICallbackEventHandler interface for achieving this goal by this flexible and 
' lightweight method.
' 
' This page is use to display xml file and insert, update, delete record of GridView
' control without postbacks.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports System.Xml
Imports System.IO

Public Class _Default
    Inherits System.Web.UI.Page
    Implements ICallbackEventHandler
    Private strOutput As String
    Private xmlPath As String = AppDomain.CurrentDomain.BaseDirectory + "XmlFile/NameXml.xml"

    ''' <summary>
    ''' Page Load method.
    ''' There we define ClientScriptManager class instances for register JavaScript functions.
    ''' These JS functions are use to invoke RaiseCallbackEvent method, and return string variables 
    ''' to client-side.
    ''' we also need invoke GridViewBind method to display information of xml file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Filter call back event.
        ' Create ClientManager instance of this page.
        Dim clientManager As ClientScriptManager = Page.ClientScript

        ' Create a JS function for invoke WebForm_DoCallback method.
        Dim callBackRef As String = clientManager.GetCallbackEventReference(Me, "arg", "FilterGetOutputFromServer", [String].Empty)
        Dim callBackScript As String = "function FilterCallServerMethod(arg, context) {" & callBackRef & "; }"

        ' Register functions on page.
        clientManager.RegisterClientScriptBlock(Me.[GetType](), "FilterGetOutputFromServer", callBackScript, True)

        ' Delete call back event.
        Dim clientManagerDelete As ClientScriptManager = Page.ClientScript
        Dim deleteCallBackRef As String = clientManagerDelete.GetCallbackEventReference(Me, "arg", "DeleteGetOutputFromServer", [String].Empty)
        Dim deleteCallBackScript As String = "function DeleteCallServerMethod(arg, context){" & deleteCallBackRef & ";}"
        clientManagerDelete.RegisterClientScriptBlock(Me.[GetType](), "DeleteGetOutputFromServer", deleteCallBackScript, True)

        ' Insert call back event.
        Dim clientManagerInsert As ClientScriptManager = Page.ClientScript
        Dim insertCallBackRef As String = clientManagerInsert.GetCallbackEventReference(Me, "arg", "InsertGetOutputFromServer", [String].Empty)
        Dim insertCallBackScript As String = "function InsertCallServerMethod(arg, context){" & insertCallBackRef & ";}"
        clientManagerInsert.RegisterClientScriptBlock(Me.[GetType](), "InsertGetOutputFromServer", insertCallBackScript, True)

        ' Update call back event.
        Dim clientManagerUpdate As ClientScriptManager = Page.ClientScript
        Dim updateCallBackRef As String = clientManagerUpdate.GetCallbackEventReference(Me, "arg", "UpdateGetOutputFromServer", [String].Empty)
        Dim updateCallBackScript As String = "function UpdateCallServerMethod(arg, context){" & updateCallBackRef & ";}"
        clientManagerUpdate.RegisterClientScriptBlock(Me.[GetType](), "UpdateGetOutputFromServer", updateCallBackScript, True)

        ' GridView bind event.
        Me.GridViewBind()
    End Sub

    ''' <summary>
    ''' This method is use to load XML file and convert it to a DataTable variable.
    ''' Set this variable as GridView' data source.
    ''' </summary>
    Private Sub GridViewBind()
        Dim xmlDocument As New XmlDocument()
        xmlDocument.Load(xmlPath)
        Dim nodeList As XmlNodeList = xmlDocument.SelectNodes("Root/Person")
        Dim tabNodes As New DataTable()
        tabNodes.Columns.Add("ID", Type.[GetType]("System.String"))
        tabNodes.Columns.Add("FirstName", Type.[GetType]("System.String"))
        tabNodes.Columns.Add("LastName", Type.[GetType]("System.String"))
        tabNodes.Columns.Add("Age", Type.[GetType]("System.String"))
        For Each node As XmlNode In nodeList
            Dim drTab As DataRow = tabNodes.NewRow()
            drTab("ID") = node.Attributes("id").InnerText
            drTab("FirstName") = node("FirstName").InnerText
            drTab("LastName") = node("LastName").InnerText
            drTab("Age") = node("Age").InnerText
            tabNodes.Rows.Add(drTab)
        Next
        Me.ViewState("Table") = tabNodes
        GvwView.DataSource = Nothing
        GvwView.DataSource = tabNodes
        GvwView.DataBind()
    End Sub


    ''' <summary>
    ''' This method is use to render current HtmlTextWriter object.
    ''' </summary>
    Private Sub Flush()
        Using strWriter As New StringWriter()
            Using htmlWriter As New HtmlTextWriter(strWriter)
                GvwView.RenderControl(htmlWriter)
                htmlWriter.Flush()
                strOutput = strWriter.ToString()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' This method is use to filter similar results of your input words.
    ''' and re-bind them with GridView control.
    ''' </summary>
    ''' <param name="firstName"></param>
    ''' <param name="lastName"></param>
    ''' <param name="age"></param>
    Private Sub FilterGrid(ByVal firstName As String, ByVal lastName As String, ByVal age As String)
        Dim tabName As DataTable = DirectCast(Me.ViewState("Table"), DataTable)
        Dim tabView As DataView = tabName.DefaultView
        tabView.RowFilter = [String].Format("FirstName Like '%{0}%' And LastName Like '%{1}%' And Age Like '%{2}%'", firstName, lastName, age)
        GvwView.DataSource = tabView
        GvwView.DataBind()
        Me.Flush()
    End Sub

    ''' <summary>
    ''' This method is use to delete xml file's records and render new xml data on page.
    ''' </summary>
    ''' <param name="nameId"></param>
    Private Sub DeleteName(ByVal nameId As String)
        Dim xmlDocument As New XmlDocument()
        xmlDocument.Load(xmlPath)
        Dim nodeList As XmlNode = xmlDocument.SelectSingleNode("Root")
        Dim i As Integer
        For i = 0 To nodeList.ChildNodes.Count - 1
            If (i < nodeList.ChildNodes.Count) Then
            Dim elXml As XmlElement = DirectCast(nodeList.ChildNodes(i), XmlElement)
            If nameId = elXml.Attributes("id").InnerText Then
                nodeList.RemoveChild(nodeList.ChildNodes(i))
                End If
            End If
        Next
        xmlDocument.Save(xmlPath)
        Me.GridViewBind()
        Me.Flush()
    End Sub

    ''' <summary>
    ''' This method is use to insert a new record in xml file.
    ''' </summary>
    ''' <param name="firstName"></param>
    ''' <param name="lastName"></param>
    ''' <param name="age"></param>
    Private Sub InsertName(ByVal firstName As String, ByVal lastName As String, ByVal age As String)
        Dim uniqueID As String = Guid.NewGuid().ToString().Replace("-", [String].Empty)
        Dim xmlDocument As New XmlDocument()
        xmlDocument.Load(xmlPath)
        Dim nodeRoot As XmlNode = xmlDocument.SelectSingleNode("Root")
        Dim elePerson As XmlElement = xmlDocument.CreateElement("Person")
        elePerson.SetAttribute("id", uniqueID)
        Dim eleFirstName As XmlElement = xmlDocument.CreateElement("FirstName")
        eleFirstName.InnerText = firstName
        Dim eleLastName As XmlElement = xmlDocument.CreateElement("LastName")
        eleLastName.InnerText = lastName
        Dim eleAge As XmlElement = xmlDocument.CreateElement("Age")
        eleAge.InnerText = age
        elePerson.AppendChild(eleFirstName)
        elePerson.AppendChild(eleLastName)
        elePerson.AppendChild(eleAge)
        nodeRoot.AppendChild(elePerson)
        xmlDocument.Save(xmlPath)
        Me.GridViewBind()
        Me.Flush()
    End Sub

    ''' <summary>
    ''' This method is use to update the records of xml file.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="firstName"></param>
    ''' <param name="lastName"></param>
    ''' <param name="age"></param>
    Private Sub UpdateName(ByVal id As String, ByVal firstName As String, ByVal lastName As String, ByVal age As String)
        Dim xmlDocument As New XmlDocument()
        xmlDocument.Load(xmlPath)
        Dim nodeList As XmlNodeList = xmlDocument.SelectNodes("Root/Person")
        For Each nodeSingle As XmlNode In nodeList
            Dim eleSingle As XmlElement = DirectCast(nodeSingle, XmlElement)
            If nodeSingle.Attributes("id").Value = id Then
                Dim nodeFirstName As XmlNode = nodeSingle.ChildNodes(0)
                Dim eleFirstName As XmlElement = DirectCast(nodeFirstName, XmlElement)
                eleFirstName.InnerText = firstName
                Dim nodeLastName As XmlNode = nodeSingle.ChildNodes(1)
                Dim eleLastName As XmlElement = DirectCast(nodeLastName, XmlElement)
                eleLastName.InnerText = lastName
                Dim nodeAge As XmlNode = nodeSingle.ChildNodes(2)
                Dim eleAge As XmlElement = DirectCast(nodeAge, XmlElement)
                eleAge.InnerText = age
            End If
        Next
        xmlDocument.Save(xmlPath)
        Me.GridViewBind()
        Me.Flush()
    End Sub

    ''' <summary>
    ''' Bind the GridView button controls' onclick events with JavaScript functions.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GvwView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GvwView.RowDataBound
        ' Make sure the current GridViewRow is a data row.
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Make sure the current GridViewRow is either 
            ' in the normal state or an alternate row.
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                ' Add client-side onclick events.
                Dim id As String = DirectCast(e.Row.Cells(2), DataControlFieldCell).Text
                Dim firstName As String = DirectCast(e.Row.Cells(3), DataControlFieldCell).Text.Replace("&nbsp;", "")
                Dim lastName As String = DirectCast(e.Row.Cells(4), DataControlFieldCell).Text.Replace("&nbsp;", "")
                Dim age As String = DirectCast(e.Row.Cells(5), DataControlFieldCell).Text.Replace("&nbsp;", "")
                DirectCast(e.Row.Cells(1).Controls(0), LinkButton).Attributes.Add("onclick", [String].Format("DeleteName('{0}'); return false;", id))
                DirectCast(e.Row.Cells(0).Controls(0), LinkButton).Attributes.Add("onclick", [String].Format("GiveValue('{0}','{1}','{2}','{3}'); return false;", id, firstName, lastName, age))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Return a output string variable and display it on page.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Return strOutput
    End Function

    ''' <summary>
    ''' This method is use to receive arguments from JS functions, and check the header 
    ''' of the string variable for invoke different methods.
    ''' </summary>
    ''' <param name="eventArgument"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        Dim str As String() = eventArgument.Split("|"c)
        If str(0).Equals("Filter", StringComparison.OrdinalIgnoreCase) Then
            Me.FilterGrid(str(1), str(2), str(3))
        ElseIf str(0).Equals("Delete", StringComparison.OrdinalIgnoreCase) Then
            Me.DeleteName(str(1))
        ElseIf str(0).Equals("Insert", StringComparison.OrdinalIgnoreCase) Then
            Me.InsertName(str(1), str(2), str(3))
        ElseIf str(0).Equals("Update", StringComparison.OrdinalIgnoreCase) Then
            Me.UpdateName(str(1), str(2), str(3), str(4))
        End If
    End Sub
End Class