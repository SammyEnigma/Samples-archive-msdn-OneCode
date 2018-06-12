﻿'****************************** 模块头 ******************************\
' 模块名:	Global.vb
' 项目名: StoryCreatorWebRole
' 版权 (c) Microsoft Corporation.
' 
' Global.asax 文件.用来初始化Azure的存储 .
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Web.SessionState
Imports Microsoft.WindowsAzure
Imports System.Web.Routing
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports Microsoft.ApplicationServer.Http.Activation

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Friend Shared StorageAccount As CloudStorageAccount

    Public Shared Sub RegisterRoutes(routes As RouteCollection)
        routes.MapServiceRoute(Of StoryService)("stories")
    End Sub

    ''' <summary>
    ''' Intitialize the Azure storage.
    ''' If not running in Compute Emulator or the cloud,
    ''' we use Storage Emulator.
    ''' Supress CA2122 as RoleEnvironment.IsAvailable should not introduce any security issues.
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")> _
    Friend Shared Function InitializeStorage() As Boolean
        Try
            ' For test purpose only, if we do not run the service in compute emulator, we always use dev storage.
            If RoleEnvironment.IsAvailable Then
                CloudStorageAccount.SetConfigurationSettingPublisher(Function(configName, configSetter)
                                                                         configSetter(RoleEnvironment.GetConfigurationSettingValue(configName))

                                                                     End Function)
                StorageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
            Else
                StorageAccount = CloudStorageAccount.DevelopmentStorageAccount
            End If

            Dim blobClient As New CloudBlobClient(StorageAccount.BlobEndpoint, StorageAccount.Credentials)
            Dim container As CloudBlobContainer = blobClient.GetContainerReference("videostories")
            container.CreateIfNotExist()
            Dim queueClient As New CloudQueueClient(StorageAccount.QueueEndpoint, StorageAccount.Credentials)
            Dim queue As CloudQueue = queueClient.GetQueueReference("videostories")
            queue.CreateIfNotExist()
            Dim tableClient As New CloudTableClient(StorageAccount.TableEndpoint.AbsoluteUri, StorageAccount.Credentials)
            tableClient.CreateTableIfNotExist("Stories")
            Return True
        Catch ex As Exception
            Trace.Write("Error initializing storage: " + ex.Message, "Error")
            Return False
        End Try
    End Function

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        RegisterRoutes(RouteTable.Routes)
        InitializeStorage()
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class