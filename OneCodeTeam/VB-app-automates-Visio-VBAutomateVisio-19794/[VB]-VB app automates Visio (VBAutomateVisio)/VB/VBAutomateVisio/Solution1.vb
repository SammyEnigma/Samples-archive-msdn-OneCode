﻿' ******************************** Module Header ********************************\
' Module Name:  Solution1.vb
' Project:      VBAutomateVisio
' Copyright (c) Microsoft Corporation.
' 
' Solution1.AutomateVisio demonstrates automating Microsoft Visio application by 
' using Microsoft Visio Primary Interop Assembly (PIA) and explicitly assigning 
' each COM accessor object to a new variable that you would explicitly call 
' Marshal.FinalReleaseComObject to release it at the end. When you use this 
' solution, it is important to avoid calls that tunnel into the object model 
' because they will orphan Runtime Callable Wrapper (RCW) on the heap that you 
' will not be able to access in order to call Marshal.ReleaseComObject. You need 
' to be very careful. For example, 
' 
'            Dim oDoc As Visio.Document = oVisio.Documents.Add("")
'  
' Calling oVisio.Documents.Add creates an RCW for the Documents object. If you 
' invoke these accessors via tunneling as this code does, the RCW for 
' Documents is created on the GC heap, but the reference is created under the 
' hood on the stack and are then discarded. As such, there is no way to call 
' MarshalFinalReleaseComObject on this RCW. To get such kind of RCWs released, 
' you would either need to force a garbage collection as soon as the calling 
' function is off the stack (see Solution2.AutomateVisio), or you would need to 
' explicitly assign each accessor object to a variable and free it.
' 
'            oDocs = oVisio.Documents
'            oDoc = oDocs.Add("")
'   
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' *******************************************************************************/

#Region "Imports directives"

Imports System.Reflection
Imports System.IO

Imports Visio = Microsoft.Office.Interop.Visio
Imports System.Runtime.InteropServices

#End Region


Class Solution1

    Public Shared Sub AutomateVisio()

        Dim oVisio As Visio.Application = Nothing
        Dim oDocs As Visio.Documents = Nothing
        Dim oDoc As Visio.Document = Nothing
        Dim oPages As Visio.Pages = Nothing
        Dim oPage As Visio.Page = Nothing
        Dim oRectShape As Visio.Shape = Nothing
        Dim oOvalShape As Visio.Shape = Nothing

        Try
            ' Create an instance of Microsoft Visio and make it invisible.

            oVisio = New Visio.Application
            oVisio.Visible = False
            Console.WriteLine("Visio.Application is started")

            ' Create a new Document based on no template.

            oDocs = oVisio.Documents
            oDoc = oDocs.Add("")
            Console.WriteLine("A new document is created")

            ' Draw a rectangle and a oval on the first page.

            Console.WriteLine("Draw a rectangle and a oval")

            oPages = oDoc.Pages
            oPage = oPages(1)
            oRectShape = oPage.DrawRectangle(0.5, 10.25, 6.25, 7.375)
            oOvalShape = oPage.DrawOval(1.125, 6, 6.875, 2.125)

            ' Save the document as a vsd file and close it.

            Console.WriteLine("Save and close the document")
            Dim fileName As String = Path.GetDirectoryName( _
            Assembly.GetExecutingAssembly().Location) + "\\Sample1.vsd"
            oDoc.SaveAs(fileName)
            oDoc.Close()

            ' Quit the Visio application.

            Console.WriteLine("Quit the Visio application")
            oVisio.Quit()

        Catch ex As Exception
            Console.WriteLine("Solution1.AutomateVisio throws the error: {0}", _
                              ex.Message)
        Finally

            ' Clean up the unmanaged Visio COM resources by explicitly 
            ' calling Marshal.FinalReleaseComObject on all accessor objects. 
            ' See http://support.microsoft.com/kb/317109.

            If Not oOvalShape Is Nothing Then
                Marshal.FinalReleaseComObject(oOvalShape)
                oOvalShape = Nothing
            End If
            If Not oRectShape Is Nothing Then
                Marshal.FinalReleaseComObject(oRectShape)
                oRectShape = Nothing
            End If
            If Not oPage Is Nothing Then
                Marshal.FinalReleaseComObject(oPage)
                oPage = Nothing
            End If
            If Not oPages Is Nothing Then
                Marshal.FinalReleaseComObject(oPages)
                oPages = Nothing
            End If
            If Not oDoc Is Nothing Then
                Marshal.FinalReleaseComObject(oDoc)
                oDoc = Nothing
            End If
            If Not oDocs Is Nothing Then
                Marshal.FinalReleaseComObject(oDocs)
                oDocs = Nothing
            End If
            If Not oVisio Is Nothing Then
                Marshal.FinalReleaseComObject(oVisio)
                oVisio = Nothing
            End If

        End Try

    End Sub

End Class